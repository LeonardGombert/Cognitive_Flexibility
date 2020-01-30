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
    [SerializeField] int numberOfRandomsToSpawn;
    int onStartSpawnTarget;
    int onStartSpawnAvoid;
    int onStartSpawnRandoms;
    Object objectClass;

    float randomSpawnTimer;
    [SerializeField] float timeToSpawn;

    Vector2 spawnPosition;
    
    string targetType;
    string targetColor;

    string losingType;
    string losingColor;
    [ShowInInspector] Dictionary<string, string> targetObjectParameters = new Dictionary<string, string>();
    [ShowInInspector] Dictionary<string, string> avoidObjectParameters = new Dictionary<string, string>();

    void Start()
    {
        objectClass = objectPrefab.GetComponent<Object>();
    }
    
    // Update is called once per frame
    void SentenceMessageReceiver(string sentence)
    {
        //ACTION
        if (sentence.Contains("Trier"))
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

        else if (sentence.Contains("Laisser"))
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
            AssignValues();
        }
    }

    private void AssignValues()
    {
        targetObjectParameters.Clear();
        avoidObjectParameters.Clear();

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
        }

        for (onStartSpawnAvoid = 0; onStartSpawnAvoid < numberOfAvoidToSpawn; onStartSpawnAvoid++)
        {
            spawnPosition = (Vector2)whereToSpawn.position + UnityEngine.Random.insideUnitCircle * 5;//new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            GameObject objectToSpawn = Instantiate(objectPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            objectToSpawn.SendMessage("SetObjectParameters", avoidObjectParameters);
        }

        /*for (onStartSpawnRandoms = 0; onStartSpawnRandoms < numberOfRandomsToSpawn; onStartSpawnRandoms++)
        {
            spawnPosition = (Vector2)whereToSpawn.position + UnityEngine.Random.insideUnitCircle * 5;//new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            GameObject objectToSpawn = Instantiate(objectPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            objectToSpawn.SendMessage("SpawnWithRandomParams");
        }*/
    }

    void Update()
    {
        randomSpawnTimer += Time.deltaTime;
        if (randomSpawnTimer > timeToSpawn)
        {
            spawnPosition = (Vector2)whereToSpawn.position + UnityEngine.Random.insideUnitCircle * 5;//new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
            GameObject objectToSpawn = Instantiate(objectPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            objectToSpawn.SendMessage("SpawnWithRandomParams");
            randomSpawnTimer = 0f;
        }
    }
}
