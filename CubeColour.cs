﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColour : MonoBehaviour
{
    private Color originalColour;
    private Vector3 originalVector;
    private Quaternion originalPose;

    // Use this for initialization
    void Start()
    {
        var newColour = Color.blue; 
        this.GetComponent<Renderer>().material.color = newColour;

        originalColour = newColour;
        originalVector = this.transform.position;

        originalPose = this.transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSelect()
    {
        // Get the object gazed at, then store original colour
        var cube = this.GetComponent<Renderer>();

        // Change to highlight colour
        cube.material.color = Color.black;
    }

    void OnReset()
    {
        // Get the object gazed at, then store original colour
        var cube = this.GetComponent<Renderer>();

        // Change to highlight colour
        cube.material.color = originalColour;
    }

    public void OnResetBlock()
    {
        this.transform.position = originalVector;
        transform.rotation = Quaternion.Slerp(transform.rotation, originalPose, 1.0f);
    }
}