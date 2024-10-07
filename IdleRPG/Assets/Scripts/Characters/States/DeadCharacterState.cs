using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public abstract class DeadCharacterState : StateMachineBehaviourEvents
{
    bool _endAnimation;
    public override void Init(Character character)
    {
        base.Init(character);
        timeAnimationStat = new Stat(new Modifier(1500));
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _endAnimation = false;
        character.timerBar.SetActive(false);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (stateInfo.normalizedTime >= 1f && !_endAnimation)
        {
            character.StartCoroutine(End());
            _endAnimation = true;
        }
    }


    protected abstract IEnumerator End();
}

