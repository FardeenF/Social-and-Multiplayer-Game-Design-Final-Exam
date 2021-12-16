using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditedCamera : MonoBehaviour
{
    public new Camera camera;
    VariableJoystick rotationJoystick;
    public float speed = 3.0f;
    public Transform playerPosition;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camera.transform.LookAt(transform);
        float xRot = speed * -rotationJoystick.Vertical;
        float yRot = speed * rotationJoystick.Horizontal;

        transform.Rotate(xRot, yRot, 0.0f);
        transform.position = playerPosition.position;
    }

    public void SetData(GameObject cameraParent)
    {
        VariableJoystick[] joys = cameraParent.GetComponentsInChildren<VariableJoystick>();
        foreach (VariableJoystick joy in joys)
        {
            if (joy.name == "Camera Joystick")
                rotationJoystick = joy;
        }
    }
}
