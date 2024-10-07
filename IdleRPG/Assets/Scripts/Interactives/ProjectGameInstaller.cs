using UnityEngine;
using Zenject;

public class ProjectGameInstaller : MonoInstaller
{
    [SerializeField] LocationData defaultLocationData;
    public override void InstallBindings()
    {
        var gcd = new GameCurrentData();
        gcd.locationData = defaultLocationData; 
        Container.Bind<GameCurrentData>().FromInstance(gcd).AsSingle();

    }
}
