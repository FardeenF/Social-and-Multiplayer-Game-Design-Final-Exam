using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    new Transform camera;
    public float speed;
    FixedJoystick fixedJoystick;
    public Rigidbody rb;
    public float jumpForce = 100.0f;
    public PhotonView view;
    bool dataSet = false;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void FixedUpdate()
    {
        if (dataSet)
        {
            Vector3 direction = camera.forward * fixedJoystick.Vertical + camera.right * fixedJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

            Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, camera.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }

    public void Jump()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    public void SetData(GameObject cameraParent)
    {
        FixedJoystick[] joys = cameraParent.GetComponentsInChildren<FixedJoystick>();
        foreach (FixedJoystick joy in joys)
        {
            if (joy.name == "Movement Joystick")
                fixedJoystick = joy;
        }
        camera = cameraParent.transform.GetComponentInChildren<Camera>().gameObject.transform;
        dataSet = true;
    }
}
