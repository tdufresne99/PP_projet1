using UnityEngine;

namespace Platformer.Mechanics
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class DeathZone : MonoBehaviour
    {
        public Level parentLevel;

        
        void Start()
        {
            var boxCollider = GetComponent<BoxCollider2D>();
            boxCollider.isTrigger = true;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(parentLevel.BallLayer == (1 << other.gameObject.layer))
            {
                parentLevel.ResetLevel();
            }
        }
    }
}