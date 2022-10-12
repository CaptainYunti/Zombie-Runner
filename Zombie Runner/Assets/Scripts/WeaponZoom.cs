using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 60;
    [SerializeField] float zoomedInFOV = 20;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;


    bool zoomedInToogle = false;

    private void OnDisable()
    {
        ZoomOut();
    }


    private void Update()
    {
      if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToogle == false)
            {
                ZoomIn();
            }

            else
            {
                ZoomOut();

            }
        }
    }

    private void ZoomOut()
    {
        zoomedInToogle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void ZoomIn()
    {
        zoomedInToogle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }
}
