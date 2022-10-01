using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION    
    [SerializeField] private int preyCount, smartPreyCount, predatorCount;
    [SerializeField] private GameObject preyPrefab, smartPreyPrefab, predatorPrefab;

    public const float xBoundary = 57, zBoundary = 25;

    private static Text caughtText, escapedText;
    private static int caughtPrey, escapedPrey;

    // Start is called before the first frame update
    void Start()
    {
        caughtPrey = 0;
        escapedPrey = 0;
        caughtText = GameObject.Find("CaughtText").GetComponent<Text>();
        escapedText = GameObject.Find("EscapedText").GetComponent<Text>();

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

    public static void UpdateCaughtPrey() 
    {
        caughtPrey++;
        caughtText.text = "Caught Prey: " + caughtPrey;
    }

    public static void UpdateEscapedPrey() 
    {
        escapedPrey++;
        escapedText.text = "Escaped Prey: " + escapedPrey;
    }
}
