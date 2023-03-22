using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    [SerializeField] private float _fallingSpeed = 0.02f;
    [SerializeField] private float _horizontalSpeed = 0.02f;
    [SerializeField] private float _rotationSpeed = 0.02f;
    private float _direction;
    private float _rotation;
    private bool _controlEnabled = true;

    private

    void Start()
    {

    }

    void Update()
    {
        if(_controlEnabled == false) return;

        _direction = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire1"))
        {
            transform.Rotate(Vector3.forward * 90f, Space.World);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            transform.Rotate(Vector3.back * 90f, Space.World);

        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.down * _fallingSpeed, Space.World);
       
        if(_controlEnabled == false) return;

        transform.Translate(Vector3.right * _direction * _horizontalSpeed, Space.World);
        
    }

    public void ResetPlayerPosition()
    {
        transform.position = GameManager.Instance.PlayerSpawnPosition.position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Model.Instance.ObjectiveLayer == (1 << other.gameObject.layer))
        {
            Debug.Log("objective touched");
        }

    }

    public bool ControlEnabled
    {
        get => _controlEnabled;
        set => _controlEnabled = value;
    }
}