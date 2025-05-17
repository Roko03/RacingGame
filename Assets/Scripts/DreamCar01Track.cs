using System.Collections;
using UnityEngine;

public class DreamCar01Track : MonoBehaviour
{
    public GameObject TheMarker;
    public GameObject Mark01;
    public GameObject Mark02;
    public GameObject Mark03;
    public GameObject Mark04;
    public GameObject Mark05;
    public GameObject Mark06;
    public int MarkTracker;

    private void Update()
    {
        switch (MarkTracker)
        {
            case 0: TheMarker.transform.position = Mark01.transform.position; break;
            case 1: TheMarker.transform.position = Mark02.transform.position; break;
            case 2: TheMarker.transform.position = Mark03.transform.position; break;
            case 3: TheMarker.transform.position = Mark04.transform.position; break;
            case 4: TheMarker.transform.position = Mark05.transform.position; break;
            case 5: TheMarker.transform.position = Mark06.transform.position; break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarAITag"))
        {
            StartCoroutine(AdvanceMarker());
        }
    }

    private IEnumerator AdvanceMarker()
    {
        GetComponent<BoxCollider>().enabled = false;
        MarkTracker++;
        if (MarkTracker > 5)
            MarkTracker = 0;

        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider>().enabled = true;
    }
}
