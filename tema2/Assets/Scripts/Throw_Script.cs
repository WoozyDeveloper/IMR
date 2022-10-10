using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem; 

public class Throw_Script : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
