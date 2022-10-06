using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("intru??");
        if (collision.gameObject.tag == "cactus")
        {
            this.transform.LookAt(collision.gameObject.transform);
            this.GetComponentInParent<Animator>().Play("Attack");
            Debug.Log("Ne batem sau nu???");
        }
    }
}
