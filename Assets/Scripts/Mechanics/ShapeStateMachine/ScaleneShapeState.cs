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
    }

    public override void UpdateState(ShapeStatesManager manager)
    {

    }
}