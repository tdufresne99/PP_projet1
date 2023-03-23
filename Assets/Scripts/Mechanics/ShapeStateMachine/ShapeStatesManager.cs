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

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha1) && _canChangeState)
        // {
        //     PrepareChangeState(acute, ShapeStateEnum.Acute);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha2) && _canChangeState)
        // {
        //     PrepareChangeState(obtuse, ShapeStateEnum.Obtuse);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha3) && _canChangeState)
        // {
        //     PrepareChangeState(right, ShapeStateEnum.Right);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha4) && _canChangeState)
        // {
        //     PrepareChangeState(isosceles, ShapeStateEnum.Isosceles);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha5) && _canChangeState)
        // {
        //     PrepareChangeState(equilateral, ShapeStateEnum.Equilateral);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha6) && _canChangeState)
        // {
        //     PrepareChangeState(scalene, ShapeStateEnum.Scalene);
        // }

        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            switch (CurrentStateEnum)
            {
                case ShapeStateEnum.Acute:
                    PrepareChangeState(obtuse, ShapeStateEnum.Obtuse);
                    break;
                case ShapeStateEnum.Obtuse:
                    PrepareChangeState(right, ShapeStateEnum.Right);
                    break;
                case ShapeStateEnum.Right:
                    PrepareChangeState(equilateral, ShapeStateEnum.Equilateral);
                    break;
                case ShapeStateEnum.Equilateral:
                    PrepareChangeState(isosceles, ShapeStateEnum.Isosceles);
                    break;
                case ShapeStateEnum.Isosceles:
                    PrepareChangeState(scalene, ShapeStateEnum.Scalene);
                    break;
                case ShapeStateEnum.Scalene:
                    PrepareChangeState(acute, ShapeStateEnum.Acute);
                    break;
                default:
                    break;
            }
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

    public void ExecuteChangeState(ShapeStates state, ShapeStateEnum shapeStateEnum)
    {
        _currentState = state;
        SoundManager.Instance.PlaySoundOneShot(SoundManager.Instance.PlayerShapeShiftSFX);
        CurrentStateEnum = shapeStateEnum;
        _currentState.InitState(this);
    }

    private void EnableChangeState()
    {
        _canChangeState = true;
    }
    

    public ShapeStateEnum CurrentStateEnum;
}
