using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float WhisperLiesRate;
    [SerializeField] private float wisperrange;
    public LayerMask whatIsPeople;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(transform.position, wisperrange, whatIsPeople);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Normal_Person>().Convince(WhisperLiesRate);
            Debug.Log(enemiesToDamage[i]);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, wisperrange);

    }
}
