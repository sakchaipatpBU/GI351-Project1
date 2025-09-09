using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string lv1Name = "MapLv.1 1";
    void Start()
    {

    }
    
    public void OnLv1Clicked()
    {
        SceneManager.LoadScene(lv1Name);
    }
    
}
