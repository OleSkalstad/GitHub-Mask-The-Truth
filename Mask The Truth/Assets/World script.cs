using UnityEngine;

public class Worldscript : MonoBehaviour
{
     [SerializeField] private Snitch prefabsnitch;
     [SerializeField] private Snitch prefabsnitch1;
     [SerializeField] private Snitch prefabsnitch2;

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
}
