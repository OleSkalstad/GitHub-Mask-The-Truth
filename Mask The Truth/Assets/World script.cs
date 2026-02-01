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

     
     [SerializeField] private AudioSource[] titoksound;
     private float TikToktimer;
     private bool TikkingOrTokking=false;
     
    
     public bool gotoNextlvl = false;

     public int StartCount;
     public int compareCount;

     public float world_timer;

     
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        world_timer += Time.deltaTime;
        TikTok();

    }

    private void FixedUpdate()
    {
        clockViser.transform.Rotate(new Vector3(0,0,-360/(50*HourLenth)));
        hourViser.transform.Rotate(new Vector3(0,0,-360/(50*HourLenth*12)));

        if (hourEvent[eventcounter]<=world_timer/HourLenth)
        {
            if (eventcounter==4)
            {
                EventOne();
            }
            eventcounter++;
            prefabsnitch.StartNextAction(eventcounter);
            prefabsnitch1.StartNextAction(eventcounter);
            prefabsnitch2.StartNextAction(eventcounter);
            
        }
    }

    void EventOne()
    {
        
        SceneManager.LoadScene("OutOfTime");

    }

    public void convertedCounter()
    {
        compareCount++;
        if (compareCount==StartCount && !gotoNextlvl)
        {
            SceneManager.LoadScene("YouWinScreen");
        }
    if (compareCount==StartCount && gotoNextlvl)
        {
         SceneManager.LoadScene("Lvl2");
        }
    }

    void TikTok()
    {
        TikToktimer += Time.deltaTime;
        if (TikToktimer>=1&&!TikkingOrTokking)
        {
            TikkingOrTokking = true;
            TikToktimer = 0;
            AudioSource sound;
            sound = Instantiate(titoksound[0]);
            Destroy(sound,1);
            
        }
        if (TikToktimer>=1&&TikkingOrTokking)
        {
            TikkingOrTokking = false;
            TikToktimer = 0;
            AudioSource sound;
            sound = Instantiate(titoksound[1]);
            Destroy(sound,1);
        }

    }
}

