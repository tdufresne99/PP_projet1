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

        private float _maxVelocity = 2f;

        void Start()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_maxVelocity, _rigidbody.velocity.y);
        }

        public float Speed { get => _speed; set => _speed = value; }
    }
}