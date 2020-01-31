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

    [SerializeField] int totalInteractions;

    [SerializeField] List<float> playerAllTimestamps = new List<float>();
    [SerializeField] List<float> playerAllTimestampsArchive = new List<float>();

    [SerializeField] List<float> playerCorrectInteractionsTimestamps = new List<float>();
    [SerializeField] List<float> playerCorrectInteractionsTimestampsArchive = new List<float>();

    [SerializeField] List<float> playerPackageTimestamps = new List<float>();
    [SerializeField] List<float> playerDestroyTimestamps = new List<float>();

    float packagedTimePassed;
    float destroyTimePassed;

    bool packageStartTimer = false;
    bool destroyStartTimer = false;

    float packageLap;
    float destroyLap;

    [SerializeField] float averageTimeBetweenAllActions;
    [SerializeField] float averageTimeBetweenCorrectActions;
    float _averageTimeBetweenCorrectActions;
    float _averageTimeBetweenActions;
    
    float correctInteractionLap;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(packageStartTimer) packagedTimePassed += Time.deltaTime;
        if(destroyStartTimer) destroyTimePassed += Time.deltaTime;
        StatsTracker();
    }

    void PointTracker(string pointResult)
    {
        packageStartTimer = true;

        packageLap = packagedTimePassed;
        playerAllTimestamps.Add(packageLap);
        playerPackageTimestamps.Add(packageLap);

        switch (pointResult)
        {
            case "Correct":
                correctPackagedObjects++;
                correctInteractionLap = packagedTimePassed;
                playerCorrectInteractionsTimestamps.Add(correctInteractionLap);
                break;
            case "Mistake":
                incorrectPackagedObjects++;
                break;
            case "Error":
                incorrectPackagedObjects++;
                break;
            case "Incorrect":
                failedPackageObjects++;
                break;
        }

        packagedTimePassed = 0f;
    }

    void ObjectDestructionTracker(GameObject destroyed)
    {
        destroyStartTimer = true;

        destroyLap = destroyTimePassed;
        playerAllTimestamps.Add(destroyLap);
        playerDestroyTimestamps.Add(destroyLap);

        if (destroyed.tag == "Destroy")
        {
            //destroyedObjects.Add(destroyed);
            correctDestroyedObjects++;
            correctInteractionLap = destroyTimePassed;
            playerCorrectInteractionsTimestamps.Add(correctInteractionLap);
        }

        if (destroyed.tag == "Object")
        {
            //wrongDestroyedObjects.Add(destroyed);
            incorrectDestroyedObjects++;
        }

        destroyTimePassed = 0f;
    }

    void StatsTracker()
    {
        playerScore = correctPackagedObjects + correctDestroyedObjects - incorrectPackagedObjects - failedPackageObjects - incorrectDestroyedObjects;

        foreach (float timeStamp in playerAllTimestamps)
        {
            _averageTimeBetweenActions += timeStamp;
            playerAllTimestampsArchive.Add(timeStamp);
            playerAllTimestamps.Remove(timeStamp);
        } 

        foreach (float timeStamp in playerCorrectInteractionsTimestamps)
        {
            _averageTimeBetweenCorrectActions += timeStamp;
            playerCorrectInteractionsTimestampsArchive.Add(timeStamp);
            playerCorrectInteractionsTimestamps.Remove(timeStamp);
        }
        
        //AVERAGE IME FOR INTERACTIONS
        averageTimeBetweenAllActions = _averageTimeBetweenActions/ playerAllTimestampsArchive.Count;
        averageTimeBetweenCorrectActions = _averageTimeBetweenCorrectActions / playerCorrectInteractionsTimestampsArchive.Count;

        totalInteractions = correctPackagedObjects + correctDestroyedObjects + incorrectPackagedObjects + failedPackageObjects + incorrectDestroyedObjects;
    }
}
