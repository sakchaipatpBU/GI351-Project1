using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    // public float gameTime;
    public float mapTime;
    public bool isLose;
    public bool isWin;

    public int score;

    public TMP_Text textScore;
    public TMP_Text textTimer;

    public GameObject pausePanel;

    public string mainMenuName = "MainMenu";
    public string lv1Name = "MapLv.1 1";


    private static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        // sigleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(gameObject);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (isLose||isWin) return;
        if (Time.time > mapTime)
        {
            GameOver();
        }
        textTimer.text = "Time : "+((int)(mapTime - Time.time)).ToString();
    }

    public void GameOver()
    {
        isLose = true;
        playerController.canMove = false;
    }

    public void AddScore()
    {
        score++;
        Debug.Log($"Add 1 score => {score}");
        UpdateScore();
    }

    public void ResetScore()
    {
        score = 0;
        Debug.Log($"Score reset => {score}");
        UpdateScore();
    }

    public void UpdateScore()
    {
        textScore.text = "Score : "+score.ToString();
    }

    public void PauseEnnable()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        playerController.isPause = true;
    }
    public void PauseDisable()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        playerController.isPause = false;
    }

    public void OnMainMenuClicked()
    {
        SceneManager.LoadScene(mainMenuName);
    }
    public void OnLv1Clicked()
    {
        SceneManager.LoadScene(lv1Name);
    }
    public void OnResumeClicked()
    {
        PauseDisable();
    }
}
