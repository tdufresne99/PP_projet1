using System.Collections;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class CameraTransition : MonoBehaviour
    {
        private float _transitionSpeed = 0.5f;
        public void StartTransition(float pos)
        {
            StartCoroutine(CoroutineBallEsacapeAnim(pos));
        }
        private IEnumerator CoroutineBallEsacapeAnim(float pos)
        {
            while (transform.position.x < pos)
            {
                transform.Translate(Vector3.right * _transitionSpeed, Space.World);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}