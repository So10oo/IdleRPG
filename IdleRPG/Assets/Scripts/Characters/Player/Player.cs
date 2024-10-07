using System.Linq;
using UnityEngine;
using Zenject;

public class Player : Character
{
    [Header("WeaponSlot")]
    [SerializeField] WeaponSlot weaponSlot;

    public DeferredAction deferredAction { get; private set; }

    GameLoop gameLoop;

    [Inject]
    void Construct(GameLoop gameLoop)
    {
        this.gameLoop = gameLoop;
        idleState = animator.GetBehaviour<IdleState>();
        preparatoryState = animator.GetBehaviour<PreparatoryState>();
        attackingState = animator.GetBehaviour<AttackingState>();
        deadState = animator.GetBehaviour<DeadCharacterState>();
        deferredAction = animator.GetBehaviour<DeferredAction>();
        preparatoryState.Init(this);
        preparatoryState.timeAnimationStat = characteristics.PreparationTime;

        attackingState.Init(this);
        attackingState.timeAnimationStat = characteristics.AttackTime;
        deadState.Init(this);
        idleState.Init(this);
        deferredAction.Init(this);
        deferredAction.timeAnimationStat = new Stat(new Modifier(2000));//2 сек
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        if (newWeapon == weaponSlot.currentWeapon)
            return;

        if (!gameLoop.idleState.isCurrentState)
        {
            deferredAction.Action += () => SetWeapon(characteristics, newWeapon);
            animator.SetBool("DeferredAction", true);
        } 
        else
        {
            SetWeapon(characteristics, newWeapon);
        }
    }

    void SetWeapon(Characteristics characteristics, Weapon newWeapon)
    {
        attackingState = animator.GetBehaviours<AttackingState>().First((attackingStatus) => attackingStatus.attackType == newWeapon.type);
        attackingState.Init(this);
        attackingState.timeAnimationStat = newWeapon.timeAttackStat;
        animator.SetInteger("AttackType", (int)newWeapon.type);
        weaponSlot.SetWeapon(characteristics, newWeapon);
    }

}
