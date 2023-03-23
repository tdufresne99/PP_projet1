using UnityEngine;

public class ObtuseShapeState : ShapeStates
{
    public override void ExitState(ShapeStatesManager manager)
    {
        manager.obtuseGO.SetActive(false);
    }
    public override void InitState(ShapeStatesManager manager)
    {
        manager.obtuseGO.SetActive(true);
        manager.obtuseGO.transform.Rotate(Vector3.zero, Space.World);

    }

    public override void UpdateState(ShapeStatesManager manager)
    {
        
    }
}