using UnityEngine;

public class HAttack: ICommand
{
    private HomingAttack _controller;

    public HAttack(HomingAttack controller)
    {
        _controller = controller;
    }

    public void Execute()
    {
        _controller.Attack();
    }
}
