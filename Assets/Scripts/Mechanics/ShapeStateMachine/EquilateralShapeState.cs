using UnityEngine;

public class EquilateralShapeState : ShapeStates
{
    public override void ExitState(ShapeStatesManager manager)
    {
        manager.equilateralGO.SetActive(false);
    }
    public override void InitState(ShapeStatesManager manager)
    {
        manager.equilateralGO.SetActive(true);
        manager.equilateralGO.transform.Rotate(Vector3.zero, Space.World);
    }

    public override void UpdateState(ShapeStatesManager manager)
    {

    }
}