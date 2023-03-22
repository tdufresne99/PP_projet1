using Platformer.Mechanics;
using UnityEngine;

namespace Platformer.Model
{
    public class PlatformerModel : MonoBehaviour
    {
        private float _yMax = 6f;
        private static PlatformerModel _modelInstance;
        public static PlatformerModel ModelInstance => _modelInstance;
        public float LevelLenght = 18f;
        
        void Awake()
        {
            if(_modelInstance == null) _modelInstance = this;
            else Destroy(this);

            player.model = this;
        }
        public PlayerController player;
        public ShapeStatesManager shapeStatesManager;
        public float JumpModifier = 1.5f;
        public float JumpDeceleration = 0.5f;
        public float YMax => _yMax;
    }
}