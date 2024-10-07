using System.Collections;
using UnityEngine;


public class DeadEnemyState : DeadCharacterState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        character.healthBar.SetActive(false);
    }
    protected override IEnumerator End()
    {
        var second = new WaitForSeconds(0.5f);
        yield return second;
        GameObject.Destroy(character.gameObject);
    }
}
