using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Target : MonoBehaviour
{
    public Level parentLevel;
    public TrianglePointingDirections pointingDirection;

    void Start()
    {
        var boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (parentLevel.PlayerLayer == (1 << other.gameObject.layer))
        {
            parentLevel.ValidatePuzzle();
        }
    }

    public void LockTriangle()
    {
        var triangle = transform.GetChild(0);
        if(triangle != null)
        {
            triangle.gameObject.SetActive(true);
        }
    }
}