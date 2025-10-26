using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public Transform target;
    public PlayerDetector detector;
    public TransitionController transitionController;
    public float stopChase = 10f;
    public float stopTargetDistance = 1f;
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
        if (GameManager.Instance.isPaused) return;
        if (target != null && detector.playerDetect)
        {
            nma.SetDestination(target.position);
            detector.gameObject.SetActive(false);
            if (Vector2.Distance(transform.position, target.position) < stopTargetDistance)
            {
                transitionController.LoadScene("LoseScene");
                this.transform.SetParent(null);
                DontDestroyOnLoad(this.gameObject);
                nma.isStopped = true;
                nma.enabled = false;
                Invoke(nameof(ClearEnemy), transitionController.anim.GetCurrentAnimatorStateInfo(0).length + 0.1f);
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
        transform.localScale = Vector3.one *50;
        transform.position = new Vector3(0, -5.5f, 0);
        SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
    }
}