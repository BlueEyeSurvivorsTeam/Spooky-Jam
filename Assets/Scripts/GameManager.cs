using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isPaused { get; private set; }
    public Color playerColor;
    public PartData head;
    public PartData eye;
    public PartData mouth;
    public PartData headDetail;
    public PartData bodyDetail;
    void Awake()
    {
        Instance = this;
    }

    public void SetPause(bool boolean)
    {
        isPaused = boolean;
    }
}