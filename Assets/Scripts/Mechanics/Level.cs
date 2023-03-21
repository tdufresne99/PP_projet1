using UnityEngine;

namespace Platformer.Mechanics
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject _playerObject;
        [SerializeField] private GameObject _ballObject;
        [SerializeField] private GameObject _leverObject;
        [SerializeField] private GameObject _objectiveObject;

        [SerializeField] private Transform _playerSpawnPosition;
        [SerializeField] private Transform _ballSpawnPosition;
        [SerializeField] private Transform _leverSpawnPosition;
        [SerializeField] private Transform _objectiveSpawnPosition;

        private BallController _ballCS;
        private Lever _leverCS;
        private Objective _objectiveCS;
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
                Instantiate(_ballObject, _ballSpawnPosition.position, Quaternion.identity, transform);
            }

            if (_leverObject != null && _leverSpawnPosition != null)
            {
                var lever = Instantiate(_leverObject, _leverSpawnPosition.position, Quaternion.identity, transform);

                if (lever.GetComponent<Lever>() == null) 
                    _leverCS = lever.AddComponent<Lever>();
                else 
                    _leverCS = lever.GetComponent<Lever>();

                _leverCS.parentLevel = this;
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
        }

        public void ReleaseTheBall()
        {

        }
    }
}