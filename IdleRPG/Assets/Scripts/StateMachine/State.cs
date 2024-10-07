using System;

public abstract class State<TypeObject> : IState
{
    protected TypeObject _this;
    protected StateMachine<TypeObject> stateMachine;

    public Action<TypeObject> OnEnter;
    public Action<TypeObject> OnExit;

    protected State(TypeObject _this, StateMachine<TypeObject> stateMachine)
    {
        this._this = _this;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        OnEnter?.Invoke(_this);
    }
    public virtual void Exit()
    {
        OnExit?.Invoke(_this);
    }

    public bool isCurrentState => this == stateMachine.CurrentState;
}

