using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;
    public LapComplete lapCompleteScript;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        LapCompleteTrig.SetActive(true);
        HalfLapTrig.SetActive(false);

        lapCompleteScript.AllowLapCompletion();
    }
}
