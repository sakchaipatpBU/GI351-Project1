using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string lv1Name = "MapLv.1 1";
    public string howToPlayName = "HowToPlay";
    public string mainMenuName = "MainMenu";

    void Start()
    {

    }
    
    public void OnLv1Clicked()
    {
        SoundManager.Instance.PlaySFX("CilckButton");

        SceneManager.LoadScene(lv1Name);
    }
    public void OnExitClicked()
    {
        SoundManager.Instance.PlaySFX("CilckButton");
        Application.Quit();
    }
    public void OnHowtoPlayClicked()
    {
        SoundManager.Instance.PlaySFX("CilckButton");
        SceneManager.LoadScene(howToPlayName);
    }

    public void OnMainMenuClicked()
    {
        SoundManager.Instance.PlaySFX("CilckButton");

        SceneManager.LoadScene(mainMenuName);
    }
}
