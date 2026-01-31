using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float WhisperLiesRate;
    [SerializeField] private float NormalLiesRate;
    [SerializeField] private float NormalWisperLiesRate;
    
    [SerializeField] private float wisperrange;
    [SerializeField] private float NormalTalkRange;
    [SerializeField] private float NormalWisperRange;
    public LayerMask whatIsPeople;

    private CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, wisperrange, whatIsPeople);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            if ( enemiesToDamage[i].GetComponent<Normal_Person>())
            {
                enemiesToDamage[i].GetComponent<Normal_Person>().Convince(WhisperLiesRate);

            }

            if (enemiesToDamage[i].GetComponent<Snitch>())
            {
             Debug.Log("i got caught");   
            }
            enemiesToDamage[i].GetComponent<Snitch>();
            Debug.Log(enemiesToDamage[i]);
            
        }
        
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            Debug.Log("z");
            wisperrange = NormalTalkRange;
            WhisperLiesRate = NormalLiesRate;
            
        }
        

        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            Debug.Log("X");

            wisperrange = NormalWisperRange;
            WhisperLiesRate = NormalWisperLiesRate;
            
        }
           
        

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, wisperrange);

    }
}
