using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingBoxBehavior : MonoBehaviour
{
    enum State { Color, Shape, Number, Letter }

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

    private void StateChecker(GameObject collisionObject = null)
    {
        switch (myState)
        {
            case State.Color:
                if (collisionObject.name.Contains("Green")) Debug.Log("I've hit Green");
                if (collisionObject.name.Contains("Blue")) Debug.Log("I've hit Blue");
                if (collisionObject.name.Contains("Red")) Debug.Log("I've hit Red");
                break;
            case State.Shape:
                if (collisionObject.name.Contains("Square")) Debug.Log("I've hit Square");
                if (collisionObject.name.Contains("Circle")) Debug.Log("I've hit Circle");
                break;
            case State.Number:
                if (collisionObject.name.Contains("One")) Debug.Log("I've hit 1");
                if (collisionObject.name.Contains("Two")) Debug.Log("I've hit 2");
                if (collisionObject.name.Contains("Three")) Debug.Log("I've hit 3");
                break;
            case State.Letter:
                if (collisionObject.name.Contains("Aee")) Debug.Log("I've hit A");
                if (collisionObject.name.Contains("Bee")) Debug.Log("I've hit B");
                if (collisionObject.name.Contains("Cee")) Debug.Log("I've hit C");
                break;
        }
    }
}
