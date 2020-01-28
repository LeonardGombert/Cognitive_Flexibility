using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject objectPrefab;
    [SerializeField] int numberToSpawn;
    int onStartSpawn;

    Vector2 spawnPosition;

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
            spawnPosition = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
        }
    }
}
