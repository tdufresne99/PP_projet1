using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class DynamicObject : MonoBehaviour
    {
        public float minGroundNormalY = .65f;
        public float gravityModifier = 1f;
        public Vector2 velocity;
        public bool IsGrounded { get; private set; }
        protected Vector2 targetVelocity;
        protected float targetRotation;
        protected Vector2 groundNormal;
        protected Rigidbody2D body;
        protected ContactFilter2D contactFilter;
        protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
        protected const float minMoveDistance = 0.001f;
        protected const float shellRadius = 0.01f;

        public void Bounce(float value)
        {
            velocity.y = value;
        }

        public void Bounce(Vector2 dir)
        {
            velocity.y = dir.y;
            velocity.x = dir.x;
        }

        public void Teleport(Vector3 position)
        {
            body.position = position;
            velocity *= 0;
            body.velocity *= 0;
        }

        protected virtual void OnEnable()
        {
            body = GetComponent<Rigidbody2D>();
        }

        protected virtual void OnDisable()
        {
            
        }

        protected virtual void Start()
        {
            contactFilter.useTriggers = false;
            contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
            contactFilter.useLayerMask = true;
        }

        protected virtual void Update()
        {
            targetVelocity = Vector2.zero;
            ComputeVelocity();

            targetRotation = 0;
            ComputeRotation();
        }

        protected virtual void ComputeVelocity()
        {

        }

        protected virtual void ComputeRotation()
        {

        }

        protected virtual void FixedUpdate()
        {
            if (velocity.y < 0)
                velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
            else
                velocity += Physics2D.gravity * Time.deltaTime;

            velocity.x = targetVelocity.x;

            IsGrounded = false;

            var deltaPosition = velocity * Time.deltaTime;

            var moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

            var move = moveAlongGround * deltaPosition.x;

            PerformMovement(move, false);

            move = Vector2.up * deltaPosition.y;

            PerformMovement(move, true);

        }

        void PerformMovement(Vector2 move, bool yMovement)
        {
            var distance = move.magnitude;

            if (distance > minMoveDistance)
            {
                var count = body.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
                for (var i = 0; i < count; i++)
                {
                    var currentNormal = hitBuffer[i].normal;

                    if (currentNormal.y > minGroundNormalY)
                    {
                        IsGrounded = true;

                        if (yMovement)
                        {
                            groundNormal = currentNormal;
                            currentNormal.x = 0;
                        }
                    }
                    if (IsGrounded)
                    {

                        var projection = Vector2.Dot(velocity, currentNormal);
                        if (projection < 0)
                        {

                            velocity = velocity - projection * currentNormal;
                        }
                    }
                    else
                    {

                        velocity.x *= 0;
                        velocity.y = Mathf.Min(velocity.y, 0);
                    }
                    
                    var modifiedDistance = hitBuffer[i].distance - shellRadius;
                    distance = modifiedDistance < distance ? modifiedDistance : distance;
                }
            }

            body.rotation = body.rotation + targetRotation;

            body.position = body.position + move.normalized * distance;
        }
    }
}
