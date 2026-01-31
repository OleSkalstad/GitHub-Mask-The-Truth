using System;
using UnityEngine;

public class Worldscript : MonoBehaviour
{
     [SerializeField] private Snitch prefabsnitch;
     [SerializeField] private Snitch prefabsnitch1;
     [SerializeField] private Snitch prefabsnitch2;

     [SerializeField] private GameObject clockViser;

     [SerializeField] private float HourLenth;
     

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
        clockViser.transform.Rotate(new Vector3(0,0,360/(50*HourLenth)));
    }
}
