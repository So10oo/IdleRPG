using System.Collections;
using UnityEngine;

public class DeadPlayerState : DeadCharacterState
{
    protected override IEnumerator End()
    {
        var second = new WaitForSeconds(1);
        yield return second;
        character.characteristics.Health.AddCurrentValue(5);
        character.animator.Play("Idle");
    }

}
