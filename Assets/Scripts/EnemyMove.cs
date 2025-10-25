using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform target;
    public PlayerDetector detector;
    public float stopDistance = 10f;
    public float speed = 3f;
    Vector2 initialPos;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPos = transform.position;
    }

    private void Update()
    {
        if (target != null && detector.playerDetect)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
            detector.gameObject.SetActive(false);
        }

        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            Vector2 direction = (initialPos - (Vector2)transform.position).normalized;
            rb.linearVelocity = direction * speed;
            detector.gameObject.SetActive(true);
            detector.playerDetect = false;
        }
    }
}