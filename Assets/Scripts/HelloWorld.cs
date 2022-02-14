using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // string message = "Hello world";  no se debe hacer así
    [SerializeField] private string  message = "Hello there!";
    [SerializeField] private float  rotationSpeed = 200f;
    //[SerializeField] private float  grados = 2;
    [SerializeField] private float  Velocidad = 100f;
    // Start is called before the first frame update


    void Start()
    {
        Debug.Log(message);
    }

    // Update is called once per frame
    void Update()
    {

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
       // transform.Rotate(0f,0f, grados * Time.deltaTime);
       float goup = Input.GetAxis("Vertical")* Velocidad *  Time.deltaTime;
       transform.Rotate(0f,0f, rotation);
       transform.Translate(0f,goup, 0f);
        
    }
}
