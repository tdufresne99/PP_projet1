using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class PlayerController : DynamicObject
    {
        public float maxSpeed = 7f;

        public float jumpTakeOffSpeed = 7f;
        public float rotationSpeed = 3f;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        private AudioSource _audioSource;
        private Collider2D _collider2d;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        public bool controlEnabled = true;
        Vector2 move;
        float rotate;
        bool jump;
        public Model model;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _collider2d = GetComponent<Collider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                }

                if(Input.GetButton("Fire1")) 
                {
                    rotate = 1;
                }
                else if(Input.GetButton("Fire2"))
                {
                    rotate = -1;
                }
                else
                {
                    rotate = 0;
                }
            }
            else
            {
                move.x = 0;
                rotate = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.JumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.JumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                _spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                _spriteRenderer.flipX = true;

            // _animator.SetBool("grounded", IsGrounded);
            // _animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        protected override void ComputeRotation()
        {
            if(jumpState == JumpState.InFlight)
                targetRotation = rotate * rotationSpeed;

        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}