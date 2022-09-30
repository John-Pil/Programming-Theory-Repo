using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {        
        RandomRotate();
        StartCoroutine(WalkForRandomTime());
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator WalkForRandomTime() 
    {
        yield return new WaitForSeconds(Random.Range(3f, 10f));
        RandomRotate();
        StartCoroutine(WalkForRandomTime());
    }    

    protected virtual void MoveForward(Vector3 direction) 
    {
        if (Mathf.Abs(transform.position.x + direction.x) > 57 || Mathf.Abs(transform.position.z + direction.z) > 25)
        {
            transform.Translate(-direction);
            RandomRotate();
        }
        else
        {
            transform.Translate(direction);
        }
    }

    protected void RandomRotate()
    {
        transform.Rotate(0, Random.Range(0f, 361f), 0);
    }
}