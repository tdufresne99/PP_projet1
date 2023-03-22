using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class ShapeStatesManager : MonoBehaviour
{
    private ShapeStates _currentState;
    public ShapeStates acute = new AcuteShapeState();
    public ShapeStates obtuse = new ObtuseShapeState();
    public ShapeStates right = new RightShapeState();
    public ShapeStates isosceles = new IsoscelesShapeState();
    public ShapeStates equilateral = new EquilateralShapeState();
    public ShapeStates scalene = new ScaleneShapeState();

    public GameObject acuteGO;
    public GameObject obtuseGO;
    public GameObject rightGO;
    public GameObject isoscelesGO;
    public GameObject equilateralGO;
    public GameObject scaleneGO;

    private bool _canChangeState = true;
    private float _stateChangeDelay = 0.3f;

    void Start()
    {
        ExecuteChangeState(acute, ShapeStateEnum.Acute);
    }

    public void ExecuteChangeState(ShapeStates state, ShapeStateEnum shapeStateEnum)
    {
        _currentState = state;
        CurrentStateEnum = shapeStateEnum;
        _currentState.InitState(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _canChangeState)
        {
            PrepareChangeState(acute, ShapeStateEnum.Acute);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _canChangeState)
        {
            PrepareChangeState(obtuse, ShapeStateEnum.Obtuse);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && _canChangeState)
        {
            PrepareChangeState(right, ShapeStateEnum.Right);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && _canChangeState)
        {
            PrepareChangeState(isosceles, ShapeStateEnum.Isosceles);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && _canChangeState)
        {
            PrepareChangeState(equilateral, ShapeStateEnum.Equilateral);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && _canChangeState)
        {
            PrepareChangeState(scalene, ShapeStateEnum.Scalene);
        }

        _currentState.UpdateState(this);
    }

    private void PrepareChangeState(ShapeStates state, ShapeStateEnum shapeStateEnum)
    {
        _currentState.ExitState(this);
        ExecuteChangeState(state, shapeStateEnum);
        _canChangeState = false;
        Invoke("EnableChangeState", _stateChangeDelay);
    }

    private void EnableChangeState()
    {
        _canChangeState = true;
    }
    

    public ShapeStateEnum CurrentStateEnum;
}
