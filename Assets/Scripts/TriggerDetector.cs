using UnityEngine;
using UnityEngine.Events;

public class TriggerDetector : MonoBehaviour
{
    public string tagDetect;
    public UnityEvent triggerEnterEvent;
    public UnityEvent triggerExitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagDetect))
        {
            triggerEnterEvent.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(tagDetect))
        {
            triggerExitEvent.Invoke();
        }
    }
}
