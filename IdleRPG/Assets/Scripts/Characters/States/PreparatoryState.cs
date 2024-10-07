using UnityEngine;

public class PreparatoryState : StateMachineBehaviourEvents
{
    public override void Init(Character character)
    {
        base.Init(character);
    }

    public float previousNormalizedTime { get; private set; }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        character.timerBar.SetActive(true, 0);
        character.timerBar.SetColor(Color.green);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        character.timerBar.SetProgress(stateInfo.normalizedTime);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        previousNormalizedTime = stateInfo.normalizedTime; 
    }


}

