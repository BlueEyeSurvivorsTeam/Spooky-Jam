using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public Transform target;
    public PlayerDetector detector;
    public TransitionController transitionController;
    public float stopChase = 10f;
    public float stopTargetDistance = 0.5f;
    Vector2 initialPos;
    private NavMeshAgent nma;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPos = transform.position;
        nma = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null && detector.playerDetect)
        {
            nma.SetDestination(target.position);
            detector.gameObject.SetActive(false);
            if (Vector2.Distance(transform.position, target.position) < stopTargetDistance)
            {
                DontDestroyOnLoad(this);
                nma.isStopped = true;
                nma.enabled = false;
                transitionController.LoadScene("LoseScene");
                transform.position = new Vector3(0, -5.5f, 0);
                transform.localScale = Vector3.one *50;
                Invoke(nameof(ClearEnemy), 3f);
            }
        }

        if (target != null && Vector2.Distance(transform.position, target.position) > stopChase)
        {
            if (Vector2.Distance(transform.position, initialPos) > stopTargetDistance)
            {
                nma.SetDestination(initialPos);
            }
            detector.gameObject.SetActive(true);
            detector.playerDetect = false;
        }
    }
    private void ClearEnemy()
    {
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
    }
}