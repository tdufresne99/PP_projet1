using System.Collections;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    private float _transitionSpeed = 0.5f;
    public void MoveLevels()
    {
        StartCoroutine(CoroutineMoveLevels());
    }

    private IEnumerator CoroutineMoveLevels()
    {
        var destination = transform.position.x - 18f;
        while(transform.position.x > destination)
        {
            transform.Translate(Vector3.left * _transitionSpeed);
            yield return new WaitForFixedUpdate();
        }
    }
}