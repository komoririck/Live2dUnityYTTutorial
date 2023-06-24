//live2d sdk has a code that make a similar think, but i'm posting it since this can give a idea of how to
    //work with parameters 

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;

[System.Serializable]
public class ParameterLoop : MonoBehaviour {
    [SerializeField]
    private CubismParameter parameter;
    [SerializeField]
    private float startValue;
    [SerializeField]
    private float minValue;
    [SerializeField]
    private float maxValue;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float interval;
    private float currentValue;
    private float currentInterval;
    private bool increasing = true;
    private bool intervaling = false;

    void Start(){
        currentValue = startValue;
        currentInterval = 0;
        minValue = parameter.MinimumValue;
        maxValue = parameter.MaximumValue;
        if (minValue < parameter.MinimumValue)
            minValue = parameter.MinimumValue;
        if (maxValue < parameter.MaximumValue)
            maxValue = parameter.MaximumValue;
    }

    void LateUpdate(){
        if (intervaling) {
            if (currentInterval > interval)
                intervaling = false;
            currentInterval += Time.deltaTime;
        } else {
            if (increasing)
            {
                currentValue += speed * Time.deltaTime;
                if (currentValue > maxValue)
                {
                    currentValue = maxValue;
                    increasing = false;
                    intervaling = true;
                    currentInterval = 0;
                }
            }
            else
            {
                currentValue -= speed * Time.deltaTime;
                if (currentValue < minValue)
                {
                    currentValue = minValue;
                    increasing = true;
                }
            }
            parameter.Value = currentValue;
        }
    }
}