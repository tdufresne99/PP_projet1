using System.Collections;
using System.Collections.Generic;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private float _speed = 2f;
        private float _escapeSpeed = 1f;
        private float _velocityX = 2f;
        private bool _isStopped = false;

        void Start()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            _rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }

        void FixedUpdate()
        {
            if(_isStopped == false) _rigidbody.velocity = new Vector2(_velocityX, _rigidbody.velocity.y);
        }

        public void StopBall()
        {
            _isStopped = true;
            StartCoroutine(CoroutineBallEsacapeAnim());
        }

        private IEnumerator CoroutineBallEsacapeAnim()
        {
            _rigidbody.velocity = Vector2.zero;
            while (transform.position.y < PlatformerModel.ModelInstance.YMax)
            {
                _rigidbody.AddForce(Vector2.up * _escapeSpeed, ForceMode2D.Impulse);
                yield return new WaitForFixedUpdate();
            }
            Destroy(gameObject);
        }

        public float Speed { get => _speed; set => _speed = value; }
    }
}