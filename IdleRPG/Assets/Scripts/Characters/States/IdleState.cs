using UnityEngine;

public class IdleState : StateMachineBehaviourEvents
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("DeferredAction", false);
        animator.SetBool("Dead", false);    
        character.timerBar.SetActive(false,0);
    }

}

