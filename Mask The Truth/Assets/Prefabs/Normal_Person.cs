using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Normal_Person : MonoBehaviour
{
    public float conversionmeter;
    private bool converted = false;

    [SerializeField] private Slider personalSlider;
    private Worldscript _Worldscript;

    public float Fatigue= 0.005f;

    private void Awake()
    {
        _Worldscript = FindAnyObjectByType<Worldscript>();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Worldscript.StartCount++;
    }

    // Update is called once per frame
    void Update()
    {
      
    
    }

    private void FixedUpdate()
    {
        if (conversionmeter>=1&&!converted)
        {
            converted = true;
            _Worldscript.convertedCounter();
        }
        if (conversionmeter>0 && converted==false)
        {
            conversionmeter -= Fatigue;
        }
       

        if (conversionmeter<0)
        {
            conversionmeter = 0;
        }

        personalSlider.value = conversionmeter;
    }

    public void Convince(float conversionRate)
    {
        conversionmeter += conversionRate;
    }
}
