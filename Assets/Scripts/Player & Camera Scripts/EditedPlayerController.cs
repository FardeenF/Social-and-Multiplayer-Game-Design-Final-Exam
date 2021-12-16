using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EditedPlayerController : MonoBehaviour
{
    public float speed;
    VariableJoystick variableJoystick;
    public Rigidbody rb;
    public float jumpForce = 100.0f;
    public PhotonView view;


    Transform cameraTransform;
    VariableJoystick rotationJoystick;
    public float camSpeed = 3.0f;
    public Transform playerPosition;

    private void Start()
    {
        Application.targetFrameRate = 60;

        cameraTransform = GetComponentInChildren<Camera>().transform;

        if(!view.IsMine)
        {
            GetComponentInChildren<Camera>().enabled = false;
        }

        VariableJoystick[] joys = GetComponentsInChildren<VariableJoystick>();
        foreach (VariableJoystick joy in joys)
        {
            if (joy.name == "Camera Joystick")
                rotationJoystick = joy;
            else if (joy.name == "Movement Joystick")
                variableJoystick = joy;
        }
    }

    public void FixedUpdate()
    {
        //if (view.IsMine)
        //{
            Vector3 direction = cameraTransform.forward * variableJoystick.Vertical + cameraTransform.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

            cameraTransform.LookAt(playerPosition.position);
            float xRot = speed * -rotationJoystick.Vertical;
            float yRot = speed * rotationJoystick.Horizontal;

            cameraTransform.Rotate(xRot, yRot, 0.0f);
            transform.position = playerPosition.position;
        //}
    }

    public void setData()
    {
        VariableJoystick[] joys = GetComponentsInChildren<VariableJoystick>();
        foreach (VariableJoystick joy in joys)
        {
            if (joy.name == "Camera Joystick")
                rotationJoystick = joy;
            else if (joy.name == "Movement Joystick")
                variableJoystick = joy;
        }
    }

    public void Jump()
    {
        if (view.IsMine)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}
