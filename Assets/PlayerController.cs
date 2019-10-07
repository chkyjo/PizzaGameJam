using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    Rigidbody rb;

    //---------state values
    bool canMove = true;

    Vector3 moveDirection;
    Vector3 moveVelocity;
    public float speed = 3.0f;
    float jumpForce = 3.0f;

    public Camera mainCamera;
    public Vector3 cameraOffset;

    Animator animator;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        cameraOffset = new Vector3(3, 10, -15);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate(){

        if (canMove) {
            float xMov = Input.GetAxisRaw("Horizontal");
            float yMov = Input.GetAxisRaw("Jump");

            Vector3 movement = new Vector3(xMov, yMov, 0);

            if (movement != Vector3.zero) {
                animator.SetFloat("Speed", 0.5f);
            }
            else {
                animator.SetFloat("Speed", 0f);
            }

            moveDirection = movement.normalized;
            moveDirection.y *= jumpForce;
            moveVelocity = moveDirection * speed;

            rb.MovePosition(transform.position + moveVelocity * Time.deltaTime);

            mainCamera.transform.position = transform.position + cameraOffset;
            if (mainCamera.transform.position.y < 105) {
                Vector3 cameraPosition = mainCamera.transform.position;
                cameraPosition.y = 105;
                mainCamera.transform.position = cameraPosition;
            }
        }
        
        //mainCamera.transform.LookAt(transform);
    }

    public void Die() {
        Debug.Log("You died");
        canMove = false;
    }
}
