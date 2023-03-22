using UnityEngine;
using Platformer.Model;

namespace Platformer.Mechanics
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField] private LayerMask _ballLayer;
        // [SerializeField] private LayerMask _leverLayer;
        [SerializeField] private LayerMask _objectiveLayer;

        [SerializeField] private GameObject _playerObject;
        [SerializeField] private GameObject _ballObject;
        // [SerializeField] private GameObject _leverObject;
        [SerializeField] private GameObject _objectiveObject;
        [SerializeField] private GameObject _backwardsBarrier;

        [SerializeField] private Transform _playerSpawnPosition;
        [SerializeField] private Transform _ballSpawnPosition;
        // [SerializeField] private Transform _leverSpawnPosition;
        [SerializeField] private Transform _objectiveSpawnPosition;

        [SerializeField] private DeathZone _deathZoneCS;
        [SerializeField] private EndDoor _endDoorCS;
        [SerializeField] private ShapeStatesManager _playerShapeStateCS;
        [SerializeField] private CameraTransition _camTransitionCS;
        [SerializeField] private NextLevelHitbox _nextLevelHitboxCS;
        
        [SerializeField] private ShapeStateEnum _levelPuzzleShape;

        [SerializeField] private float _levelCenter;
        private GameObject _instanciatedBallObject;

        // private Lever _leverCS;
        private Objective _objectiveCS;

        private bool _ballIsReleased = false;

        void Start()
        {
            PlaceObjectcsInLevel();

            if(_backwardsBarrier != null)
            {
                _backwardsBarrier.SetActive(false);
            }
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

            // if (_leverObject != null && _leverSpawnPosition != null)
            // {
            //     var lever = Instantiate(_leverObject, _leverSpawnPosition.position, Quaternion.identity, transform);

            //     if (lever.GetComponent<Lever>() == null) 
            //         _leverCS = lever.AddComponent<Lever>();
            //     else 
            //         _leverCS = lever.GetComponent<Lever>();

            //     _leverCS.parentLevel = this;
            // }

            if (_objectiveObject != null && _objectiveSpawnPosition != null)
            {
                var objective = Instantiate(_objectiveObject, _objectiveSpawnPosition.position, Quaternion.identity, transform);

                if (objective.GetComponent<Objective>() == null) 
                    _objectiveCS = objective.AddComponent<Objective>();
                else 
                    _objectiveCS = objective.GetComponent<Objective>();
                    
                _objectiveCS.parentLevel = this;
            }

            if(_deathZoneCS != null)
            {
                _deathZoneCS.parentLevel = this;
            }
            if(_nextLevelHitboxCS != null)
            {
                _nextLevelHitboxCS.parentLevel = this;
            }
        }

        public void ValidatePuzzle()
        {
            if(_playerShapeStateCS.CurrentStateEnum == _levelPuzzleShape) ReleaseTheBall();
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
            if(ballcontrollerCS != null)
            {
                ballcontrollerCS.StopBall();
            }
            if(_endDoorCS != null)
            {
                _endDoorCS.OnLevelCompleted();            
            }
            if(_deathZoneCS != null)
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
            _camTransitionCS.StartTransition(_levelCenter + PlatformerModel.ModelInstance.LevelLenght);
            _backwardsBarrier.SetActive(true);
            this.enabled = false;
        }

        public LayerMask PlayerLayer => _playerLayer;
        public LayerMask BallLayer => _ballLayer;
        // public LayerMask LeverLayer => _leverLayer;
        public LayerMask ObjectiveLayer => _objectiveLayer;

        public bool BallIsReleased => _ballIsReleased;
    }
}