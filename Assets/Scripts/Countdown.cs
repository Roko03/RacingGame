using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI CountDown;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public GameObject CarControls;
    public MonoBehaviour AIControlScript;
    public AudioSource LevelMusic;


    void Start()
    {
        CarControls.SetActive(false);
        AIControlScript.enabled = false;
        StartCoroutine(CountStart());
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
        CarControls.SetActive(true);
        AIControlScript.enabled = true;
    }
}