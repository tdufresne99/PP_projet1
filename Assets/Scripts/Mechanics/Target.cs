using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Target : MonoBehaviour
{
    [SerializeField] private ShapeStateEnum _levelPuzzleShape;
    [SerializeField] private TrianglePointingDirections _pointingDirection;
    [SerializeField] private LevelManager _levelManager;

    void Start()
    {
        var boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Model.Instance.PlayerLayer == (1 << other.gameObject.layer))
        {
            _levelManager.ValidatePuzzle(this, _levelPuzzleShape, _pointingDirection);
        }
    }

    public void LockTriangle()
    {
        var triangle = transform.GetChild(0);
        if(triangle != null)
        {
            triangle.gameObject.SetActive(true);
        }
        Destroy(this);
    }
}