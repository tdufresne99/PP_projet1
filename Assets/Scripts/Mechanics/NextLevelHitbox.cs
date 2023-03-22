using UnityEngine;

namespace Platformer.Mechanics
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class NextLevelHitbox : MonoBehaviour
    {
        public Level parentLevel;

        private BoxCollider2D _boxCollider;

        void Start()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(parentLevel.PlayerLayer == (1 << other.gameObject.layer))
            {
                Debug.Log("Next level entered");
                parentLevel.OnNextLevelEntered();
                Destroy(gameObject);
            }
        }
    }
}