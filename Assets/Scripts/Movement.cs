using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float runSpeed = 8f;
    public bool canMove = true;
    public bool canRun = true;
    public KeyCode runKey = KeyCode.LeftShift;
    private float currentSpeed;
    private Vector3 inputDirection;

    private void Start()
    {
        currentSpeed = speed;
    }
    private void Update()
    {
        if(GameManager.Instance.isPaused)
        {
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
        transform.position += inputDirection * currentSpeed * Time.deltaTime;
    }
}
