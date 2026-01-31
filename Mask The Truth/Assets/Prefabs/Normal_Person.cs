using System;
using UnityEngine;
using UnityEngine.UI;

public class Normal_Person : MonoBehaviour
{
    public float conversionmeter;
    private bool converted = false;

    [SerializeField] private Slider personalSlider;

    public float Fatigue= 0.005f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    
    }

    private void FixedUpdate()
    {
        if (conversionmeter>=1)
        {
            converted = true;
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
