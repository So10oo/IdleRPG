using UnityEngine;
using Zenject;

public class Location : MonoBehaviour
{
    [SerializeField] LocationView locationView;

    LocationData locationData;


    [Inject]
    void Construct(GameCurrentData gameCurrentData)
    {
        locationView.SetLocationData(gameCurrentData.locationData);
    }


}

