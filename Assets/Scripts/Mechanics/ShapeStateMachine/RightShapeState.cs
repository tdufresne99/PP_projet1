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
    }

    public override void UpdateState(ShapeStatesManager manager)
    {

    }
}