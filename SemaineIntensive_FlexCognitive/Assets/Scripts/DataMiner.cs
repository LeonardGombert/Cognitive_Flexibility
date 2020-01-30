using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMiner : MonoBehaviour
{
    [SerializeField] int playerScore;

    [SerializeField] int correctPackagedObjects;
    [SerializeField] int incorrectPackagedObjects;

    [SerializeField] int correctDestroyedObjects;
    [SerializeField] int incorrectDestroyedObjects;

    [SerializeField] int failedPackageObjects;

    [SerializeField] List<float> playerTime = new List<float>();
    //[SerializeField] List<GameObject> destroyedObjects = new List<GameObject>();
    //[SerializeField] List<GameObject> wrongDestroyedObjects = new List<GameObject>();

    float timePassed;
    bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer) timePassed += Time.deltaTime;
        else return;

        StatsTracker();
    }

    void PointTracker(string pointResult)
    {
        startTimer = true;

        float playerLap = timePassed;
        playerTime.Add(playerLap);

        switch (pointResult)
        {
            case "Correct":
                correctPackagedObjects++;
                break;
            case "Mistake":
                incorrectPackagedObjects--;
                break;
            case "Error":
                incorrectPackagedObjects--;
                break;
            case "Incorrect":
                failedPackageObjects--;
                break;
        }

        timePassed = 0f;
    }

    void ObjectDestructionTracker(GameObject destroyed)
    {
        if (destroyed.tag == "Destroy")
        {
            //destroyedObjects.Add(destroyed);
            correctDestroyedObjects++;
        }

        if (destroyed.tag == "Object")
        {
            //wrongDestroyedObjects.Add(destroyed);
            incorrectDestroyedObjects++;
        }
    }

    void StatsTracker()
    {
        playerScore = correctPackagedObjects + correctDestroyedObjects + incorrectPackagedObjects + failedPackageObjects + incorrectDestroyedObjects;
    }
}
