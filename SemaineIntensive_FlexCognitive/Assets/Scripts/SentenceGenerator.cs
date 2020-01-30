using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SentenceGenerator : MonoBehaviour
{
    //SENTENCE VARIABLES
    string action, type, color, sentence1, sentence2, sentence3;

    string[] actionLines;
    string[] typeLines;
    string[] colorLines;
    [SerializeField] TextAsset actionText;
    [SerializeField] TextAsset typeText;
    [SerializeField] TextAsset colorText;

    enum currentAction { package, doNotPackage, sortir, doNotPackage2, destroy};

    [SerializeField] currentAction firstSentence;
    [SerializeField] currentAction secondSentence;
    [SerializeField] currentAction thirdSentence;

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GenerateSentence();
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

            SentenceDifferentiator("sentence2");

            ActionTypeCheck(3);

            type = typeLines[UnityEngine.Random.Range(0, 4)];
            color = colorLines[UnityEngine.Random.Range(0, 3)];
            sentence3 = string.Format("{0} {1} {2}.", action, color, type);

            SentenceDifferentiator("sentence3");

            SentenceToGeneration(sentence1);
            SentenceToGeneration(sentence2);
            SentenceToGeneration(sentence3);

            Debug.Log(sentence1);
            Debug.Log(sentence2);
            Debug.Log(sentence3);
            //GetComponent<TextMesh>().text = dialog;
        }
    }

    private void ActionTypeCheck(int whichSentence)
    {
        if (whichSentence == 1)
        {
            switch (firstSentence)
            {
                case currentAction.package:
                    action = actionLines[0];
                    break;
                case currentAction.doNotPackage:
                    action = actionLines[1];
                    break;
                case currentAction.sortir:
                    action = actionLines[2];
                    break;
                case currentAction.doNotPackage2:
                    action = actionLines[3];
                    break;
                case currentAction.destroy:
                    action = actionLines[4];
                    break;
            }
        }

        if (whichSentence == 2)
        {
            switch (secondSentence)
            {
                case currentAction.package:
                    action = actionLines[0];
                    break;
                case currentAction.doNotPackage:
                    action = actionLines[1];
                    break;
                case currentAction.sortir:
                    action = actionLines[2];
                    break;
                case currentAction.doNotPackage2:
                    action = actionLines[3];
                    break;
                case currentAction.destroy:
                    action = actionLines[4];
                    break;
            }
        }

        if (whichSentence == 3)
        {
            switch (thirdSentence)
            {
                case currentAction.package:
                    action = actionLines[0];
                    break;
                case currentAction.doNotPackage:
                    action = actionLines[1];
                    break;
                case currentAction.sortir:
                    action = actionLines[2];
                    break;
                case currentAction.doNotPackage2:
                    action = actionLines[3];
                    break;
                case currentAction.destroy:
                    action = actionLines[4];
                    break;
            }
        }
    }

    private void SentenceDifferentiator(string whichSentence)
    {
        if(whichSentence == "sentence2")
        {
            if (sentence1.Replace("Package", "") == sentence2.Replace("Leave", ""))
            {
                while (sentence1.Replace("Package", "") == sentence2.Replace("Leave", ""))
                {
                    type = typeLines[UnityEngine.Random.Range(0, 4)];
                    color = colorLines[UnityEngine.Random.Range(0, 3)];
                    sentence2 = string.Format("{0} {1} {2}.", action, color, type);
                }
            }
        }

        if (whichSentence == "sentence3")
        {
            if (sentence1.Replace("Package", "") == sentence3.Replace("Destroy", "") || sentence2.Replace("Leave", "") == sentence3.Replace("Destroy", ""))
            {
                while (sentence1.Replace("Package", "") == sentence3.Replace("Destroy", "") || sentence2.Replace("Leave", "") == sentence3.Replace("Destroy", ""))
                {
                    type = typeLines[UnityEngine.Random.Range(0, 4)];
                    color = colorLines[UnityEngine.Random.Range(0, 3)];
                    sentence3 = string.Format("{0} {1} {2}.", action, color, type);
                }
            }
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
}
