using UnityEngine;
using TMPro;
public class LoadLapTime : MonoBehaviour
{
    public int MinCount;
    public int SecCount;
    public int MiliCount;

    public TextMeshProUGUI MinDisplay;
    public TextMeshProUGUI SecDisplay;
    public TextMeshProUGUI MiliDisplay;

    void Start()
    {
        MinCount = PlayerPrefs.GetInt("MinSave");
        SecCount = PlayerPrefs.GetInt("SecSave");
        MiliCount = PlayerPrefs.GetInt("MiliSave");

        MinDisplay.text = MinCount.ToString("00");
        SecDisplay.text = SecCount.ToString("00");
        MiliDisplay.text = MiliCount.ToString("00");
    }
}
