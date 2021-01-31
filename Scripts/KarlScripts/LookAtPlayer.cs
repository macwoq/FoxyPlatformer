using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    public Transform terget;
    public Vector3 offset;

    public Camera theCam;

    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(terget != null)
        {
            transform.position = terget.position + offset;

            transform.LookAt(terget);
        }
    }
}
