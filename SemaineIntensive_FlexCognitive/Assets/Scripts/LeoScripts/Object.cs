using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Object : MonoBehaviour
{
    SpriteRenderer sr;
    enum Color {red, green, blue}; enum Shape {square, circle}; enum Number {one, two, three}; enum Letters {a, b, c};

    [SerializeField] Color myColor;
    [SerializeField] Shape myShape;
    [SerializeField] Number myNumber;
    [SerializeField] Letters myLetters;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        myColor = (Color)Random.Range(0, 3);
        myShape = (Shape)Random.Range(0, 2);
        myNumber = (Number)Random.Range(0, 3);
        myLetters = (Letters)Random.Range(0, 3);

        gameObject.name = myColor.ToString() + " " + myShape.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
