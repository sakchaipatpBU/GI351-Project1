using UnityEngine;

public class Map1 : MonoBehaviour
{
    public GameObject winUi;
    public GameObject loseUi;
    public int pizzaOrderWin = 3;
    public float mapTime = 60;

    public GameManager gameManager;
    public PlayerController playerController;

    private bool hasPlayedWinSound = false;
    private bool hasPlayedLoseSound = false;

    private void Awake()
    {
        winUi.SetActive(false);
        loseUi.SetActive(false);
    }
    private void Start()
    {
        SoundManager.Instance.PlaySFX("Ringing");

        gameManager = GameManager.GetInstance();
        playerController = PlayerController.GetInstance();
        gameManager.ResetScore();
        gameManager.mapTime = mapTime;
        gameManager.isWin = false;
        gameManager.isLose = false;
        playerController.canMove = true;
        gameManager.PauseDisable();

        RandomOrderLocation.Instance.RandomizeAndInstantiateOrderLocation();
    }

    private void Update()
    {
        if (gameManager.score >= pizzaOrderWin && !gameManager.isWin)
        {
            gameManager.isWin = true;
            playerController.canMove = false;
            winUi.SetActive(true);

            if (!hasPlayedWinSound)
            {
                SoundManager.Instance.PlaySFX("Win");
                hasPlayedWinSound = true;
            }
        }

        if (gameManager.isLose)
        {
            loseUi.SetActive(true);

            if (!hasPlayedLoseSound)
            {
                SoundManager.Instance.PlaySFX("Lose");
                hasPlayedLoseSound = true;
            }
        }
    }
}
