using UnityEngine;

public class AttackingState : StateMachineBehaviourEvents
{
    [SerializeField] AttackType _attackType;
    public AttackType attackType => _attackType;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        character.timerBar.SetActive(true,0);
        character.timerBar.SetColor(Color.red);
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        character.timerBar.SetProgress(stateInfo.normalizedTime);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        character.OnAttack?.Invoke(character);
         
    }

}

