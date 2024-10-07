using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonChangeStateGameLoop : MonoBehaviour
{
    Button _button;
    GameLoop _gameLoop;

    [Inject]
    void Construct(GameLoop gameLoop)
    {
        _gameLoop = gameLoop;
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _gameLoop.idleState.OnEnter += SetStartAction;
        _gameLoop.idleState.OnExit += SetStopAction;
    }

    private void OnDisable()
    {
        _gameLoop.idleState.OnEnter -= SetStartAction;
        _gameLoop.idleState.OnExit -= SetStopAction;
    }

    void SetStopAction(GameLoop gameLoop)
    {
        _button.onClick.RemoveListener(StartAction);
        _button.onClick.AddListener(StopAction);
    }
    void SetStartAction(GameLoop gameLoop)
    {
        _button.onClick.RemoveListener(StopAction);
        _button.onClick.AddListener(StartAction);
    }
    void StopAction()
    {
        _gameLoop.ChangeState(_gameLoop.idleState);
    }
    void StartAction()
    {
        _gameLoop.ChangeState(_gameLoop.searchOpponentState);
    }

}
