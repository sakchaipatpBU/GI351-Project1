using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string lv1Name = "MapLv.1 1";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnLv1Clicked()
    {
        SceneManager.LoadScene(lv1Name);
    }
}
