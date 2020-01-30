using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMiner : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] List<float> playerTime = new List<float>();

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
    }

    void PointTracker(string pointResult)
    {
        startTimer = true;

        float playerLap = timePassed;
        playerTime.Add(playerLap);

        switch (pointResult)
        {
            case "Correct":
                playerScore++;
                break;
            case "Mistake":
                playerScore--;
                break;
            case "Error":
                playerScore--;
                break;
            case "Incorrect":
                Debug.Log("That was a mistake");
                break;
        }

        timePassed = 0f;
    }
}
