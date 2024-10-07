using UnityEngine;

public class BattleState : State<GameLoop>
{
    Player player;
    Enemy enemy;

    public BattleState(GameLoop _this, StateMachine<GameLoop> stateMachine) : base(_this, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player = _this.player;
        enemy = _this.enemy;

        player.animator.Play("Preparation");
        enemy.animator.Play("Preparation");

        player.OnAttack += LogicDealingDamage;
        enemy.OnAttack += LogicDealingDamage;
        player.characteristics.Health.OnCurrentValueChange += LogicDeathPlayer;
        enemy.characteristics.Health.OnCurrentValueChange += LogicDeathEnemy;
    }

    public override void Exit()
    {
        base.Exit();

        player.animator.SetTrigger("Idle");
        enemy.animator.SetTrigger("Idle");

        player.OnAttack -= LogicDealingDamage;
        player.characteristics.Health.OnCurrentValueChange -= LogicDeathPlayer;
        if (enemy != null)
        {
            enemy.characteristics.Health.OnCurrentValueChange -= LogicDeathEnemy;
            enemy.OnAttack -= LogicDealingDamage;
            //GameObject.Destroy(enemy.gameObject);
        }
    }

    void LogicDealingDamage(Character attacker)
    {
        Character attacked = attacker == player ? enemy : player;
        var attackerAttack = attacker.characteristics.AttackPower.Value;
        var attackedArmor = attacked.characteristics.Armor.Value;
        var damage = Mathf.Clamp(attackerAttack - attackedArmor, 0, attackerAttack);
        attacked.characteristics.Health.SubCurrentValue(damage);
    }

    void LogicDeathPlayer(int hp)
    {
        if (hp <= 0)
        {
            player.animator.SetBool("Dead", true);
            stateMachine.ChangeState(_this.idleState);
        }
    }

    void LogicDeathEnemy(int hp)
    {
        if (hp <= 0)
        {
            enemy.animator.SetBool("Dead", true);
            stateMachine.ChangeState(_this.searchOpponentState);
        }
    }

}

