using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCam : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    Camera thisCam;


    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        thisCam = this.GetComponent<Camera>();

    }

    void Update(){
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate!
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        //Zoom with Z key
        if (Input.GetKey("z") && thisCam.fieldOfView >= 20f){
            thisCam.fieldOfView -= 180f * Time.deltaTime;
        } else if (!Input.GetKey("z") && this.thisCam.fieldOfView < 60f){
            thisCam.fieldOfView += 180f * Time.deltaTime;
        }
    }   
}
