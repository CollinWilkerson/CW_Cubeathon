using UnityEngine;

public class Jump:ICommand
{
    private playerBehavior _controller;

    public Jump(playerBehavior controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.Jump();
    }
}
