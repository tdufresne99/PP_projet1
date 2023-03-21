using UnityEngine;

namespace Platformer.Mechanics
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Objective : MonoBehaviour
    {
        public Level parentLevel;

        private BoxCollider2D _boxCollider;

        void Start()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == parentLevel.BallLayer.value)
            {
                Debug.Log("Level completed! Well done!");
            }
        }
    }
}