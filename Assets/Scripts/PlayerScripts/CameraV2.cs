using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraV2 : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineCamera;
    private int rotationSpeed = 100;
    private float FOV;
    private float targetFOV;
    private float zoomSpeed = 5;

    private void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        FOV = cinemachineCamera.m_Lens.OrthographicSize;
        targetFOV = FOV;

    }

    private void Update()
    {
        RotateCamera();
        ZoomCamera();
    }

    private void RotateCamera()
    {
        Vector3 rotation = this.transform.eulerAngles;
        rotation.y += Input.GetAxisRaw("Horizontal") * Time.deltaTime * rotationSpeed;
        this.transform.eulerAngles = rotation;
    }

    private void ZoomCamera()
    {
        float scroll = Input.mouseScrollDelta.y * 2;

        targetFOV -= scroll;
        float minFOV = 60f;
        float maxFOV = 90f;
        targetFOV = Mathf.Clamp(targetFOV, minFOV, maxFOV);
        FOV = Mathf.Lerp(targetFOV, FOV, zoomSpeed * Time.deltaTime);

        cinemachineCamera.m_Lens.FieldOfView = FOV;




    }
}
