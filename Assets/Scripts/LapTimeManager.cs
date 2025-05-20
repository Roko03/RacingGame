using UnityEngine;
using TMPro;

public class LapTimeManager : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    public TMP_Text MinuteBox;
    public TMP_Text SecondBox;
    public TMP_Text MilliBox;

    public static float RawTime;

    public static bool isTiming = true;

    void Start()
    {
        isTiming = true; 
    }

    void Update()
    {
        if (!isTiming) return; 

        MilliCount += Time.deltaTime * 10;
        RawTime += Time.deltaTime;
        MilliDisplay = MilliCount.ToString("F0");
        MilliBox.text = MilliDisplay;

        if (MilliCount >= 10)
        {
            MilliCount = 0;
            SecondCount += 1;
        }

        if (SecondCount <= 9)
        {
            SecondBox.text = "0" + SecondCount + ".";
        }
        else
        {
            SecondBox.text = SecondCount + ".";
        }

        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }

        if (MinuteCount <= 9)
        {
            MinuteBox.text = "0" + MinuteCount + ":";
        }
        else
        {
            MinuteBox.text = MinuteCount + ":";
        }
    }
}
