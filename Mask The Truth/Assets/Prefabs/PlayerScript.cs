using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerScript : MonoBehaviour
{
    public InputActionAsset InputActions;
    [SerializeField] private float WhisperLiesRate;
    [SerializeField] private float NormalLiesRate;
    [SerializeField] private float NormalWisperLiesRate;
    [SerializeField] private GameObject WhisperIndicator;
    
    [SerializeField] private float wisperrange;
    [SerializeField] private float NormalTalkRange;
    [SerializeField] private float NormalWisperRange;
    public LayerMask whatIsPeople;

    [SerializeField] private Sprite[] DirectionalSprites;
    private SpriteRenderer MyRender;

    private bool HayImWALkingHere;
    
    [SerializeField] private float speed;

    [SerializeField] private AudioSource walking;    

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
        m_movement = InputSystem.actions.FindAction("Move");
        MyRender = GetComponent<SpriteRenderer>();

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
            WhisperIndicator.transform.localScale =
                new Vector3(6.8300004f,6.8300004f,6.8300004f);
        }
        

        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            Debug.Log("X");

            wisperrange = NormalWisperRange;
            WhisperLiesRate = NormalWisperLiesRate;
            WhisperIndicator.transform.localScale =
                new Vector3(2.30032778f, 2.30032778f, 2.30032778f);
            
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
        transform.Translate(movement*speed);
        WalkingAnim();

    }
    private void WalkingAnim()
    {
        
      
            if (movement.y<0)
            {
                MyRender.sprite = DirectionalSprites[0];
            }

            if (movement.y>0)
            {
                MyRender.sprite = DirectionalSprites[1];

            }
        
        
       
            if (movement.x<0)
            {
                MyRender.sprite = DirectionalSprites[2];

            }
            if (movement.x>0)
            {
                MyRender.sprite = DirectionalSprites[3];
            }

            if (movement.x==0&& movement.y==0)
            {
           //     StopCoroutine(PlaySoundEverySecond());
            }
            else
            {
//StartCoroutine(PlaySoundEverySecond());

            }
        
    }

    IEnumerator PlaySoundEverySecond()
    {
        while (true)
        {
            AudioSource sound;
            sound = Instantiate(walking);
            Destroy(sound,1);
            yield return new WaitForSeconds(1f);
        }
    }
}
