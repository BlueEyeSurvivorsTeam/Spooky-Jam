using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class KillMonster : MonoBehaviour
{
    public Animator anim;
    public Movement player;
    public CinemachineCamera playerCam;
    public Button startKill;
    public Button killButton;
    public float timeToNextPos = 5f;
    public int attemps = 3;
    float currentTime;
    int counter;
    public float randomPosDistance = 100f;
    bool canKill;
    bool tryToKill;
    CinemachineCamera enemyCam;
    private void Update()
    {
        if(canKill && enemyCam != null && !tryToKill)
        {
            startKill.gameObject.SetActive(true);
        }
        else
        {
            startKill.gameObject.SetActive(false);
        }
        if(killButton.gameObject.activeInHierarchy)
        {
            currentTime += Time.deltaTime;
            if(currentTime > timeToNextPos)
            {
                currentTime = 0;
                counter++;
                SetRandomPosition();
            }
            if(counter == attemps)
            {
                counter = 0;
                
                FailKill();
            }
        }
    }
    public void TryToKill()
    {
        tryToKill = true;
        player.canMove = false;
        playerCam.Priority = 1;
        enemyCam.Priority = 2;
        anim.SetTrigger("Mask");
        killButton.gameObject.SetActive(true);
        SetRandomPosition();
    }
    public void FailKill()
    {
        anim.SetTrigger("Boo");
        tryToKill = false;
        player.canMove = true;
        playerCam.Priority = 2;
        enemyCam.Priority = 1;
        killButton.gameObject.SetActive(false);
        if (enemyCam.GetComponentInParent<SetMonsterPart>())
        {
            enemyCam.GetComponentInParent<SetMonsterPart>().playerDetector.playerDetect = true;
        }
    }
    public void Kill()
    {
        anim.SetTrigger("Boo");
        tryToKill = false;
        player.canMove = true;
        playerCam.Priority = 2;
        enemyCam.Priority = 1;
        killButton.gameObject.SetActive(false);
        if (enemyCam.GetComponentInParent<EnemyMove>())
        {
            if (enemyCam.GetComponentInParent<EnemyMove>().isKing) GameManager.Instance.TryWin();
            enemyCam.GetComponentInParent<EnemyMove>().gameObject.SetActive(false);
        }
        enemyCam = null;
    }
    public void SetRandomPosition()
    {
        RectTransform rectTransform = killButton.GetComponent<RectTransform>();
        RectTransform parentCanvas = killButton.transform.parent.GetComponent<RectTransform>();

        if (rectTransform == null || parentCanvas == null) return;

        Vector2 canvasSize = parentCanvas.rect.size;
        Vector2 buttonSize = rectTransform.rect.size;

        // Calcular área disponible
        float availableWidth = canvasSize.x - buttonSize.x - (randomPosDistance * 2);
        float availableHeight = canvasSize.y - buttonSize.y - (randomPosDistance * 2);

        // Posición random
        float randomX = Random.Range(-availableWidth / 2, availableWidth / 2);
        float randomY = Random.Range(-availableHeight / 2, availableHeight / 2);

        rectTransform.anchoredPosition = new Vector2(randomX, randomY);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponentInChildren<PlayerDetector>())
        {
            PlayerDetector pd = collision.GetComponentInChildren<PlayerDetector>();
            if(collision.GetComponentInChildren<CinemachineCamera>()) enemyCam = collision.GetComponentInChildren<CinemachineCamera>();
            if (!pd.playerDetect && pd.spriteFill.fillAmount == 0)
            {
                canKill = true;
            }
            else
            {
                canKill = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyCam = null;
    }
}
