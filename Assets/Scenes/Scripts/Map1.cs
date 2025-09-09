using UnityEngine;

public class Map1 : MonoBehaviour
{
    public GameObject winUi;
    public GameObject loseUi;
    public int pizzaOrderWin = 3;
    public float mapTime = 60;

    public GameManager gameManager;
    public PlayerController playerController;

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
        if(gameManager.score >= pizzaOrderWin)
        {
            SoundManager.Instance.PlaySFX("Win");
            winUi.SetActive(true);
            playerController.canMove = false;
            gameManager.isWin = true;
        }
        if (gameManager.isLose)
        {
            SoundManager.Instance.PlaySFX("Lose");
            loseUi.SetActive(true);
        }
    }
}
