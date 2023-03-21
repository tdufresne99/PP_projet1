using UnityEngine;

public class IsoscelesShapeState : ShapeStates
{
    public override void ExitState(ShapeStatesManager manager)
    {
        manager.isoscelesGO.SetActive(false);
    }
    public override void InitState(ShapeStatesManager manager)
    {
        manager.isoscelesGO.SetActive(true);
    }

    public override void UpdateState(ShapeStatesManager manager)
    {

    }
}