using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _playerSpawnPosition;

    [SerializeField] private  TriangleController _triangleController;

    private static GameManager _instance;

    void Awake()
    {
        if(_instance == null) _instance = this;
        else Destroy(this);
    }

    void Start()
    {
        _triangleController = _player.GetComponent<TriangleController>();
    }

    // public void ResetPlayerPosition()
    // {
    //     _triangleController.ResetPlayerPosition(true);
    // }
    public void ResetPlayerPosition(bool instanciatePart)
    {
        _triangleController.ResetPlayerPosition(instanciatePart);
    }

    public void SetPlayerInactive()
    {
        _player.gameObject.SetActive(false);
    }

    public void SetPlayerActive()
    {
        _player.gameObject.SetActive(true);
    }

    public static GameManager Instance => _instance;
    public Transform PlayerSpawnPosition => _playerSpawnPosition;
}