using UnityEngine;
public class Level : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _ballLayer;
    [SerializeField] private LayerMask _objectiveLayer;

    [SerializeField] private GameObject _playerObject;
    [SerializeField] private GameObject _ballObject;
    [SerializeField] private GameObject _objectiveObject;

    [SerializeField] private Transform _playerSpawnPosition;
    [SerializeField] private Transform _ballSpawnPosition;
    [SerializeField] private Transform _objectiveSpawnPosition;

    [SerializeField] private Target _targetCS;
    [SerializeField] private ShapeStatesManager _playerShapeStateCS;

    [SerializeField] private ShapeStateEnum _levelPuzzleShape;

    private GameObject _instanciatedBallObject;
    private TriangleController _playerCS;
    void Start()
    {
        PlaceObjectcsInLevel();
        _playerCS = _playerObject.GetComponent<TriangleController>();
    }

    private void PlaceObjectcsInLevel()
    {
        if (_ballObject != null && _ballSpawnPosition != null)
        {
            _instanciatedBallObject = Instantiate(_ballObject, _ballSpawnPosition.position, Quaternion.identity, transform);
        }

        if (_targetCS != null)
        {
            _targetCS.parentLevel = this;
        }
    }

    public void ValidatePuzzle()
    {
        if (_playerShapeStateCS.CurrentStateEnum == _levelPuzzleShape && _playerCS.currentPointingDirection == _targetCS.pointingDirection)
        {
            GameManager.Instance.ResetPlayerPosition(true);
            ReleaseTheBall();
            // GameManager.Instance.ResetPlayerPosition(true);
            _targetCS.LockTriangle();
        }
        else 
        {
            GameManager.Instance.ResetPlayerPosition(false);
        }
    }

    public void ReleaseTheBall()
    {
        _instanciatedBallObject.AddComponent<BallController>();
    }

    public void CompleteLevel()
    {
        var ballcontrollerCS = _instanciatedBallObject.GetComponent<BallController>();
        if (ballcontrollerCS != null)
        {
            ballcontrollerCS.StopBall();
        }
        ResetLevel();
        GameManager.Instance.SetPlayerActive();

    }

    public void ResetLevel()
    {
        PlaceObjectcsInLevel();
    }

    public void OnNextLevelEntered()
    {
        Debug.Log("level up!");
    }

    public LayerMask PlayerLayer => _playerLayer;
    public LayerMask BallLayer => _ballLayer;
    // public LayerMask LeverLayer => _leverLayer;
    public LayerMask ObjectiveLayer => _objectiveLayer;
}