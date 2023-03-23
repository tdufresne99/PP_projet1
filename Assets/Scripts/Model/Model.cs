using Platformer.Mechanics;
using UnityEngine;
public class Model : MonoBehaviour
{
    private float _yMax = 6f;
    private static Model _instance;
    public static Model Instance => _instance;
    public float LevelLenght = 18f;

    void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);
    }

    public float BottomLimit = -5f;
    public float RightLimit = 6f;
    public float LeftLimit = -6f;
    public ShapeStatesManager shapeStatesManager;
    public float JumpModifier = 1.5f;
    public float JumpDeceleration = 0.5f;
    public float YMax => _yMax;

    public LayerMask PlayerLayer;
    public LayerMask BallLayer;
    public LayerMask ObjectiveLayer;
    public LayerMask GroundLayer;
}