using UnityEngine;
using UnityEngine.AI;
using RoadArchitect;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using System.Threading.Tasks;

[RequireComponent(typeof(NavMeshAgent))]
public class CarAIMesh : MonoBehaviour
{
    public Transform splineParent;
    public float stopDistance = 3f;
    public float carSpeed = 12f;
    public float carAcceleration = 8f;
    public float turnSpeed = 5f;

    private NavMeshAgent agent;
    private List<Vector3> splinePoints = new List<Vector3>();
    private int currentPointIndex = 0;
    private bool isInitialized = false;

    void Start()
    {
        SetupNavMeshAgent();
        FindSplinePoints();
        StartNavigation();
    }

    void SetupNavMeshAgent()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent komponenta nije pronađena!");
            return;
        }

        agent.speed = carSpeed;
        agent.acceleration = carAcceleration;
        agent.angularSpeed = 120f;
        agent.stoppingDistance = stopDistance;
        agent.radius = 1.5f;
        agent.height = 2f;
        agent.baseOffset = 0f;
        agent.updateRotation = false;
    }

    void FindSplinePoints()
    {
        splinePoints.Clear();

        if (splineParent == null)
        {
            Debug.LogError("splineParent nije postavljen!");
            return;
        }

        List<Transform> foundNodes = new List<Transform>();
        string[] possibleNodeNames = { "Node", "SplineNode", "Point", "Waypoint" };

        foreach (string nodeName in possibleNodeNames)
        {
            foreach (Transform child in splineParent)
            {
                if (child.name.Contains(nodeName))
                {
                    foundNodes.Add(child);
                }
            }

            if (foundNodes.Count > 0)
                break;
        }

        if (foundNodes.Count > 0)
        {
            foundNodes.Sort((a, b) =>
            {
                int aNum = ExtractNumberFromName(a.name);
                int bNum = ExtractNumberFromName(b.name);
                return aNum.CompareTo(bNum);
            });

            foreach (Transform node in foundNodes)
            {
                splinePoints.Add(node.position);
            }
        }
        else
        {
            GenerateSplinePoints();
        }
    }

    void GenerateSplinePoints()
    {
        if (splineParent.childCount == 0)
            return;

        for (int i = 0; i < splineParent.childCount; i++)
        {
            Transform child = splineParent.GetChild(i);
            splinePoints.Add(child.position);
        }
    }

    int ExtractNumberFromName(string name)
    {
        // Izvuci broj iz naziva (npr. "Node5" -> 5)
        string numberStr = "";
        foreach (char c in name)
        {
            if (char.IsDigit(c))
            {
                numberStr += c;
            }
        }

        if (int.TryParse(numberStr, out int result))
        {
            return result;
        }
        return 0;
    }

    void StartNavigation()
    {
        if (splinePoints.Count == 0)
        {
            Debug.LogError("Nema spline točaka za navigaciju!");
            return;
        }

        isInitialized = true;
        currentPointIndex = 0;
        agent.SetDestination(splinePoints[currentPointIndex]);
    }

    void Update()
    {
        if (!isInitialized || splinePoints.Count == 0)
            return;

        UpdateNavigation();
        UpdateCarRotation();
    }

    void UpdateNavigation()
    {
        if (currentPointIndex >= splinePoints.Count)
            return;

        float distance = Vector3.Distance(transform.position, splinePoints[currentPointIndex]);

        if (distance < stopDistance || (!agent.pathPending && agent.remainingDistance < 1f))
        {
            currentPointIndex++;

            if (currentPointIndex < splinePoints.Count)
            {
                agent.SetDestination(splinePoints[currentPointIndex]);
            }
        }
    }

    void UpdateCarRotation()
    {
        if (agent.velocity.sqrMagnitude > 0.1f)
        {
            Vector3 direction = agent.velocity.normalized;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                    turnSpeed * Time.deltaTime);
            }
        }
    }

    public void RestartNavigation()
    {
        currentPointIndex = 0;
        if (splinePoints.Count > 0)
        {
            agent.SetDestination(splinePoints[currentPointIndex]);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        carSpeed = newSpeed;
        if (agent != null)
        {
            agent.speed = carSpeed;
        }
    }
}