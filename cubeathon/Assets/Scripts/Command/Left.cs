using UnityEngine;

public class Left: ICommand
{
    private playerBehavior _controller;

    public Left(playerBehavior controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.TurnLeft();
    }
}
