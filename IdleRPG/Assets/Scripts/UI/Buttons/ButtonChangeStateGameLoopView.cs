using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class ButtonChangeStateGameLoopView : MonoBehaviour 
{
    [SerializeField] Image _imageView;

    [SerializeField] Sprite _start;
    [SerializeField] Sprite _stop;

    GameLoop _gameLoop;
    Player _player;

    [Inject]
    void Construct(GameLoop gameLoop, Player character)
    {
        _gameLoop = gameLoop;
        _player = character;
    }

    private void Start()
    {
        _gameLoop.idleState.OnEnter += Text1;
        _gameLoop.searchOpponentState.OnEnter += Text2;
        _gameLoop.battleState.OnEnter += Text3;

        _player.deadState.OnExit += Activate;
        _player.deadState.OnEnter += Deactivate;
    }

    private void OnDestroy()
    {
        _gameLoop.idleState.OnEnter -= Text1;
        _gameLoop.searchOpponentState.OnEnter -= Text2;
        _gameLoop.battleState.OnEnter -= Text3;
        _player.deadState.OnExit -= Activate;
        _player.deadState.OnEnter -= Deactivate;
    }

    void Activate(Character character, Animator animator, AnimatorStateInfo stateInfo)
    {
        gameObject.SetActive(true);
    }
    void Deactivate(Character character, Animator animator, AnimatorStateInfo stateInfo)
    {
        gameObject.SetActive(false);
    }

    void Text1(GameLoop gameLoop)
    {
        //_buttonText.text = "поиск";
        _imageView.sprite = _start;

    }

    void Text2(GameLoop gameLoop)
    {
        //_buttonText.text = "отмена";
        _imageView.sprite = _stop;
    }

    void Text3(GameLoop gameLoop)
    {
        //_buttonText.text = "покинуть";
        _imageView.sprite = _stop;
    }
 
}

