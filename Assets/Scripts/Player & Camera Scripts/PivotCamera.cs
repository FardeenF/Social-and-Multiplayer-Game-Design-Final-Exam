using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotCamera : MonoBehaviour
{
    public new Camera camera;
    FixedJoystick rotationJoystick;
    public float speed = 3.0f;
    public GameObject player;
    bool dataSet = false;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dataSet)
        {
            camera.transform.LookAt(transform);
            float xRot = speed * -rotationJoystick.Vertical;
            float yRot = speed * rotationJoystick.Horizontal;

            transform.Rotate(xRot, yRot, 0.0f);
            transform.position = player.transform.position;
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
    }
}
