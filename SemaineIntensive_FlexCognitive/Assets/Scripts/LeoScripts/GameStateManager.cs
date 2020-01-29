using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameStateManager : MonoBehaviour
{
    //SENTENCE VARIABLES
    string action1, type1, color1, sentence1;
    string action2, type2, color2, sentence2;

    string[] actionLines;
    string[] typeLines;
    string[] colorLines;
    [SerializeField] TextAsset actionText;
    [SerializeField] TextAsset typeText;
    [SerializeField] TextAsset colorText;

    public enum currentAction { trier, nePasTrier, sortir, nePasSortir};

    [ShowInInspector] public static currentAction firstSentence;
    [ShowInInspector] public static currentAction secondSentence;

    // Start is called before the first frame update
    void Start()
    {
        GenerateSentence();
    }

    private void GenerateSentence()
    {
        if (actionText != null && typeText != null && colorText != null)
        {
            actionLines = (actionText.text.Split('\n'));
            typeLines = (typeText.text.Split('\n'));
            colorLines = (colorText.text.Split('\n'));

            ActionTypeCheck();

            type1 = typeLines[UnityEngine.Random.Range(0, 4)];
            color1 = colorLines[UnityEngine.Random.Range(0, 3)];

            type2 = typeLines[UnityEngine.Random.Range(0, 4)];
            color2 = colorLines[UnityEngine.Random.Range(0, 3)];

            sentence1 = string.Format("{0} {1} {2}.", action1, type1, color1);
            sentence2 = string.Format("{0} {1} {2}.", action2, type2, color2);

            Debug.Log(sentence1);
            Debug.Log(sentence2);
            //GetComponent<TextMesh>().text = dialog;
        }
    }

    private void ActionTypeCheck()
    {
        switch (firstSentence)
        {
            case currentAction.trier:
                action1 = actionLines[0];
                break;
            case currentAction.nePasTrier:
                action1 = actionLines[1];
                break;
            case currentAction.sortir:
                action1 = actionLines[2];
                break;
            case currentAction.nePasSortir:
                action1 = actionLines[3];
                break;
        }

        switch (secondSentence)
        {
            case currentAction.trier:
                action2 = actionLines[0];
                break;
            case currentAction.nePasTrier:
                action2 = actionLines[1];
                break;
            case currentAction.sortir:
                action2 = actionLines[2];
                break;
            case currentAction.nePasSortir:
                action2 = actionLines[3];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {    

    }
}
