using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _playerSpawnPosition;

    private TriangleController _triangleController;

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

    public void ResetPlayerPosition(bool disablePlayer)
    {
        _triangleController.ResetPlayerPosition();

        if (disablePlayer)
        {
            SetPlayerInactive();
        }
    }

    public void SetPlayerInactive()
    {
        _triangleController.gameObject.SetActive(false);
    }

    public void SetPlayerActive()
    {
        _triangleController.gameObject.SetActive(true);
    }

    public static GameManager Instance => _instance;
    public Transform PlayerSpawnPosition => _playerSpawnPosition;
}