using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public float gameTime;

    public int score;

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
        DontDestroyOnLoad(gameObject);

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        /*if (Time.time > gameTime)
        {
            GameOver();
        }*/
    }

    public void GameOver()
    {
        playerController.canMove = false;
    }

    public void AddScore()
    {
        score++;
        Debug.Log($"Add 1 score => {score}");
    }

    public void ResetScore()
    {
        score = 0;
        Debug.Log($"Score reset => {score}");
    }
}
