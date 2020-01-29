using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject objectPrefab;
    [SerializeField] Transform whereToSpawn;
    [SerializeField] int numberToSpawn;
    int onStartSpawn;
    Object objectClass;

    Vector2 spawnPosition;

    void Start()
    {
        SpawnObjects();
        objectClass = objectPrefab.GetComponent<Object>();
    }

    // Update is called once per frame
    void SentenceMessageReceiver(string sentence)
    {
        Debug.Log("OBJECT GENERATOR : " + sentence);

        switch (sentence)
        {
            case string a when a.Contains("Trier"): print("yeet");
                break;
            case string a when a.Contains("Laisser"): print("nwep");
                break;
        }
    }

    private void SpawnObjects()
    {
        for (onStartSpawn = 0; onStartSpawn < numberToSpawn; onStartSpawn++)
        {
            spawnPosition = (Vector2)whereToSpawn.position + Random.insideUnitCircle * 5;//new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            GameObject objectToSpawn = Instantiate(objectPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
        }
    }
}
