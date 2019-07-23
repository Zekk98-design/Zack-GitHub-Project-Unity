using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject TargetWarrior;
    [SerializeField] private GameObject TargetRogue;
    [SerializeField] private GameObject TargetMage;
   
    [SerializeField] private float mSpeed= 5f; // enemy speed
    [SerializeField] private Rigidbody rb;

    private float curDistance = 1000f;


    // Start is called before the first frame update
    void Start()
    {   //find characters with matched tag
        TargetWarrior = GameObject.FindGameObjectWithTag("Warrior");
        TargetRogue = GameObject.FindGameObjectWithTag("Rogue");
        TargetMage = GameObject.FindGameObjectWithTag("Mage");

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance1= Mathf.Infinity;
        float distance2 = Mathf.Infinity;
        float distance3 = Mathf.Infinity;

        if (TargetWarrior != null)
        {
            distance1 = Vector3.Distance(transform.position, TargetWarrior.transform.position); // get distance between Enemy and Character
        }

        if (TargetRogue != null)
        {
            distance2 = Vector3.Distance(transform.position, TargetRogue.transform.position);
        }

        if (TargetMage != null)
        {
            distance3 = Vector3.Distance(transform.position, TargetMage.transform.position);
        }


        //find if it is closest to Warrior
        if (distance1 < distance2 && distance1 < distance3) 
        {
            curDistance = distance1;
            transform.LookAt(TargetWarrior.transform);

            //transform.Translate(Vector3.forward * mSpeed * Time.deltaTime);
            //rb.AddForce(transform.forward * mSpeed * Time.deltaTime *100);
            if (distance1 > 2f )
            {
                rb.AddForce(transform.forward * mSpeed * Time.deltaTime * 100);
            }
            // when close...
            else
            {
                // ...attack
            }

        }
        //find if it is closest to Rogue
        if (distance2 < distance1 && distance2 < distance3)
        {
            curDistance = distance2;

            transform.LookAt(TargetRogue.transform);
            
            if (distance1 > 3f)
            {
                rb.velocity = transform.forward * mSpeed * Time.deltaTime * 100;

            }
            // when close...
            else
            {
                // ...attack
            }

        }

        //find if it is closest to Mage
        if (distance2 < distance1 && distance2 < distance3)
        {
            curDistance = distance2;

            transform.LookAt(TargetMage.transform);

            if (distance1 > 3f)
            {
                rb.velocity = transform.forward * mSpeed * Time.deltaTime * 100;

            }
            // when close...
            else
            {
                // ...attack
            }
        }
    }

}