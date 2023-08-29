using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public float timeElapsedSecs = 0;
    public Text timeElapsed;

    void Update()
    {
        timeElapsedSecs += Time.deltaTime;
        timeElapsed.text = (Math.Truncate(timeElapsedSecs * 100)/100).ToString();
    }
}
