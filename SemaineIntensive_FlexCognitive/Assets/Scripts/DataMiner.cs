using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DataMiner : MonoBehaviour
{
    //GENERAL VALUES
    [FoldoutGroup("GENERAL")][SerializeField] int playerScore;
    [FoldoutGroup("GENERAL")][SerializeField] int totalInteractions;
    
    //INTERACTION TRACKING
    [FoldoutGroup("CURRENTCYCLE")][SerializeField] int totalInteractionsInCycle;
    [FoldoutGroup("CURRENTCYCLE")] [SerializeField] int totalMistakesInCycle;

    //OBJECT TRACKING
    [FoldoutGroup("PACKAGING")][SerializeField] int correctPackagedObjects;
    [FoldoutGroup("PACKAGING")][SerializeField] int incorrectPackagedObjects;
    [FoldoutGroup("PACKAGING")] [SerializeField] int failedPackageObjects;
    [FoldoutGroup("DESTROYING")] [SerializeField] int correctDestroyedObjects;
    [FoldoutGroup("DESTROYING")] [SerializeField] int incorrectDestroyedObjects;

    //OBJECT TRCAKING FOR CURRENT CYCLE
    [FoldoutGroup("CURRENTCYCLE")] [SerializeField] int correctPackagedObjectsInCycle;
    [FoldoutGroup("CURRENTCYCLE")][SerializeField] int incorrectPackagedObjectsInCycle;
    [FoldoutGroup("CURRENTCYCLE")][SerializeField] int failedPackageObjectsInCycle;
    [FoldoutGroup("CURRENTCYCLE")] [SerializeField] int correctDestroyedObjectsInCycle;
    [FoldoutGroup("CURRENTCYCLE")] [SerializeField] int incorrectDestroyedObjectsInCycle;

    //INTERACTION TIMESTAMPS
    [FoldoutGroup("TIMESTAMPS")][SerializeField] List<float> playerAllTimestampsArchive = new List<float>();
    List<float> playerAllTimestamps = new List<float>();
    List<float> playerPackageTimestamps = new List<float>();
    List<float> playerDestroyTimestamps = new List<float>();
    List<float> playerCorrectInteractionsTimestamps = new List<float>();
    [FoldoutGroup("TIMESTAMPS")] [SerializeField] List<float> playerCorrectInteractionsTimestampsArchive = new List<float>();
    [FoldoutGroup("PLAYER TIMES")] [SerializeField] float averageTimeAllActions;
    [FoldoutGroup("PLAYER TIMES")] [SerializeField] float averageTimeCorrectActions;

    //MULTITASKING
    [FoldoutGroup("PERCENTAGES")] [Range(0, 100)] [SerializeField] float multitaskingPercentage;
    [FoldoutGroup("PERCENTAGES")] [Range(0, 100)] [SerializeField] float percentageOfPackaged;
    [FoldoutGroup("PERCENTAGES")] [Range(0, 100)] [SerializeField] float percentageOfDestroyed;

    //ADAPTABILITY
    [FoldoutGroup("PLAYER TIMES")] [SerializeField] float timeToFirstReaction;
    [FoldoutGroup("PLAYER TIMES")] [SerializeField] float averageTimeToFirstReaction;
    [FoldoutGroup("TIMESTAMPS")] [SerializeField] List<float> playerFirstReactionTime = new List<float>();
    [FoldoutGroup("TIMESTAMPS")] [SerializeField] List<float> playerFirstReactionTimeArchive = new List<float>();
    [FoldoutGroup("PERCENTAGES")] [SerializeField] List<float> adaptabilityPercentagesArchive = new List<float>();
    [FoldoutGroup("PERCENTAGES")] [Range(0, 100)] [SerializeField] float adaptabilityPercentage;
    [FoldoutGroup("PERCENTAGES")] [ShowInInspector] public static float numberOfPackageTargets;
    [FoldoutGroup("PERCENTAGES")] [ShowInInspector] public static float numberOfDestroyTargets;


    float packagedTimePassed;
    float destroyTimePassed;

    float packageLap;
    float destroyLap;

    float timePassedBeforeReaction;

    bool packageStartTimer = false;
    bool destroyStartTimer = false;

    bool newSentence = false;

    float _averageTimeBetweenCorrectActions;
    float _averageTimeBetweenActions;
    float _averageTimeToFirstReaction;

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

        if (newSentence) timePassedBeforeReaction += Time.deltaTime;
        StatsTracker();

        multitaskingPercentage = (correctPackagedObjectsInCycle / numberOfPackageTargets  * correctDestroyedObjectsInCycle / numberOfDestroyTargets) * 100;
        percentageOfPackaged = correctPackagedObjectsInCycle / numberOfPackageTargets * 100;
        percentageOfDestroyed = correctDestroyedObjectsInCycle / numberOfDestroyTargets * 100;

        //first reaction time and number of misstkeas
        adaptabilityPercentage = timeToFirstReaction;
        totalMistakesInCycle = incorrectPackagedObjectsInCycle + failedPackageObjectsInCycle + incorrectDestroyedObjectsInCycle;
    }

    //new sentence has been generated
    void NewCycle()
    {
        newSentence = true;

        adaptabilityPercentagesArchive.Add(multitaskingPercentage);

        timePassedBeforeReaction = 0f;
        correctPackagedObjectsInCycle = 0;
        correctDestroyedObjectsInCycle = 0;

        incorrectPackagedObjectsInCycle = 0;
        failedPackageObjectsInCycle = 0;
        incorrectDestroyedObjectsInCycle = 0;

        totalMistakesInCycle = 0;
    }

    void PointTracker(string pointResult)
    {
        packageStartTimer = true; 
        newSentence = false;

        timeToFirstReaction = timePassedBeforeReaction;
        playerFirstReactionTime.Add(timeToFirstReaction);

        packageLap = packagedTimePassed;
        playerAllTimestamps.Add(packageLap);
        playerPackageTimestamps.Add(packageLap);

        switch (pointResult)
        {
            case "Correct":
                correctPackagedObjects++;
                correctPackagedObjectsInCycle++;
                correctInteractionLap = packagedTimePassed;
                playerCorrectInteractionsTimestamps.Add(correctInteractionLap);
                break;
            case "Mistake":
                incorrectPackagedObjects++;
                incorrectPackagedObjectsInCycle++;
                break;
            case "Error":
                incorrectPackagedObjects++;
                incorrectPackagedObjectsInCycle++;
                break;
            case "Incorrect":
                failedPackageObjects++;
                failedPackageObjectsInCycle++;
                break;
        }

        packagedTimePassed = 0f;
    }

    void ObjectDestructionTracker(GameObject destroyed)
    {
        destroyStartTimer = true;
        newSentence = false;

        destroyLap = destroyTimePassed;
        playerAllTimestamps.Add(destroyLap);
        playerDestroyTimestamps.Add(destroyLap);

        if (destroyed.tag == "Destroy")
        {
            //destroyedObjects.Add(destroyed);
            correctDestroyedObjects++;
            correctDestroyedObjectsInCycle++;
            correctInteractionLap = destroyTimePassed;
            playerCorrectInteractionsTimestamps.Add(correctInteractionLap);
        }

        if (destroyed.tag == "Object")
        {
            //wrongDestroyedObjects.Add(destroyed);
            incorrectDestroyedObjects++;
            incorrectDestroyedObjectsInCycle++;
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

        foreach (float timeStamp in playerFirstReactionTime)
        {
            _averageTimeToFirstReaction += timeStamp;
            playerFirstReactionTimeArchive.Add(timeStamp);
            playerFirstReactionTime.Remove(timeStamp);
        }        

        //AVERAGE IME FOR INTERACTIONS
        averageTimeAllActions = _averageTimeBetweenActions/ playerAllTimestampsArchive.Count;
        averageTimeCorrectActions = _averageTimeBetweenCorrectActions / playerCorrectInteractionsTimestampsArchive.Count;
        averageTimeToFirstReaction = _averageTimeToFirstReaction / playerFirstReactionTimeArchive.Count;



        totalInteractions = correctPackagedObjects + correctDestroyedObjects + incorrectPackagedObjects + failedPackageObjects + incorrectDestroyedObjects;
    }
}
