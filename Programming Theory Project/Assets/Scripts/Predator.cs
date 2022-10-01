using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Predator : Animal // INHERITANCE
{
    [SerializeField]private GameObject target;

    // POLYMORPHISM
    protected override void MoveForward(Vector3 direction)
    {
        if (target != null)
        {
            if (standardRoutine != null) 
            {
                StopCoroutine(standardRoutine);
                standardRoutine = null;
            }

            transform.LookAt(target.transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else 
        {
            if (standardRoutine == null) 
            {
                standardRoutine = StartCoroutine(WalkForRandomTime());
            }
            base.MoveForward(direction);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (target == null && other.CompareTag("Prey")) 
        {
            target = other.gameObject;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Prey")) 
        {
            Destroy(collision.gameObject);
        }
    }
}
