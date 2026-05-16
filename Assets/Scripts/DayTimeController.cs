using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using System.Runtime.CompilerServices;
using System;
using Unity.Mathematics.Geometry;
using System.Collections;
using System.Collections.Generic;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;
    const float phaseLength = 900f;

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;

    float time;
    [SerializeField] float timeScale = 60f;
    [SerializeField] float startAtTime = 28800f;

    [SerializeField] Text text;
    [SerializeField] Light2D globalLight;
    private int days;   

    List<TimeAgent> agents;

    private void Awake()
    {   
        agents = new List<TimeAgent>();
    }

    private void Start()
    {
        time = startAtTime;
    }
    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }

    public void UnsubScribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
    } 
    float Hours
    {
        get {return time / 3600f; }
    }

    float Minutes
    {
        get {return time % 3600f / 60f; }
    }
    private void Update()
    {
        time += Time.deltaTime * timeScale;

        TimeValueCalculation();
        DayLight();

        if (time > secondsInDay)
        {
            NextDay();
        }

        TimeAgents();
    }

    private void TimeValueCalculation()
    {
        int hh = (int)Hours;
        int mm = (int)Minutes;
        text.text = hh.ToString("00") + ":" + mm.ToString("00");
    }


    private void DayLight()
    {
        float V = nightTimeCurve.Evaluate(Hours);
        Color C = Color.Lerp(dayLightColor, nightLightColor, V);
        globalLight.color = C;
    }

    int oldPhase = 0;
    private void TimeAgents()
    {
        int phase = (int)(time / phaseLength);
        
        if(oldPhase != phase)
        {
            oldPhase = phase;
            for(int i = 0; i < agents.Count; i++)
            {
                agents[i].Invoke();
            }
        }

        /*for (int i = 0; i < agents.Count; i++)
        {
            agents[i].Invoke();
        }*/
    }


    private void NextDay()
    {
        time = 0;
        days += 1;
    }
    
}
