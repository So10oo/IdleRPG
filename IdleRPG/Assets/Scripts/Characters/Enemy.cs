using System;

public class Enemy : Character
{
    public Action<Enemy> OnStart;

    protected override void AwakeMonoBehaviour()
    {
        base.AwakeMonoBehaviour();
        idleState = animator.GetBehaviour<IdleState>();
        preparatoryState = animator.GetBehaviour<PreparatoryState>();
        attackingState = animator.GetBehaviour<AttackingState>();
        deadState = animator.GetBehaviour<DeadCharacterState>();
        preparatoryState.Init(this);
        preparatoryState.timeAnimationStat = characteristics.PreparationTime;
        attackingState.Init(this);
        attackingState.timeAnimationStat = characteristics.AttackTime;
        deadState.Init(this);
        idleState.Init(this);
    }

    protected override void StartMonoBehaviour()
    {
        base.StartMonoBehaviour();
        OnStart?.Invoke(this);
    }
}