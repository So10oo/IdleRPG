using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader : MonoBehaviour
{
    GameCurrentData gameCurrentData;

    [Inject]
    void Constructor(GameCurrentData gameCurrentData)
    {
        this.gameCurrentData = gameCurrentData;
    }

    public void Load(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void LoadLocation(LocationData locationData)
    {
        gameCurrentData.locationData = locationData;
        Load("Game");
    }
}
