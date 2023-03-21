using UnityEngine;

public class AcuteShapeState : ShapeStates
{

    public override void ExitState(ShapeStatesManager manager)
    {
        manager.acuteGO.SetActive(false);
    }
    public override void InitState(ShapeStatesManager manager)
    {
        manager.acuteGO.SetActive(true);
    }

    public override void UpdateState(ShapeStatesManager manager)
    {
        
    }
}