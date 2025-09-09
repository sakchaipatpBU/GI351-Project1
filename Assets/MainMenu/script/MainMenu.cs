using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {

    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("GameLv1");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void HowToPlay()
    {
        Debug.Log("HTP");
        SceneManager.LoadScene("HowToPlay");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
