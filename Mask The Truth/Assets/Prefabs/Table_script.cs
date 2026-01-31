using UnityEngine;

public class Table_script : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    public LayerMask whatIsEnemies;
    public float duration = 5;
    public bool destroyable = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        void Start()
        {
            circleCollider = GetComponent<CircleCollider2D>();
            //cicle parameters
            Vector2 center = circleCollider.bounds.center;
            float radius = circleCollider.radius * transform.lossyScale.x;
            Collider2D[] hits = Physics2D.OverlapCircleAll(center, radius, whatIsEnemies);
            foreach (Collider2D hit in hits)
            {
                if (hit.gameObject != gameObject) // ignore self
                {
                    Debug.Log("Inside at spawn: " + hit.name);
                    // Do whatever logic you need here
                    hit.GetComponent<PlayerScript>();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
