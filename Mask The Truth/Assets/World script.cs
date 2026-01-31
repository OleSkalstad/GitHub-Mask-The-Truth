using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Worldscript : MonoBehaviour
{
     [SerializeField] private Snitch prefabsnitch;
     [SerializeField] private Snitch prefabsnitch1;
     [SerializeField] private Snitch prefabsnitch2;

     [SerializeField] private GameObject clockViser;
     [SerializeField] private GameObject hourViser;

     [SerializeField] private float HourLenth;

     [SerializeField] private float[] hourEvent;
     private int eventcounter=0;
    

     public int StartCount;
     [FormerlySerializedAs("conpareCount")] public int compareCount;

     public float world_timer;

     
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        world_timer += Time.deltaTime;


    }

    private void FixedUpdate()
    {
        clockViser.transform.Rotate(new Vector3(0,0,-360/(50*HourLenth)));
        hourViser.transform.Rotate(new Vector3(0,0,-360/(50*HourLenth*12)));

        if (hourEvent[eventcounter]<=world_timer/HourLenth)
        {
            Debug.Log("DingDong");
            eventcounter++;
        }
    }

    void EventOne()
    {
        
    }

    public void convertedCounter()
    {
        compareCount++;
        if (compareCount==StartCount)
        {
            SceneManager.LoadScene("YouWinScreen");
        }
    }

}
