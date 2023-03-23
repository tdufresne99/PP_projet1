using UnityEngine;

public class RightShapeState : ShapeStates
{
    public override void ExitState(ShapeStatesManager manager)
    {
        manager.rightGO.SetActive(false);
    }
    public override void InitState(ShapeStatesManager manager)
    {
        manager.rightGO.SetActive(true);
        manager.rightGO.transform.Rotate(Vector3.zero, Space.World);

    }

    public override void UpdateState(ShapeStatesManager manager)
    {

    }
}