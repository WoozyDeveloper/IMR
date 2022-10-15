using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    [SerializeField] private Animator animator;

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "arrow")
        {
            animator.Play("Armature_ArmatureAction_001");
            Debug.Log("Ar trebui sa dea play la animatie");
        }
    }
}
