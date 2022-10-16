using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    [SerializeField] private Animator animator;
    private bool in_hand;

    private void Start()
    {
        in_hand = false;
    }

    private void Update()
    {
        if(in_hand == true)
        {
            animator.Play("hold");
        }
        else
        {
            animator.Play("drop");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "arrow")
        {
            in_hand = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            in_hand = false;
        }
    }
}
