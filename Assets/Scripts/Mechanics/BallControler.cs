using System.Collections;
using System.Collections.Generic;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class BallController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private float _speed = 2f;

        void Start()
        {
            _rigidbody = gameObject.AddComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            _rigidbody.AddForce(Vector2.right * _speed, ForceMode2D.Force);
        }
    }
}