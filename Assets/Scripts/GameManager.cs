using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isPaused { get; private set; }
    public Color playerColor;
    public PartData head;
    public Color headColor;
    public PartData eye;
    public Color eyeColor;
    public PartData mouth;
    public Color mouthColor;
    public PartData headDetail;
    public Color headDetailColor;
    public PartData bodyDetail;
    public Color bodyDetailColor;
    void Awake()
    {
        Instance = this;
    }

    public void SetPause(bool boolean)
    {
        isPaused = boolean;
    }
}