using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingBoxBehavior : MonoBehaviour
{
    enum State { Color, Shape, Shape1, Shape2, Number, Letter }

    [SerializeField] State myState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StateChecker(collision.gameObject);
    }

    void SentenceMessageReceiver(string sentence)
    {
        Debug.Log("SORTING BOXES : " + sentence);
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
                if (collisionObject.name.Contains("Square")) Debug.Log("I've hit Square");
                else if (collisionObject.name.Contains("Circle")) Debug.Log("I've hit Circle");
                else Debug.Log("Incompatible");
                break;
            case State.Shape1:
                if (collisionObject.name.Contains("Square")) Debug.Log("I've hit Square");
                else Debug.Log("Incompatible");
                break;
            case State.Shape2:
                if (collisionObject.name.Contains("Circle")) Debug.Log("I've hit Circle");
                else Debug.Log("Incompatible");
                break;
            case State.Number:
                if (collisionObject.name.Contains("One")) Debug.Log("I've hit 1");
                else if (collisionObject.name.Contains("Two")) Debug.Log("I've hit 2");
                else if (collisionObject.name.Contains("Three")) Debug.Log("I've hit 3");
                else Debug.Log("Incompatible");
                break;
            case State.Letter:
                if (collisionObject.name.Contains("Aee")) Debug.Log("I've hit A");
                else if (collisionObject.name.Contains("Bee")) Debug.Log("I've hit B");
                else if (collisionObject.name.Contains("Cee")) Debug.Log("I've hit C");
                else Debug.Log("Incompatible");
                break;
        }
    }
}
