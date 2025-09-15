using UnityEngine;

public class Right: ICommand
{
    private playerBehavior _controller;

    public Right(playerBehavior controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.TurnRight();
    }
}
