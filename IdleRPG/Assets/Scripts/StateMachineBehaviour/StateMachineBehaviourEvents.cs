using System;
using UnityEngine;

public class StateMachineBehaviourEvents : StateMachineBehaviour
{
    public Action<Character, Animator, AnimatorStateInfo> OnEnter;
    public Action<Character, Animator, AnimatorStateInfo> OnUpdate;
    public Action<Character, Animator, AnimatorStateInfo> OnExit;

    public Character character { private set; get; }
    public Stat timeAnimationStat { protected get; set; }

    float timeAnimation => timeAnimationStat.Value / 1000f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log($"{character.name}:Enter - {this.GetType().ToString()} - {stateInfo.normalizedTime.ToString("N2")} - {Time.time.ToString("N2")}");
        animator.speed = animator.speed * stateInfo.length / timeAnimation;
        OnEnter?.Invoke(character, animator, stateInfo);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnUpdate?.Invoke(character, animator, stateInfo);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log($"{character.name}:OnExit - {this.GetType().ToString()} - {stateInfo.normalizedTime.ToString("N2")}- {Time.time.ToString("N2")}");
        OnExit?.Invoke(character, animator, stateInfo); 
    }

    public virtual void Init(Character character)
    {
        this.character = character;
        timeAnimationStat = new Stat(new Modifier(1000));
    }
}
