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
    public GameObject Mark07;
    public GameObject Mark08;
    public GameObject Mark09;
    public GameObject Mark10;
    public GameObject Mark11;
    public GameObject Mark12;
    public GameObject Mark13;
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
            case 6: TheMarker.transform.position = Mark07.transform.position; break;
            case 7: TheMarker.transform.position = Mark08.transform.position; break;
            case 8: TheMarker.transform.position = Mark09.transform.position; break;
            case 9: TheMarker.transform.position = Mark10.transform.position; break;
            case 10: TheMarker.transform.position = Mark11.transform.position; break;
            case 11: TheMarker.transform.position = Mark12.transform.position; break;
            case 12: TheMarker.transform.position = Mark13.transform.position; break;
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
        if (MarkTracker > 13)
            MarkTracker = 0;

        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider>().enabled = true;
    }
}
