using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPatchHandler : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        CheckforEncounters();
    }

    public void CheckforEncounters()
    {
        if (Random.Range(1, 101) <= 10)
        {
            Debug.Log("Encounterned Wild Pokemon");
        }
    }
}
