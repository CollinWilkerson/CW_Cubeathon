using UnityEngine;

public class RightUp: ICommand
{
    private playerBehavior _controller;

    public RightUp(playerBehavior controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.StopTurnRight();
    }
}
