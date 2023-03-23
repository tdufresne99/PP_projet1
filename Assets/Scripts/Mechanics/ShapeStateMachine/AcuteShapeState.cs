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
        manager.acuteGO.transform.Rotate(Vector3.zero, Space.World);
    }

    public override void UpdateState(ShapeStatesManager manager)
    {

    }
}