using UnityEngine;

public class BottomLimit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Model.Instance.PlayerLayer == (1 << other.gameObject.layer))
        {
            GameManager.Instance.ResetPlayerPosition();
        }
    }
}