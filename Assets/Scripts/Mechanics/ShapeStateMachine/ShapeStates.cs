using UnityEngine;

public abstract class ShapeStates
{
    public abstract void ExitState(ShapeStatesManager manager);
    public abstract void InitState(ShapeStatesManager manager);
    public abstract void UpdateState(ShapeStatesManager manager);
}
