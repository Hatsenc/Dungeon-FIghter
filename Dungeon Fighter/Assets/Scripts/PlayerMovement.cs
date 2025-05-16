using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 6f;
    private bool sprinting = false;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && sprinting == false)
        {
            sprinting = true;
            speed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && sprinting == true)
        {
            sprinting = false;
            speed /= 2;
        }
    }
}
