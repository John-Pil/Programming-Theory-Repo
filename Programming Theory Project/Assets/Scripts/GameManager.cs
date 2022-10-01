using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] private int preyCount, smartPreyCount, predatorCount;
    [SerializeField] private GameObject preyPrefab, smartPreyPrefab, predatorPrefab;
    public const float xBoundary = 57, zBoundary = 25;

    // Start is called before the first frame update
    void Start()
    {
        //ABSTRACTION
        CreatePrey();
        CreateSmartPrey();
        CreatePredators();
    }

    private void CreatePrey() 
    {
        for (int i = 0; i < preyCount; i++)
        {
            Instantiate(preyPrefab, getRandomSpawn(), preyPrefab.transform.rotation);
        }
    }

    private void CreateSmartPrey()
    {
        for (int i = 0; i < smartPreyCount; i++)
        {
            Instantiate(smartPreyPrefab, getRandomSpawn(), smartPreyPrefab.transform.rotation);
        }
    }

    private void CreatePredators()
    {
        for (int i = 0; i < predatorCount; i++)
        {
            Instantiate(predatorPrefab, getRandomSpawn(), predatorPrefab.transform.rotation);
        }
    }

    // ABSTRACTION
    private Vector3 getRandomSpawn() 
    {
        return new Vector3(Random.Range(-xBoundary, xBoundary), 1.5f, Random.Range(-zBoundary, zBoundary));
    }
}
