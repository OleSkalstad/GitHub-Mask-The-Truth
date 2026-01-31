using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snitch : MonoBehaviour
{
    [SerializeField] private Transform[] FirstPath;
    private int CurrentPoint;
    private bool GoOnce=true;
    private int MaxPoints;

    [SerializeField] private int[] CurrentAction;
    private int currentI;
    
    public bool ActionWalk=false; 
    

    private float timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ActionWalk)
        {
            GotoFirstTarget();
        }
    }

    public void Caught()
    {
        SceneManager.LoadScene("YouGotCaught");
    }

    void GotoFirstTarget()
    {
        //initate the number of waypoints
        if (GoOnce)
        {
             MaxPoints=FirstPath.Length;
            Debug.Log(MaxPoints);
            timer = 0;
            GoOnce = false;
        }
        if (timer / 4 >= 1 && (CurrentPoint + 1) == MaxPoints)
        {
            GoOnce = true;
            ActionWalk = false;
            currentI++;
        }
        
        if (timer / 4 >= 1 && (CurrentPoint + 1) <= MaxPoints)
        {
            CurrentPoint++;
            timer = 0;
            Debug.Log("nextPath");
        }

        if (timer/4<=1&& (CurrentPoint + 1) < MaxPoints)
        {
            timer += Time.deltaTime;
            Vector3 pathOne = FirstPath[CurrentPoint].position;
            Vector3 PathTwo = FirstPath[CurrentPoint+1].position;
            transform.position=Vector3.Lerp(pathOne,PathTwo,timer/4);
        }

        
    }

    public void StartNextAction(int i)
    {
        if (i == CurrentAction[currentI]&&currentI<=CurrentAction.Length)
        {
            ActionWalk = true;
        }
    } 
    
}
