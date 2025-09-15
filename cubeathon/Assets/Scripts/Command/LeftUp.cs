using UnityEngine;

public class LeftUp: ICommand
{
    private playerBehavior _controller;

    public LeftUp(playerBehavior controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.StopTurnLeft();
    }
}
