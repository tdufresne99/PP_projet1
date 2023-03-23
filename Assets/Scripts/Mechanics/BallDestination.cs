using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BallDestination : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    private BoxCollider2D _boxCollider;

    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Model.Instance.BallLayer == (1 << other.gameObject.layer))
        {
            levelManager.CompleteLevel();
        }
    }
}