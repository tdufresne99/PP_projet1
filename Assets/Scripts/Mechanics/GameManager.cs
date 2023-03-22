using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _playerSpawnPosition;

    private TriangleController _triangleController;

    private static GameManager _instance;

    void Awake()
    {
        if(_instance != null) _instance = this;
        else Destroy(this);
    }

    void Start()
    {
        _triangleController = _player.GetComponent<TriangleController>();
    }

    public void ResetPlayerPosition()
    {
        _triangleController.ResetPlayerPosition();
    }

    public static GameManager Instance => _instance;
    public Transform PlayerSpawnPosition => _playerSpawnPosition;
}