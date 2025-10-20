using Unity.VisualScripting;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public KeyCode craftingKey = KeyCode.Tab;
    public bool canCraft = true;
    public GameObject craftingPanel;
    public TransitionController transitionController;
    bool isOpen =false;

    private void Update()
    {
        if(canCraft)
        {
            GetInput();
        }
    }
    public void GetInput()
    {
        if(Input.GetKeyDown(craftingKey)) 
        { 
            if(isOpen && GameManager.Instance.isPaused)
            {
                StartCoroutine(transitionController.Close(craftingPanel));
                GameManager.Instance.SetPause(false);
                isOpen = false;
            }
            else
            {
                StartCoroutine(transitionController.Open(craftingPanel));
                GameManager.Instance.SetPause(true);
                isOpen = true;
            }
        }
    }
}
