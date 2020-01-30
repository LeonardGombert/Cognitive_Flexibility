using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SentenceGenerator : MonoBehaviour
{
    //SENTENCE VARIABLES
    string action, type, color, sentence1, sentence2;

    string[] actionLines;
    string[] typeLines;
    string[] colorLines;
    [SerializeField] TextAsset actionText;
    [SerializeField] TextAsset typeText;
    [SerializeField] TextAsset colorText;

    enum currentAction { trier, laisser, sortir, laisser2};

    [SerializeField] currentAction firstSentence;
    [SerializeField] currentAction secondSentence;

    [SerializeField] GameObject objectGenerator;
    [SerializeField] GameObject[] sortingBoxes;

    private void Awake()
    {
        GenerateSentence();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void GenerateSentence()
    {
        if (actionText != null && typeText != null && colorText != null)
        {
            actionLines = (actionText.text.Split('\n'));
            typeLines = (typeText.text.Split('\n'));
            colorLines = (colorText.text.Split('\n'));

            ActionTypeCheck(1);

            type = typeLines[UnityEngine.Random.Range(0, 4)];
            color = colorLines[UnityEngine.Random.Range(0, 3)];
            sentence1 = string.Format("{0} {1} {2}.", action, color, type);

            ActionTypeCheck(2);

            type = typeLines[UnityEngine.Random.Range(0, 4)];
            color = colorLines[UnityEngine.Random.Range(0, 3)];
            sentence2 = string.Format("{0} {1} {2}.", action, color, type);
            
            SentenceToGeneration(sentence1);
            SentenceToGeneration(sentence2);

            Debug.Log(sentence1);
            Debug.Log(sentence2);
            //GetComponent<TextMesh>().text = dialog;
        }
    }

    private void SentenceToGeneration(string sentenceToRead)
    {
        objectGenerator.SendMessage("SentenceMessageReceiver", sentenceToRead);

        foreach (GameObject sortingBox in sortingBoxes)
        {
            sortingBox.SendMessage("SentenceMessageReceiver", sentenceToRead);
        }
    }

    private void ActionTypeCheck(int whichSentence)
    {
        if(whichSentence == 1)
        {
            switch (firstSentence)
            {
                case currentAction.trier:
                    action = actionLines[0];
                    break;
                case currentAction.laisser:
                    action = actionLines[1];
                    break;
                case currentAction.sortir:
                    action = actionLines[2];
                    break;
                case currentAction.laisser2:
                    action = actionLines[3];
                    break;
            }
        }

        if (whichSentence == 2)
        {
            switch (secondSentence)
            {
                case currentAction.trier:
                    action = actionLines[0];
                    break;
                case currentAction.laisser:
                    action = actionLines[1];
                    break;
                case currentAction.sortir:
                    action = actionLines[2];
                    break;
                case currentAction.laisser2:
                    action = actionLines[3];
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {    
        if(Input.GetKeyDown(KeyCode.Space))
            GenerateSentence();
    }
}
