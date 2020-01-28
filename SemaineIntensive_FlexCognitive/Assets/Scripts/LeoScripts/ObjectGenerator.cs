using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject objectPrefab;
    [SerializeField] int numberToSpawn;
    int onStartSpawn;

    void Start()
    {
        SpawnObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObjects()
    {
        for (onStartSpawn = 0; onStartSpawn < numberToSpawn; onStartSpawn++)
        {
            Instantiate(objectPrefab, gameObject.transform);
        }
    }
}
