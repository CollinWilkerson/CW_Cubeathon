using UnityEngine;

//this wont work unless i do some major refactoring
public class StartGrapple: ICommand
{
    private playerBehavior _controller;

    public StartGrapple(playerBehavior controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.TurnRight();
    }
}
