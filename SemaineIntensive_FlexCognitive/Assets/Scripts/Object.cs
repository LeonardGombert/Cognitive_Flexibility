using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    enum Type {color, shape, number, letter};
    enum Color {Red, Green, Blue}; enum Shape {Square, Circle}; enum Number {Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine}; enum Letters {A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z};

    [SerializeField] Type myType;
    [SerializeField] Color myColor;
    [SerializeField] Shape myShape;
    [SerializeField] Number myNumber;
    [SerializeField] Letters myLetter;

    SpriteRenderer sr;
    [SerializeField] TextMesh valueText;
    [SerializeField] List<Sprite> spriteShapes = new List<Sprite>();

    public bool isSquare;
    public bool isCircle;
    public bool isNumber;
    public bool isLetter;

    public bool isRed;
    public bool isGreen;
    public bool isBlue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetObjectParameters(Dictionary<string, string> receivedParameters)
    {
        if (receivedParameters.ContainsKey("Square")) isSquare = true; //execute code
        if (receivedParameters.ContainsKey("Circle")) isCircle = true; //execute code
        if (receivedParameters.ContainsKey("Number")) isNumber = true; //execute code
        if (receivedParameters.ContainsKey("Letter")) isLetter = true; //execute code
        
        if (receivedParameters.ContainsValue("Red")) isRed = true; //execute code
        if (receivedParameters.ContainsValue("Green")) isGreen = true; //execute code
        if (receivedParameters.ContainsValue("Blue")) isBlue = true; //execute code
        
        Setup2();
    }

    void SpawnWithRandomParams()
    {
        sr = GetComponent<SpriteRenderer>();
        
        myType = (Type)UnityEngine.Random.Range(1, 4);

        myColor = (Color)UnityEngine.Random.Range(0, 3);
        gameObject.name = myColor.ToString();
        if (gameObject.name.Contains("Green"))
        {
            sr.color = UnityEngine.Color.green;
            valueText.color = UnityEngine.Color.green;
        }
        if (gameObject.name.Contains("Red"))
        {
            sr.color = UnityEngine.Color.red;
            valueText.color = UnityEngine.Color.red;
        }
        if (gameObject.name.Contains("Blue"))
        {
            sr.color = UnityEngine.Color.blue;
            valueText.color = UnityEngine.Color.blue;
        }
        valueText.text = null;

        switch (myType)
        {
            case Type.shape:
                myShape = (Shape)UnityEngine.Random.Range(0, 2);
                if (myShape == Shape.Circle) sr.sprite = spriteShapes[0];
                if (myShape == Shape.Square) sr.sprite = spriteShapes[1];
                gameObject.name = gameObject.name + " " + myShape.ToString();
                break;
            case Type.number:
                myNumber = (Number)UnityEngine.Random.Range(0, 11);
                if (myNumber.ToString() == "Zero") valueText.text = "0";
                if (myNumber.ToString() == "One") valueText.text = "1";
                if (myNumber.ToString() == "Two") valueText.text = "2";
                if (myNumber.ToString() == "Three") valueText.text = "3";
                if (myNumber.ToString() == "Four") valueText.text = "4";
                if (myNumber.ToString() == "Five") valueText.text = "5";
                if (myNumber.ToString() == "Six") valueText.text = "6";
                if (myNumber.ToString() == "Seven") valueText.text = "7";
                if (myNumber.ToString() == "Eight") valueText.text = "8";
                if (myNumber.ToString() == "Nine") valueText.text = "9";
                gameObject.name = gameObject.name + " Number";
                break;
            case Type.letter:
                myLetter = (Letters)UnityEngine.Random.Range(0, 27);
                valueText.text = myLetter.ToString();
                gameObject.name = gameObject.name + " Letter";
                break;
        }
    }

    void Setup2()
    {
        //SET TYPE
        if (isSquare) 
        { 
            myType = Type.shape; 
            myShape = Shape.Square; 
        }
        
        else if (isCircle) 
        { 
            myType = Type.shape; 
            myShape = Shape.Circle;
        }

        else if (isNumber) myType = Type.number;
        else if (isLetter) myType = Type.letter;

        //SET COLOR
        if (isRed) myColor = Color.Red;
        else if (isGreen) myColor = Color.Green;
        else if (isBlue) myColor = Color.Blue;

        Setup();
    }

    private void Setup()
    {
        sr = GetComponent<SpriteRenderer>();

        //valueText = GetComponentInChildren<TextMesh>();
        //valueText.transform.localScale = transform.localScale.Inverse();

        switch (myColor)
        {
            case Color.Red:
                sr.color = UnityEngine.Color.red;
                valueText.color = UnityEngine.Color.red;
                break;
            case Color.Green:
                sr.color = UnityEngine.Color.green;
                valueText.color = UnityEngine.Color.green;
                break;
            case Color.Blue:
                sr.color = UnityEngine.Color.blue;
                valueText.color = UnityEngine.Color.blue;
                break;
            default:
                break;
        }
        gameObject.name = myColor.ToString();
        valueText.text = null;

        switch (myType)
        {
            case Type.shape:
                if (myShape == Shape.Circle) sr.sprite = spriteShapes[0];
                if (myShape == Shape.Square) sr.sprite = spriteShapes[1];
                gameObject.name = gameObject.name + " " + myShape.ToString();
                break;
            case Type.number:
                myNumber = (Number)UnityEngine.Random.Range(0, 11);
                if (myNumber.ToString() == "Zero") valueText.text = "0";
                if (myNumber.ToString() == "One") valueText.text = "1";
                if (myNumber.ToString() == "Two") valueText.text = "2";
                if (myNumber.ToString() == "Three") valueText.text = "3";
                if (myNumber.ToString() == "Four") valueText.text = "4";
                if (myNumber.ToString() == "Five") valueText.text = "5";
                if (myNumber.ToString() == "Six") valueText.text = "6";
                if (myNumber.ToString() == "Seven") valueText.text = "7";
                if (myNumber.ToString() == "Eight") valueText.text = "8";
                if (myNumber.ToString() == "Nine") valueText.text = "9";
                gameObject.name = gameObject.name + " Number";
                break;
            case Type.letter:
                myLetter = (Letters)UnityEngine.Random.Range(0, 27);
                valueText.text = myLetter.ToString();
                gameObject.name = gameObject.name + " Letter" ;
                break;
        }
    }
}

public static class Vector3Extensions
{
    public static Vector3 Inverse(this Vector3 v)
    {
        return new Vector3(1f / v.x, 1f / v.y, 1f / v.z);
    }
}
