using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform playerT;

    public Vector3 offset;
    public float pitch;
    private float currentZoom = 10f;

    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float zoomSpeed = 4f;

    private float currentYaw;
    public float yawSpeed = 100f;

    // Start is called before the first frame update


    private void LateUpdate()
    {
        transform.position = playerT.position - offset * currentZoom;
        transform.LookAt(playerT.position + Vector3.up * pitch);

        transform.RotateAround(playerT.position, Vector3.up, currentYaw);
    }

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }





    /*    void Update()
        {
            if (playerT != null)
            {
                Vector3 playerPos = new Vector3(playerT.transform.position.x, playerT.transform.position.y + yOffset, playerT.transform.position.z - zOffset);
                this.transform.position = playerPos;
            }
        }*/
}

