using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Model
{
    public class PlatformerModel : MonoBehaviour
    {
        public Cinemachine.CinemachineVirtualCamera virtualCamera;
        public PlayerController player;
        public Transform spawnPoint;
        public float jumpModifier = 1.5f;
        public float jumpDeceleration = 0.5f;
        private static PlatformerModel _modelInstance;
        public static PlatformerModel ModelInstance => _modelInstance;
        
        void Awake()
        {
            if(_modelInstance == null) _modelInstance = this;
            else Destroy(this);

            player.model = this;
        }

        
    }
}