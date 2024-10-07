using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class GameLoop : MonoBehaviour
{
    public Player player { get; private set; } 
    public Enemy enemy { get; private set; }

    EnemySpanner _enemySpawner;
    public EnemySpanner enemySpawner => _enemySpawner;

    #region State
    readonly StateMachine<GameLoop> stateMachine = new();
    public BattleState battleState { get; private set; }
    public IdleLocationState idleState { get; private set; }
    public SearchOpponentState searchOpponentState { get; private set; }
    #endregion

    [Inject]
    void Construct(EnemySpanner enemySpanner, Player player)
    {
        this.player = player;
        _enemySpawner = enemySpanner;
        battleState = new BattleState(this, stateMachine);
        idleState = new IdleLocationState(this, stateMachine);
        searchOpponentState = new SearchOpponentState(this, stateMachine);
    }

    private void OnEnable()
    {
        _enemySpawner.OnEnemySpawn += SetBattle;
    }

    private void OnDisable()
    {
        _enemySpawner.OnEnemySpawn -= SetBattle;
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    void SetBattle(Enemy enemy)
    {
        this.enemy = enemy;
        stateMachine.ChangeState(battleState);
    }

    public void ChangeState(State<GameLoop> state)
    {
        stateMachine.ChangeState(state);
    }

}
