using UnityEngine;

public class ScaleneShapeState : ShapeStates
{
    public override void ExitState(ShapeStatesManager manager)
    {
        manager.scaleneGO.SetActive(false);
    }
  public override void InitState(ShapeStatesManager manager)
    {
        manager.scaleneGO.SetActive(true);
        manager.scaleneGO.transform.Rotate(Vector3.zero, Space.World);
    }

    public override void UpdateState(ShapeStatesManager manager)
    {

    }
}