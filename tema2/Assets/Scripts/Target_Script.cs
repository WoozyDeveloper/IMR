using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target_Script : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private TextMeshProUGUI scoreText;

    public bool targetHit;
    public bool inAir;
    public float score;
    private int totalScore;

    private Vector3 startingPos, finalPos;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Stop();

        targetHit = false;
        inAir = false;
        score = 0;
        totalScore = 0;

        scoreText = FindObjectOfType<TextMeshProUGUI>();
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
            Debug.Log("Should add " + score);
            totalScore += int.Parse(scoreText.text) + (int)score;
            scoreText.text = totalScore.ToString();
            score = 0;


            targetHit = false;

            gameObject.GetComponent<ParticleSystem>().Play();
            GetComponent<Rigidbody>().isKinematic = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "center_target")
        {
            Debug.Log("Center target HIT!!!");
            score = 100;
            totalScore = int.Parse(scoreText.text) + (int)score;
            scoreText.text = totalScore.ToString();
            Debug.Log("SCORE = " + score);
            score = 0;
            targetHit = true;
            inAir = false;
        }
        if (collision.gameObject.tag == "target")
        {
            Debug.Log("TAGERGET HIT SIMPLE SCORE ADDED");
            
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
