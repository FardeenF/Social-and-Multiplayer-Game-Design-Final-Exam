using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraLook : MonoBehaviour
{
    public new Camera camera;
    public CinemachineFreeLook cam;
    FixedJoystick rotationJoystick;
    public float xSpeed = 0.01f;
    public float ySpeed = 1.0f;
    public GameObject player;
    bool dataSet = false;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }


    void FixedUpdate()
    {
        if (dataSet)
        {
            float xRot = xSpeed * -rotationJoystick.Vertical;
            float yRot = ySpeed * rotationJoystick.Horizontal;

            cam.m_XAxis.Value += yRot;
            cam.m_YAxis.Value += xRot;
        }
    }

    public void SetData(GameObject cameraParent)
    {
        FixedJoystick[] joys = cameraParent.GetComponentsInChildren<FixedJoystick>();
        foreach (FixedJoystick joy in joys)
        {
            if (joy.name == "Camera Joystick")
                rotationJoystick = joy;
        }

        dataSet = true;
    }

    public void SetCameraPosition(GameObject playerPrefab)
    {
        player = playerPrefab;
        cam.Follow = player.transform;
        cam.LookAt = player.transform;
    }
}
