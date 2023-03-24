using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    [SerializeField] private float _fallingSpeed = 0.02f;
    [SerializeField] private float _horizontalSpeed = 0.02f;
    [SerializeField] private GameObject _part;
    private float _direction;
    private float _rotation;
    private bool _controlEnabled = true;
    public TrianglePointingDirections currentPointingDirection;

    private void Start()
    {
        currentPointingDirection = TrianglePointingDirections.Up;
    }

    private void Update()
    {
        if(_controlEnabled == false) return;

        _direction = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(Vector3.forward * 90f, Space.World);
            SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.PlayerRotateSFX);

            switch (currentPointingDirection)
            {
                case TrianglePointingDirections.Up:
                    currentPointingDirection = TrianglePointingDirections.Left;
                    break;
                case TrianglePointingDirections.Left:
                    currentPointingDirection = TrianglePointingDirections.Down;
                    break;
                case TrianglePointingDirections.Down:
                    currentPointingDirection = TrianglePointingDirections.Right;
                    break;
                case TrianglePointingDirections.Right:
                    currentPointingDirection = TrianglePointingDirections.Up;
                    break;
                default:
                    break;
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            transform.Rotate(Vector3.back * 90f, Space.World);
            SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.PlayerRotateSFX);

            switch (currentPointingDirection)
            {
                case TrianglePointingDirections.Up:
                    currentPointingDirection = TrianglePointingDirections.Right;
                    break;
                case TrianglePointingDirections.Right:
                    currentPointingDirection = TrianglePointingDirections.Down;
                    break;
                case TrianglePointingDirections.Down:
                    currentPointingDirection = TrianglePointingDirections.Left;
                    break;
                case TrianglePointingDirections.Left:
                    currentPointingDirection = TrianglePointingDirections.Up;
                    break;
                default:
                    break;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * _fallingSpeed, Space.World);
       
        if(_controlEnabled == false) return;

        transform.Translate(Vector3.right * _direction * _horizontalSpeed, Space.World);

        if(transform.position.y < Model.Instance.BottomLimit) ResetPlayerPosition(true);
        if(transform.position.x > Model.Instance.RightLimit) transform.position = new Vector3(Model.Instance.RightLimit, transform.position.y, transform.position.z);
        else if(transform.position.x < Model.Instance.LeftLimit) transform.position = new Vector3(Model.Instance.LeftLimit, transform.position.y, transform.position.z);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Model.Instance.ObjectiveLayer == (1 << other.gameObject.layer))
        {
            Debug.Log("objective touched");
        }
    }

    public void ResetPlayerPosition(bool instanciatePart)
    {
        if(instanciatePart) 
        {
            Instantiate(_part, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.TriangleFailSFX);
        }
        transform.position = GameManager.Instance.PlayerSpawnPosition.position;
    }

    public bool ControlEnabled
    {
        get => _controlEnabled;
        set => _controlEnabled = value;
    }
}