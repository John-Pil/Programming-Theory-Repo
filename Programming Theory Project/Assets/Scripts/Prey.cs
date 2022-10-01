using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : Animal // INHERITANCE
{
    [SerializeField]private GameObject fleeingFrom;

    // POLYMORPHISM
    protected override void MoveForward(Vector3 direction)
    {
        if (fleeingFrom != null)
        {
            if (standardRoutine != null)
            {
                StopCoroutine(standardRoutine);
                standardRoutine = null;
            }
            transform.LookAt(fleeingFrom.transform.position);
            transform.Translate(Vector3.back * speed * Time.deltaTime);

            if (Mathf.Abs(transform.position.x + direction.x) > 57 || Mathf.Abs(transform.position.z + direction.z) > 25)
            {
                GameManager.UpdateEscapedPrey();
                Destroy(gameObject);
            }
        }
        else
        {
            base.MoveForward(direction);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Predator")) 
        {
            fleeingFrom = other.gameObject;
        }
    }
}
