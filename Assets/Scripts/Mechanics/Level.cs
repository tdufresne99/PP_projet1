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

    [SerializeField] private DeathZone _deathZoneCS;
    [SerializeField] private ShapeStatesManager _playerShapeStateCS;

    [SerializeField] private ShapeStateEnum _levelPuzzleShape;

    private GameObject _instanciatedBallObject;
    
    private Objective _objectiveCS;

    private bool _ballIsReleased = false;

    void Start()
    {
        PlaceObjectcsInLevel();
    }

    private void PlaceObjectcsInLevel()
    {
        if (_playerObject != null && _playerSpawnPosition != null)
        {
            _playerObject.transform.position = _playerSpawnPosition.position;
        }

        if (_ballObject != null && _ballSpawnPosition != null)
        {
            _instanciatedBallObject = Instantiate(_ballObject, _ballSpawnPosition.position, Quaternion.identity, transform);
        }

        if (_objectiveObject != null && _objectiveSpawnPosition != null)
        {
            var objective = Instantiate(_objectiveObject, _objectiveSpawnPosition.position, Quaternion.identity, transform);

            if (objective.GetComponent<Objective>() == null)
                _objectiveCS = objective.AddComponent<Objective>();
            else
                _objectiveCS = objective.GetComponent<Objective>();

            _objectiveCS.parentLevel = this;
        }

        if (_deathZoneCS != null)
        {
            _deathZoneCS.parentLevel = this;
        }
    }

    public void ValidatePuzzle()
    {
        if (_playerShapeStateCS.CurrentStateEnum == _levelPuzzleShape) ReleaseTheBall();
        else ResetLevel();
    }

    public void ReleaseTheBall()
    {
        _ballIsReleased = true;
        _instanciatedBallObject.AddComponent<BallController>();
    }

    public void CompleteLevel()
    {
        var ballcontrollerCS = _instanciatedBallObject.GetComponent<BallController>();
        if (ballcontrollerCS != null)
        {
            ballcontrollerCS.StopBall();
        }
        if (_deathZoneCS != null)
        {
            Destroy(_deathZoneCS);
        }
    }

    public void ResetLevel()
    {
        _ballIsReleased = false;
        Destroy(_instanciatedBallObject.GetComponent<BallController>());
        Destroy(_instanciatedBallObject.GetComponent<Rigidbody2D>());
        _playerObject.transform.position = _playerSpawnPosition.position + Vector3.up * 2f;
        _instanciatedBallObject.transform.position = _ballSpawnPosition.position;
    }

    public void OnNextLevelEntered()
    {
        Debug.Log("level up!");
    }

    public LayerMask PlayerLayer => _playerLayer;
    public LayerMask BallLayer => _ballLayer;
    // public LayerMask LeverLayer => _leverLayer;
    public LayerMask ObjectiveLayer => _objectiveLayer;

    public bool BallIsReleased => _ballIsReleased;
}