using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    enum Type {color, shape, number, letter};
    enum Color {Red, Green, Blue}; enum Shape {Square, Circle}; enum Number {One, Two, Three}; enum Letters {A, B, C};

    [SerializeField] Type myType;
    [SerializeField] Color myColor;
    [SerializeField] Shape myShape;
    [SerializeField] Number myNumber;
    [SerializeField] Letters myLetter;

    SpriteRenderer sr;
    [SerializeField] TextMesh valueText;
    [SerializeField] List<Sprite> spriteShapes = new List<Sprite>();

    // Start is called before the first frame update
    void Awake()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InfoReceiver(string isRandom = null)
    {

    }

    private void Setup()
    {
        sr = GetComponent<SpriteRenderer>();

        //valueText = GetComponentInChildren<TextMesh>();
        //valueText.transform.localScale = transform.localScale.Inverse();

        myType = (Type)UnityEngine.Random.Range(0, 4);

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
                myNumber = (Number)UnityEngine.Random.Range(0, 3);
                if(myNumber.ToString() == "One") valueText.text = "1";
                if(myNumber.ToString() == "Two") valueText.text = "2";
                if(myNumber.ToString() == "Three") valueText.text = "3";
                gameObject.name = gameObject.name + " Number";
                break;
            case Type.letter:
                myLetter = (Letters)UnityEngine.Random.Range(0, 3);
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
