using System;
using UnityEngine;

public class DeferredAction : StateMachineBehaviourEvents
{
    public Action Action { get; set; }

    public override void Init(Character character)
    {
        base.Init(character);
        timeAnimationStat = new Stat(new Modifier(1500));
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        character.timerBar.SetActive(true,0);
        character.timerBar.SetColor(Color.grey);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        character.timerBar.SetProgress(stateInfo.normalizedTime);
        if (stateInfo.normalizedTime >= 1) 
        {
            Action?.Invoke();
            animator.SetBool("DeferredAction", false);
            character.animator.Play("Base Layer.Preparation", 0, character.preparatoryState.previousNormalizedTime);
        }
    }
}
