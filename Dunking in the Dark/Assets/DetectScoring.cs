﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScoring : MonoBehaviour
{
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        source.Play();
        if (other.gameObject.CompareTag("Player1"))
        {
            //Give player one points!
            GameManager.instance.addP1();
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            //Give player two points!
            GameManager.instance.addP2();
        }
    }
}
