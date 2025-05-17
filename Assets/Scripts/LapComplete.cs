using UnityEngine;
using TMPro;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public TMP_Text MinuteDisplay;
    public TMP_Text SecondDisplay;
    public TMP_Text MilliDisplay;

    public GameObject LapTimeBox;

    void OnTriggerEnter()
    {
        MinuteDisplay.text = LapTimeManager.MinuteCount.ToString("00") + ".";
        SecondDisplay.text = LapTimeManager.SecondCount.ToString("00") + ".";
        MilliDisplay.text = LapTimeManager.MilliCount.ToString("0");

        PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
        PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
        PlayerPrefs.SetFloat("MiliSave", LapTimeManager.MilliCount);

        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MilliCount = 0;

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
    }
}