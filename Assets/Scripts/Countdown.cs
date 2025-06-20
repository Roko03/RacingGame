using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [Header("UI & Audio")]
    public TextMeshProUGUI CountDown;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public AudioSource LevelMusic;

    [Header("Cars & AI")]
    public MonoBehaviour[] carControllers; 
    public CarAIMesh[] aiCarScripts; 
    public UnityEngine.AI.NavMeshAgent[] aiNavMeshAgents;

    void Start()
    {
        LapTimer.SetActive(false);
        DisableCarsAndAI();
        StartCoroutine(CountStart());
    }

    void DisableCarsAndAI()
    {
        foreach (MonoBehaviour carController in carControllers)
        {
            if (carController != null)
                carController.enabled = false;
        }

        foreach (CarAIMesh aiScript in aiCarScripts)
        {
            if (aiScript != null)
                aiScript.enabled = false;
        }

        foreach (UnityEngine.AI.NavMeshAgent agent in aiNavMeshAgents)
        {
            if (agent != null)
                agent.isStopped = true;
        }
    }

    void EnableCarsAndAI()
    {
        foreach (MonoBehaviour carController in carControllers)
        {
            if (carController != null)
                carController.enabled = true;
        }

        foreach (CarAIMesh aiScript in aiCarScripts)
        {
            if (aiScript != null)
                aiScript.enabled = true;
        }

        foreach (UnityEngine.AI.NavMeshAgent agent in aiNavMeshAgents)
        {
            if (agent != null)
                agent.isStopped = false;
        }
    }

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        CountDown.text = "3";
        GetReady.Play();
        CountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);
        CountDown.text = "2";
        GetReady.Play();
        CountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);
        CountDown.text = "1";
        GetReady.Play();
        CountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);
        GoAudio.Play();
        LevelMusic.Play();
        LapTimer.SetActive(true);

        EnableCarsAndAI();
    }
}