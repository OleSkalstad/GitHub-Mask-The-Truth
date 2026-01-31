using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snitch : MonoBehaviour
{
    [SerializeField] private Transform[] FirstPath;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime
    }

    public void Caught()
    {
        SceneManager.LoadScene("YouGotCaught");
    }

    void GotoFirstTarget()
    {
        transform.position=FirstPath[0]*Vector3.Lerp(1-);
    }
    
}
