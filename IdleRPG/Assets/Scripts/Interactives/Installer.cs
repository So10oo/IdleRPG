using Zenject;
using UnityEngine;

public class Installer : MonoInstaller
{
    [SerializeField] GameLoop _gameLoopPrefab;
    [SerializeField] Player _player;
    [SerializeField] EnemySpanner _enemySpanner;

    [SerializeField] ButtonChangeStateGameLoop _buttonChangeStateGameLoop;
    public override void InstallBindings()
    {
        Container.Bind<GameLoop>().FromInstance(_gameLoopPrefab).AsSingle();

        Container.Bind<Player>().FromInstance(_player).AsSingle();

        Container.Bind<EnemySpanner>().FromInstance(_enemySpanner).AsSingle();

        Container.Bind<FactoryWithDiContainer>().FromInstance(new FactoryWithDiContainer(Container)).AsSingle();
    }
}
