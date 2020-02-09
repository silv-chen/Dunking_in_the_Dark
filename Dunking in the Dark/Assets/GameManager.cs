﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

        //Lights and Timing
    [SerializeField] private float gameTime;

    [HideInInspector] public float p1Score;
    [HideInInspector] public float p2Score;

    //Dangerous variable, the delta of our timer
    private float delta = .1f;

    [SerializeField] private float lightsOnTime;
    [SerializeField] private float lightsOffTime;
    [SerializeField] private float lastXLight;
    private bool lightsOn = true;
    private float lightCounter;

    //Our Serialized Objects
    [SerializeField] private GameObject darknessPlane;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI p1Text;
    [SerializeField] private TextMeshProUGUI p2Text;

    // Start is called before the first frame update
    void Start()
    {
        lightCounter = lightsOnTime;
        StartCoroutine("GameTimeController");
        SetLights();
        updateScore();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GameTimeController()
    {
        while (gameTime > lastXLight)
        {
            SetTimer();
            gameTime -= delta;
            lightCounter -= delta;
            print("LightCounter is " + lightCounter);
            if (lightCounter < 0)
            {
                print("Switching lights!");
                lightsOn = !lightsOn;
                lightCounter = lightsOn ? lightsOnTime : lightsOffTime;
                SetLights();
            }
            yield return new WaitForSeconds(delta);
        }
        lightsOn = true;
        SetLights();
        while (gameTime > 0)
        {
            SetTimer();
            gameTime -= delta;
            yield return new WaitForSeconds(delta);
        }
        SetTimer();
        //At the end of our checks! Time is out, so lets exit
        ExitGame();
    }
    
    

    private void SetTimer()
    {
        //Stub for setting the time!
        scoreText.SetText("Time Left:\n" + (int) gameTime);
    }

    //TODO: Fill out my stubs!
    private void SetLights()
    {
        if (lightsOn)
        {
            //Turn the lights on!
            darknessPlane.SetActive(false);
        }
        else
        {
            //Turn them off!
            darknessPlane.SetActive(true);
        }
    }

    private void ExitGame()
    {
        print("Game should be exiting!");
    }

    public void addP1()
    {
        p1Score++;
        updateScore();
    }

    public void addP2()
    {
        p2Score++;
        updateScore();
    }

    public void updateScore()
    {
        p1Text.SetText("Player 1\n" + p1Score);
        p2Text.SetText("Player 2\n" + p2Score);
    }
}
