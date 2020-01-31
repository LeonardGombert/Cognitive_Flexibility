using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class ObjectGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject objectPrefab;
    [SerializeField] Transform whereToSpawn;
    [SerializeField] int numberOfTargetToSpawns;
    [SerializeField] int numberOfAvoidToSpawn;
    [SerializeField] int numberOfDestroyToSpawn;
    [SerializeField] int numberOfRandomsToSpawn;
    int onStartSpawnTarget;
    int onStartSpawnAvoid;
    int onStartSpawnDestroy;
    int onStartSpawnRandoms;
    Object objectClass;

    float randomSpawnTimer;
    [SerializeField] float timeToSpawn;

    Vector2 spawnPosition;
    
    string targetType;
    string targetColor;

    string losingType;
    string losingColor;

    string destroyType;
    string destroyColor;

    [ShowInInspector] Dictionary<string, string> targetObjectParameters = new Dictionary<string, string>();
    [ShowInInspector] Dictionary<string, string> avoidObjectParameters = new Dictionary<string, string>();
    [ShowInInspector] Dictionary<string, string> destroyObjectParameters = new Dictionary<string, string>();


    [ShowInInspector] List<GameObject> currentSpawnedWave = new List<GameObject>();

    void Start()
    {
        objectClass = objectPrefab.GetComponent<Object>();
    }
    
    // Update is called once per frame
    void SentenceMessageReceiver(string sentence)
    {
        foreach (GameObject item in currentSpawnedWave)
        {
            Destroy(item);
        }
        currentSpawnedWave.Clear();

        //ACTION
        if (sentence.Contains("Package"))
        {
            switch (sentence)
            {
                case string a when a.Contains("Squares"): //byShape
                    targetType = "Square";
                    break;
                case string a when a.Contains("Circles"): //byShape
                    targetType = "Circle";
                    break;
                case string a when a.Contains("Numbers"): //byNumber
                    targetType = "Number";
                    break;
                case string a when a.Contains("Letters"): //byLetter
                    targetType = "Letter";
                    break;
            }

            switch (sentence)
            {
                case string a when a.Contains("Red"): //byShape
                    targetColor = "Red";
                    break;
                case string a when a.Contains("Green"): //byShape
                    targetColor = "Green";
                    break;
                case string a when a.Contains("Blue"): //byNumber
                    targetColor = "Blue";
                    break;
            }
        }

        else if (sentence.Contains("Leave"))
        {
            switch (sentence)
            {
                case string a when a.Contains("Squares"): //byShape
                    losingType = "Square";
                    break;
                case string a when a.Contains("Circles"): //byShape
                    losingType = "Circle";
                    break;
                case string a when a.Contains("Numbers"): //byNumber
                    losingType = "Number";
                    break;
                case string a when a.Contains("Letters"): //byLetter
                    losingType = "Letter";
                    break;
            }

            switch (sentence)
            {
                case string a when a.Contains("Red"): //byShape
                    losingColor = "Red";
                    break;
                case string a when a.Contains("Green"): //byShape
                    losingColor = "Green";
                    break;
                case string a when a.Contains("Blue"): //byNumber
                    losingColor = "Blue";
                    break;
            }
        }

        else if (sentence.Contains("Destroy"))
        {
            switch (sentence)
            {
                case string a when a.Contains("Squares"): //byShape
                    destroyType = "Square";
                    break;
                case string a when a.Contains("Circles"): //byShape
                    destroyType = "Circle";
                    break;
                case string a when a.Contains("Numbers"): //byNumber
                    destroyType = "Number";
                    break;
                case string a when a.Contains("Letters"): //byLetter
                    destroyType = "Letter";
                    break;
            }

            switch (sentence)
            {
                case string a when a.Contains("Red"): //byShape
                    destroyColor = "Red";
                    break;
                case string a when a.Contains("Green"): //byShape
                    destroyColor = "Green";
                    break;
                case string a when a.Contains("Blue"): //byNumber
                    destroyColor = "Blue";
                    break;
            }
            AssignValues();
        }
    }

    private void AssignValues()
    {
        targetObjectParameters.Clear();
        avoidObjectParameters.Clear();
        destroyObjectParameters.Clear();

        switch (targetType)
        {
            case string a when a == "Square":
                if (targetColor == "Red") targetObjectParameters.Add("Square", "Red");
                else if (targetColor == "Green") targetObjectParameters.Add("Square", "Green");
                else if (targetColor == "Blue") targetObjectParameters.Add("Square", "Blue");
                break;
            case string a when a == "Circle":
                if (targetColor == "Red") targetObjectParameters.Add("Circle", "Red");
                else if (targetColor == "Green") targetObjectParameters.Add("Circle", "Green");
                else if (targetColor == "Blue") targetObjectParameters.Add("Circle", "Blue");
                break;
            case string a when a == "Number":
                if (targetColor == "Red") targetObjectParameters.Add("Number", "Red");
                else if (targetColor == "Green") targetObjectParameters.Add("Number", "Green");
                else if (targetColor == "Blue") targetObjectParameters.Add("Number", "Blue");
                break;
            case string a when a == "Letter":
                if (targetColor == "Red") targetObjectParameters.Add("Letter", "Red");
                else if (targetColor == "Green") targetObjectParameters.Add("Letter", "Green");
                else if (targetColor == "Blue") targetObjectParameters.Add("Letter", "Blue");
                break;
        }

        switch (losingType)
        {
            case string a when a == "Square":
                if (losingColor == "Red") avoidObjectParameters.Add("Square", "Red");
                else if (losingColor == "Green") avoidObjectParameters.Add("Square", "Green");
                else if (losingColor == "Blue") avoidObjectParameters.Add("Square", "Blue");
                break;
            case string a when a == "Circle":
                if (losingColor == "Red") avoidObjectParameters.Add("Circle", "Red");
                else if (losingColor == "Green") avoidObjectParameters.Add("Circle", "Green");
                else if (losingColor == "Blue") avoidObjectParameters.Add("Circle", "Blue");
                break;
            case string a when a == "Number":
                if (losingColor == "Red") avoidObjectParameters.Add("Number", "Red");
                else if (losingColor == "Green") avoidObjectParameters.Add("Number", "Green");
                else if (losingColor == "Blue") avoidObjectParameters.Add("Number", "Blue");
                break;
            case string a when a == "Letter":
                if (losingColor == "Red") avoidObjectParameters.Add("Letter", "Red");
                else if (losingColor == "Green") avoidObjectParameters.Add("Letter", "Green");
                else if (losingColor == "Blue") avoidObjectParameters.Add("Letter", "Blue");
                break;
        }

        switch (destroyType)
        {
            case string a when a == "Square":
                if (destroyColor == "Red") destroyObjectParameters.Add("Square", "Red");
                else if (destroyColor == "Green") destroyObjectParameters.Add("Square", "Green");
                else if (destroyColor == "Blue") destroyObjectParameters.Add("Square", "Blue");
                break;
            case string a when a == "Circle":
                if (destroyColor == "Red") destroyObjectParameters.Add("Circle", "Red");
                else if (destroyColor == "Green") destroyObjectParameters.Add("Circle", "Green");
                else if (destroyColor == "Blue") destroyObjectParameters.Add("Circle", "Blue");
                break;
            case string a when a == "Number":
                if (destroyColor == "Red") destroyObjectParameters.Add("Number", "Red");
                else if (destroyColor == "Green") destroyObjectParameters.Add("Number", "Green");
                else if (destroyColor == "Blue") destroyObjectParameters.Add("Number", "Blue");
                break;
            case string a when a == "Letter":
                if (destroyColor == "Red") destroyObjectParameters.Add("Letter", "Red");
                else if (destroyColor == "Green") destroyObjectParameters.Add("Letter", "Green");
                else if (destroyColor == "Blue") destroyObjectParameters.Add("Letter", "Blue");
                break;
        }

        SpawnObjects();
    }

    private void SpawnObjects()
    {
        for (onStartSpawnTarget = 0; onStartSpawnTarget < numberOfTargetToSpawns; onStartSpawnTarget++)
        {
            spawnPosition = (Vector2)whereToSpawn.position + UnityEngine.Random.insideUnitCircle * 5;//new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            GameObject objectToSpawn = Instantiate(objectPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            objectToSpawn.SendMessage("SetObjectParameters", targetObjectParameters);
            objectToSpawn.name = objectToSpawn.name + " isTarget";

            currentSpawnedWave.Add(objectToSpawn);
        }

        for (onStartSpawnAvoid = 0; onStartSpawnAvoid < numberOfAvoidToSpawn; onStartSpawnAvoid++)
        {
            spawnPosition = (Vector2)whereToSpawn.position + UnityEngine.Random.insideUnitCircle * 5;//new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            GameObject objectToSpawn = Instantiate(objectPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            objectToSpawn.SendMessage("SetObjectParameters", avoidObjectParameters);
            objectToSpawn.name = objectToSpawn.name + " isLeave";

            currentSpawnedWave.Add(objectToSpawn);
        }

        for (onStartSpawnDestroy = 0; onStartSpawnDestroy < numberOfDestroyToSpawn; onStartSpawnDestroy++)
        {
            spawnPosition = (Vector2)whereToSpawn.position + UnityEngine.Random.insideUnitCircle * 5;//new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            GameObject objectToSpawn = Instantiate(objectPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            objectToSpawn.SendMessage("SetObjectParameters", destroyObjectParameters);
            objectToSpawn.name = objectToSpawn.name + " isDestroy";
            objectToSpawn.tag = "Destroy";

            currentSpawnedWave.Add(objectToSpawn);
        }

        /*for (onStartSpawnRandoms = 0; onStartSpawnRandoms < numberOfRandomsToSpawn; onStartSpawnRandoms++)
        {
            spawnPosition = (Vector2)whereToSpawn.position + UnityEngine.Random.insideUnitCircle * 5;//new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            GameObject objectToSpawn = Instantiate(objectPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            objectToSpawn.SendMessage("SpawnWithRandomParams");

            currentSpawnedWave.Add(objectToSpawn);
        }*/
    }

    void Update()
    {
        ContinuousSpawning();
    }

    private void ContinuousSpawning()
    {
        randomSpawnTimer += Time.deltaTime;
        if (randomSpawnTimer > timeToSpawn)
        {
            spawnPosition = (Vector2)whereToSpawn.position + UnityEngine.Random.insideUnitCircle * 5;//new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            GameObject objectToSpawn = Instantiate(objectPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            
            float whichTypeToSpawn = UnityEngine.Random.Range(0, 4);

            if (whichTypeToSpawn == 0) objectToSpawn.SendMessage("SetObjectParameters", targetObjectParameters);
            if (whichTypeToSpawn == 1) objectToSpawn.SendMessage("SetObjectParameters", avoidObjectParameters);
            if (whichTypeToSpawn == 2) objectToSpawn.SendMessage("SetObjectParameters", avoidObjectParameters);
            if (whichTypeToSpawn == 3) objectToSpawn.SendMessage("SpawnWithRandomParams");

            randomSpawnTimer = 0f;
        }
    }
}
