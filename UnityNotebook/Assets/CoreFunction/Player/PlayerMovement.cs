using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float sensitivity;
    [SerializeField] float sprintSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] Transform playerOrientation;
    [SerializeField] Camera playerCamera;
    private float moveFB;
    private float moveLR;
    private Vector3 jumpVelocity = new Vector3(0f,0f,0f);

    private CharacterController cc;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){
        Move();
    }

    private void Move(){
        float movementSpeed = speed;

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift)){
            movementSpeed = sprintSpeed;
        } else {
            movementSpeed = speed;
        }

        //Get input
        moveFB = Input.GetAxis("Vertical") * movementSpeed;
        moveLR = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 movement = new Vector3(moveLR, 0, moveFB).normalized * movementSpeed;

        //Remove jump force after jump
        if (cc.isGrounded){
            if (jumpVelocity.y < 0 ){
                jumpVelocity.y = -2f;
            }
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded){
            jumpVelocity.y = jumpForce;
        }

        //Gravity
        if (!cc.isGrounded){
            jumpVelocity.y -= gravity * Time.deltaTime;
        }

        //Apply Movement
        movement = playerOrientation.rotation * movement;
        cc.Move((movement + jumpVelocity) * Time.deltaTime);
    }
}