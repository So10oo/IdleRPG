using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RecoverHealth : MonoBehaviour
{
    GameLoop _gameLoop;
    Player _player;

    [Inject]
    void Construct(GameLoop gameLoop, Player character)
    {
        _gameLoop = gameLoop;
        _player = character;
    }

    private void Awake()
    {
        _gameLoop.idleState.OnEnter += Active;
        _gameLoop.idleState.OnExit += Deactivate;
    }

    private void OnDestroy()
    {
        _gameLoop.idleState.OnEnter -= Active;
        _gameLoop.idleState.OnExit -= Deactivate;
    }

    public void Recover()
    {
        _player.characteristics.Health.Recover();
    }

    void Active(GameLoop gameLoop)
    {
        gameObject.SetActive(true);
    }

    void Deactivate(GameLoop gameLoop)
    {
        gameObject.SetActive(false);
    }

}
