using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    public LevelManager levelManager;
    private Rigidbody2D _rigidbody;
    private float _speed = 2f;
    private float _escapeSpeed = 1f;
    private float _velocityX = 2f;
    private bool _isStopped = true;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void FixedUpdate()
    {
        if (_isStopped == false) _rigidbody.velocity = new Vector2(_velocityX, _rigidbody.velocity.y);
    }

    public void StopBall()
    {
        _isStopped = true;
        StartCoroutine(CoroutineBallEsacapeAnim());
    }

    private IEnumerator CoroutineBallEsacapeAnim()
    {
        SoundManager.Instance.StopSoundOnLoop();
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.BallPulledSFX);
        while (transform.position.y < Model.Instance.YMax)
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            _rigidbody.AddForce(Vector2.up * _escapeSpeed, ForceMode2D.Impulse);
            yield return new WaitForFixedUpdate();
        }
        levelManager.MoveToNextLevel();
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (Model.Instance.GroundLayer == (1 << other.gameObject.layer) && _isStopped)
        {
            _isStopped = false;
            SoundManager.Instance.PlaySoundOnLoop(SoundManager.Instance.BallRollingSFX);
        }
    }

    public float Speed { get => _speed; set => _speed = value; }
}