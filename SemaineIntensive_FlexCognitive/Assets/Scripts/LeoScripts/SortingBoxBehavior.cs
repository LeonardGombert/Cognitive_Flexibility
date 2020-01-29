using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingBoxBehavior : MonoBehaviour
{
    enum State { Color, Shape, Shape1, Shape2, Number, Letter }

    [SerializeField] State myState;

    GameObject winSortingBox;
    GameObject wrongSortingBox;
    GameObject loseSortingBox;

    string targetType;
    string targetColor;

    string losingType;
    string losingColor;

    // Start is called before the first frame update
    void Start()
    {
        wrongSortingBox = gameObject;
        if (gameObject == wrongSortingBox) gameObject.name = "Wrong Box";
        if (gameObject == winSortingBox) gameObject.name = "Target Box";
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StateChecker(collision.gameObject);

        if (collision.gameObject.name.Contains(losingType) && collision.gameObject.name.Contains(losingColor)) Debug.Log("You lost, nigguh");
        else if (gameObject == winSortingBox && collision.gameObject.name.Contains(targetColor) && collision.gameObject.name.Contains(targetType)) Debug.Log("You got it");
        else if (gameObject == winSortingBox && !collision.gameObject.name.Contains(targetColor)) Debug.Log("Yo, you wrong dude");
        else if (gameObject != winSortingBox && !collision.gameObject.name.Contains(targetColor)) Debug.Log("Yo, GTFOutta here");
        
    }

    void SentenceMessageReceiver(string sentence)
    {
        //ACTION
        if(sentence.Contains("Trier"))
        {
            switch (sentence)
            {
                case string a when a.Contains("Squares"): //byShape
                    if (myState == State.Shape1) winSortingBox = gameObject; //Debug.Log(gameObject.name + " is the active GameObject");
                    targetType = "Square";
                    break;
                case string a when a.Contains("Circles"): //byShape
                    if (myState == State.Shape2) winSortingBox = gameObject; //Debug.Log(gameObject.name + " is the active GameObject");
                    targetType = "Circle";
                    break;
                case string a when a.Contains("Numbers"): //byNumber
                    if (myState == State.Number) winSortingBox = gameObject; //Debug.Log(gameObject.name + " is the active GameObject");
                    targetType = "Number";
                    break;
                case string a when a.Contains("Letters"): //byLetter
                    if (myState == State.Letter) winSortingBox = gameObject; //Debug.Log(gameObject.name + " is the active GameObject");
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

        else if(sentence.Contains("Laisser"))
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

        /* if(Trier) --> switch(where to clean) 
         * case shape: 
         *      if(byColor) 
         *      else if(byShapeType) 
         * case letter: 
         *      if(byColor)
         *      else()
         * case: number
         *      if()
        *
        * 
        * 
        * else if (laisser) --> 
        */
    }

    private void StateChecker(GameObject collisionObject = null)
    {
        switch (myState)
        {
            case State.Color:
                if (collisionObject.name.Contains("Green")) Debug.Log("I've hit Green");
                else if (collisionObject.name.Contains("Blue")) Debug.Log("I've hit Blue");
                else if (collisionObject.name.Contains("Red")) Debug.Log("I've hit Red");
                else Debug.Log("Incompatible");
                break;
            case State.Shape:
                if (collisionObject.name.Contains("Square")) Debug.Log("I've hit a Square");
                else if (collisionObject.name.Contains("Circle")) Debug.Log("I've hit Circle");
                else Debug.Log("Incompatible");
                break;
            case State.Shape1:
                if (collisionObject.name.Contains("Square")) Debug.Log("I've hit a Square");
                else Debug.Log("Incompatible");
                break;
            case State.Shape2:
                if (collisionObject.name.Contains("Circle")) Debug.Log("I've hit a Circle");
                else Debug.Log("Incompatible");
                break;
            case State.Number:
                if (collisionObject.name.Contains("One")) Debug.Log("I've hit a Number");
                else Debug.Log("Incompatible");
                break;
            case State.Letter:
                if (collisionObject.name.Contains("Letter")) Debug.Log("I've hit a Letter");
                else Debug.Log("Incompatible");
                break;
        }
    }
}
