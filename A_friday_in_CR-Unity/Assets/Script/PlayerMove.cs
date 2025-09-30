using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{

    public float Speed = 4;
    public float rotationSpeed = 10f;

    private Vector3 forward, rigth;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        rigth = Camera.main.transform.right;
        rigth.y = 0;
        rigth = Vector3.Normalize(rigth);

    }

    void FixedUpdate()
    {
        float horizontalInput = -Input.GetAxis("Horizontal");
        float verticalInput = -Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        if (direction.magnitude > 0.1f)
        {
            rb.MovePosition(transform.position += direction * Speed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

    }
}