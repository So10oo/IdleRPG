using UnityEngine;
using UnityEngine.UI;

public class LocationView : MonoBehaviour 
{
    [SerializeField] Image _background;
    public void SetLocationData(LocationData locationData)
    {
        _background.sprite = locationData.background;
    }

}

