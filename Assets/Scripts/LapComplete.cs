using UnityEngine;
using TMPro;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public TMP_Text MinuteDisplay;
    public TMP_Text SecondDisplay;
    public TMP_Text MilliDisplay;
    public TMP_Text LapCounter;

    public GameObject CarControls;
    public MonoBehaviour AIControlScript;

    private int lapsDone = 0;
    private bool canLap = false;

    private const int MaxLaps = 3;
    private const string RawTimeKey = "RawTime";
    private const string MinKey = "MinSave";
    private const string SecKey = "SecSave";
    private const string MilKey = "MiliSave";

    private bool firstLapDone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!canLap || !other.CompareTag("Player")) return;

        lapsDone++;
        LapCounter.text = lapsDone.ToString();

        float currentRaw = LapTimeManager.RawTime;
        int currentMin = LapTimeManager.MinuteCount;
        int currentSec = LapTimeManager.SecondCount;
        float currentMil = LapTimeManager.MilliCount;

        float bestRawTime = PlayerPrefs.GetFloat(RawTimeKey, float.MaxValue);

        if (!firstLapDone)
        {
            SaveBestLap(currentRaw, currentMin, currentSec, currentMil);
            UpdateBestLapUI(currentMin, currentSec, currentMil);
            firstLapDone = true;
        }
        else if (currentRaw < bestRawTime)
        {
            SaveBestLap(currentRaw, currentMin, currentSec, currentMil);
            UpdateBestLapUI(currentMin, currentSec, currentMil);
        }

        ResetLapTimer();

        if (lapsDone >= MaxLaps)
        {
            EndRace();
            return;
        }

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
        canLap = false;
    }
    public void AllowLapCompletion()
    {
        canLap = true;
    }

    private void SaveBestLap(float raw, int min, int sec, float mil)
    {
        PlayerPrefs.SetFloat(RawTimeKey, raw);
        PlayerPrefs.SetInt(MinKey, min);
        PlayerPrefs.SetInt(SecKey, sec);
        PlayerPrefs.SetFloat(MilKey, mil);
        PlayerPrefs.Save();
    }

    private void UpdateBestLapUI(int min, int sec, float mil)
    {
        MinuteDisplay.text = min.ToString("00") + ":";
        SecondDisplay.text = sec.ToString("00") + ".";
        MilliDisplay.text = mil.ToString("0");
    }

    private void ResetLapTimer()
    {
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MilliCount = 0f;
        LapTimeManager.RawTime = 0f;
    }

    private void EndRace()
    {
        LapCompleteTrig.SetActive(false);
        HalfLapTrig.SetActive(false);

        LapTimeManager.isTiming = false;
        CarControls.SetActive(false);
        AIControlScript.enabled = false;

        Debug.Log("Race Finished!");
    }
}
