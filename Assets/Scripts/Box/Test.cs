using System.Collections;
using System.Collections.Generic;
using Box;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            ObjectPooler.Instance.SpawnFromPool(Random.Range(0, 2));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
