﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMusicSection : MonoBehaviour
{
    Rigidbody rbd;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
	rbd.velocity = new Vector3(0, 0, speed);   
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
