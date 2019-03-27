using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private float moveForward;
    private float moveSideways;
    private Camera cam;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveForward = Input.GetAxis("Vertical");
        moveSideways = Input.GetAxis("Horizontal");

        moveForward = moveForward * movementSpeed * Time.deltaTime;
        moveSideways = moveSideways * movementSpeed * Time.deltaTime;

        if(moveForward >= 0.1f || moveSideways >= 0.1f || moveForward <= -0.1f || moveSideways <= -0.1f){
            cam.GetComponent<Animator>().SetBool("isWalking", true);
        } else {
            cam.GetComponent<Animator>().SetBool("isWalking", false);
        }
    }

    void FixedUpdate(){
        rb.AddForce(transform.forward * moveForward);
        rb.AddForce(transform.right * moveSideways);
    }
}
