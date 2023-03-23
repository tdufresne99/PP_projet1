using UnityEngine;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private GameObject _ballObject;

    [SerializeField] private Transform _ballSpawnPosition;

    [SerializeField] private ShapeStatesManager _playerShapeStateCS;
    [SerializeField] private LevelContainer _levelContainerCS;
    [SerializeField] private Sinus _sinusCs;

    [SerializeField] private Level[] _levels;

    private Level _currentLevel;
    private int _currentLevelIndex = 0;
    private int _currentLevelSolvedTargets = 0;

    private GameObject _instanciatedBallObject;
    private TriangleController _playerCS;
    void Start()
    {
        _playerCS = _playerObject.GetComponent<TriangleController>();
        InitNewLevel();
    }

    private void InitNewLevel()
    {
        InstanciateBallAtSpawnPoint();
        _currentLevelIndex++;
        _currentLevel = _levels[_currentLevelIndex - 1];
        _currentLevelSolvedTargets = 0;
        _sinusCs.PlayClip(_currentLevelIndex);
        GameManager.Instance.ResetPlayerPosition(false);
        GameManager.Instance.SetPlayerInactive();
    }

    public void StartGameAction()
    {
        GameManager.Instance.SetPlayerActive();
    }

    private void InstanciateBallAtSpawnPoint()
    {
        if (_ballObject != null && _ballSpawnPosition != null)
        {
            _instanciatedBallObject = Instantiate(_ballObject, _ballSpawnPosition.position, Quaternion.identity, transform);
        }
    }

    public void ValidatePuzzle(Target target, ShapeStateEnum targetShape, TrianglePointingDirections pointingDirection)
    {
        if (_playerShapeStateCS.CurrentStateEnum == targetShape && _playerCS.currentPointingDirection == pointingDirection)
        {
            GameManager.Instance.ResetPlayerPosition(false);
            target.LockTriangle();
            _currentLevelSolvedTargets++;
            if(_currentLevelSolvedTargets >= _currentLevel.TargetAmount)
            {
                ReleaseTheBall();
                GameManager.Instance.SetPlayerInactive();
            }
        }
        else 
        {
            GameManager.Instance.ResetPlayerPosition(true);
        }
    }

    public void ReleaseTheBall()
    {
        var ballController = _instanciatedBallObject.AddComponent<BallController>();
        ballController.levelManager = this;

    }

    public void CompleteLevel()
    {
        var ballcontrollerCS = _instanciatedBallObject.GetComponent<BallController>();
        if (ballcontrollerCS != null)
        {
            ballcontrollerCS.StopBall();
        }
    }

    public void MoveToNextLevel()
    {
        if(_currentLevelIndex < _levels.Length)
        {
            _levelContainerCS.MoveLevels();
            InitNewLevel();
        }
        else 
        {
            SceneLoader.Instance.LoadSceneEnd();
        }
    }
}