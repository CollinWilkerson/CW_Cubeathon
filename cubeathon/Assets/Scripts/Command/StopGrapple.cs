using UnityEngine;

public class StopGrapple: ICommand
{
    private playerBehavior _controller;

    public StopGrapple(playerBehavior controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.TurnRight();
    }
}
