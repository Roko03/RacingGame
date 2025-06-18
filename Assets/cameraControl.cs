using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitch : MonoBehaviour
{
   
    public Unity.Cinemachine.CinemachineCamera thirdPersonCam;
    public Unity.Cinemachine.CinemachineCamera hoodCam;

    private void Start()
    {
        SetThirdPersonView();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (thirdPersonCam.Priority > hoodCam.Priority)
            {
                SetHoodView();
            }
            else
            {
                SetThirdPersonView();
            }
        }
    }

    private void SetThirdPersonView()
    {
        thirdPersonCam.Priority = 10;
        hoodCam.Priority = 5;
    }

    private void SetHoodView()
    {
        thirdPersonCam.Priority = 5;
        hoodCam.Priority = 10;
    }
}
