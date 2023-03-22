using UnityEngine;

namespace Platformer.Mechanics
{
    public class EndDoor : MonoBehaviour
    {
        private Animator _anim;

        void Start()
        {
            _anim = GetComponent<Animator>();
        }
        
        public void OnLevelCompleted()
        {
            Debug.Log("Level completed");
            _anim.SetTrigger("unlock");
        }

        public void OnNextLevelEntered()
        {
            Debug.Log("Next level entered");
            _anim.SetTrigger("lock");
        }
    }
}