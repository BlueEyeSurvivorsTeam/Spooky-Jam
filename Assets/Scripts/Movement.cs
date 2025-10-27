using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float runSpeed = 8f;
    public float tpCooldown = 3f;
    public bool canMove = true;
    public bool canRun = true;
    public KeyCode runKey = KeyCode.LeftShift;
    private float currentSpeed;
    private Vector3 inputDirection;
    Rigidbody2D rb;
    private void Start()
    {
        currentSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(GameManager.Instance.isPaused)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        if(canMove)
        {
            GetInput();
        }
    }
    private void FixedUpdate()
    {
        if(canMove)
        {
            Move();
        }
    }
    private void GetInput()
    {
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.y = Input.GetAxis("Vertical");
        if(Input.GetKey(runKey) && canRun)
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = speed;
        }    
    }
    private void Move()
    {
        rb.linearVelocity = inputDirection * currentSpeed;
    }
    public void TeleportPlayer(Transform pos)
    {
        StartCoroutine(Tp(pos));
    }
    IEnumerator Tp(Transform pos)
    {
        yield return new WaitForSeconds(tpCooldown);
        transform.position = pos.position;
    }
}
