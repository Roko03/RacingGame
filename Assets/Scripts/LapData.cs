using System;

[Serializable]
public class LapData
{
    public float BestRawTime = float.MaxValue;
    public int BestMinutes;
    public int BestSeconds;
    public float BestMilliseconds;
}