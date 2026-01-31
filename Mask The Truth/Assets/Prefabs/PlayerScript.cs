using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerScript : MonoBehaviour
{
    public InputActionAsset InputActions;
    [SerializeField] private float WhisperLiesRate;
    [SerializeField] private float NormalLiesRate;
    [SerializeField] private float NormalWisperLiesRate;
    
    [SerializeField] private float wisperrange;
    [SerializeField] private float NormalTalkRange;
    [SerializeField] private float NormalWisperRange;
    public LayerMask whatIsPeople;

    [SerializeField] private float speed;
    private Rigidbody2D Rigidbody2D;

    private InputAction m_movement;
    private Vector2 movement;
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        m_movement = InputSystem.actions.FindAction("Move");

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
                enemiesToDamage[i].GetComponent<Snitch>().Caught();

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

    private void FixedUpdate()
    {
        movement = m_movement.ReadValue<Vector2>();
        transform.Translate(movement*speed) ;

    }
}
