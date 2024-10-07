using UnityEngine;

public class IdleLocationState : State<GameLoop>
{
    public IdleLocationState(GameLoop _this, StateMachine<GameLoop> stateMachine) : base(_this, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (_this.enemy != null)
        {
            GameObject.Destroy(_this.enemy.gameObject); 
        }
    }
}
