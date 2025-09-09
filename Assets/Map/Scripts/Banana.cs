using System.Collections;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public float stunDuration;
    //Transform transformPlayer;
    PlayerController playerController;
    GameObject playerObject;
    [SerializeField] LeanTweenType looptype;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            playerController = collision.GetComponent<PlayerController>();
            playerObject = collision.gameObject;
            //playerObject = transformPlayer.localRotation;
            if (playerController != null)
            {
                StartCoroutine(StunPlayer());

                //REMINDER!!
                //teleport gameObject out
            }
        }
    }

    IEnumerator StunPlayer()
    {
        float tempMoveSpeed = playerController.moveSpeed;
        Debug.Log("tempspeed: " + tempMoveSpeed);
        playerController.moveSpeed = 0;

        PlayerFall();

        yield return new WaitForSeconds(stunDuration);

        PlayerGetUp();
        playerController.moveSpeed = tempMoveSpeed;

        Debug.Log("player move speed:" + playerController.moveSpeed);
        
        

    }

    void PlayerFall()
    {
        LeanTween.rotate(playerObject, new Vector3(0, 0, -90), (float)0.1).setEase(looptype);
    }
    void PlayerGetUp()
    {
        LeanTween.rotate(playerObject, new Vector3(0, 0, 0), (float)0.2).setEase(looptype);
    }
}
