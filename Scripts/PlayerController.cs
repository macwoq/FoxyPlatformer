using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float bounceForce = 8f;
    public float moveSpeed = 10;
    public float jumpForce = 5;
    public float gravityScale = 5f;
    public CharacterController charControl;
    public Camera theCam;
    private Vector3 moveDirection;
    public Animator anim;

    public GameObject playerModel;
    public float rotateSpeed;

    public bool isGrounded;

    public bool isKnocking;
    public float knockBackLenght = 0.5f;
    public float knockBackCounter = 0.5f;
    public Vector2 knockBackPower;

    public GameObject[] playerPieces;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        anim.SetBool("Grounded", charControl.isGrounded);
        Movement();
    }

    private void Movement()
    {
        if (!isKnocking)
        {
            float yStore = moveDirection.y;
            //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + 
                (transform.right * Input.GetAxisRaw("Horizontal"));
            moveDirection.Normalize();
            moveDirection = moveDirection * moveSpeed;
            moveDirection.y = yStore;

            if (charControl.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
            //transform.position = transform.position + (moveDirection * Time.deltaTime);

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charControl.Move(moveDirection * Time.deltaTime);


            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                transform.rotation = Quaternion.Euler(0f, theCam.transform.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
                playerModel.transform.rotation = newRotation;
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
            }
        }

        if (isKnocking)
        {
            knockBackCounter -= Time.deltaTime;

            float yStore = moveDirection.y;
            moveDirection = playerModel.transform.forward * -knockBackPower.x;

            charControl.Move(moveDirection * Time.deltaTime);

            moveDirection.y = yStore;

            if (knockBackCounter<= 0)
            {
                isKnocking = false;
            }
        }
    }

    public void KnockBack()
    {
        isKnocking = true;
        knockBackCounter = knockBackLenght;
        Debug.Log("Knock");
    }

    public void Bounce()
    {
        moveDirection.y = bounceForce;
        charControl.Move(moveDirection * Time.deltaTime);
    }
}
