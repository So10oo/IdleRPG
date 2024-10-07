using System.Collections;
using UnityEngine;

public class SearchOpponentState : State<GameLoop>
{
    Coroutine searchCoroutine;

    public SearchOpponentState(GameLoop _this, StateMachine<GameLoop> stateMachine) : base(_this, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        searchCoroutine = _this.StartCoroutine(Search());
    }

    IEnumerator Search()
    {
        var timeExite = 2.5f;
        var time = 0f; 
        while (true)
        {
            time += Time.deltaTime;
            if (timeExite < time)
            {
                _this.enemySpawner.SpawnEnemy();
                //stateMachine.ChangeState(_this.battleState);
            }
            yield return null;
        }
         
    }

    public override void Exit()
    {
        base.Exit();
        _this.StopCoroutine(searchCoroutine);
    }
}

