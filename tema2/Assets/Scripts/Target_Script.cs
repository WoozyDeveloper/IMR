using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Script : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public bool targetHit;
    public bool inAir;
    public float score;

    private Vector3 startingPos, finalPos;
    // Start is called before the first frame update
    void Start()
    {
        targetHit = false;
        inAir = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(inAir)
        {
            if(score == 0)
            {
                startingPos = transform.position;
                score = 1;
                Debug.Log("Initial position remembered");
            }
        }
        if(targetHit)
        {
            score = (int)Mathf.Abs(target.transform.position.z - startingPos.z) * 10;
            Debug.Log("SCORE = " + score);
            targetHit = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "target")
        {
            Debug.Log("TAGERGET HIT");
            score = 0;
            targetHit = true;
            inAir = false;
        }
        else if(collision.gameObject.tag == "hand")
        {
            Debug.Log("Holding the object");
            score = 0;
            targetHit = false;
            inAir = false;
        }
        else if(collision.gameObject.tag == "Floor")
        {
            Debug.Log("On the floor");
            score = 0;
            targetHit = false;
            inAir = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            Debug.Log("IN THE AIR!!!");
            score = 0;
            targetHit = false;
            inAir = true;

            Rigidbody rb = GetComponent<Rigidbody>();
            Debug.Log("ADDING FORCE");
            rb.AddForce(transform.forward * 10, ForceMode.Impulse);
        }
    }
}
