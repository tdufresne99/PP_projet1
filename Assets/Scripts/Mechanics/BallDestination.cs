using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BallDestination : MonoBehaviour
{
    public Level parentLevel;

    private BoxCollider2D _boxCollider;

    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (parentLevel.BallLayer == (1 << other.gameObject.layer))
        {
            parentLevel.CompleteLevel();
        }
    }
}