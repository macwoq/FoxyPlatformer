using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingKarl : MonoBehaviour
{
    Quaternion targetRotation;
    public Camera theCam;
    public float rotationSpeed = 10f, walkSpeed = 5f;
    public CharacterController charControl;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveType(); 
    }

    private void MoveType()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        input = theCam.transform.TransformDirection(input);
        input.y = 0.0f;
        if (input != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(input);
            transform.eulerAngles = transform.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,
                targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
            input = input.normalized;
            input *= walkSpeed;
            input += transform.up * -8;
            charControl.Move(input * Time.deltaTime);
            anim.SetFloat("Run", 1f);
        }
        else
        {
            anim.SetFloat("Run", 0f);
        }
    }
}
