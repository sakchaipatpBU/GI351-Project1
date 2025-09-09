using System.Collections;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float boostAmount = 3f;
    public float boostDuration = 5f;

    public float spawnCooldown = 5f;
    public Vector3 outOfMap;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                SoundManager.Instance.PlaySFX("Cola");

                player.StartCoroutine(SpeedBoost(player));
                //Destroy(gameObject);
                //gameObject.SetActive(false);
                gameObject.transform.position = outOfMap;
                StartCoroutine(TimeToRespawn());
            }
        }
    }

    private IEnumerator SpeedBoost(PlayerController player)
    {
        player.moveSpeed += boostAmount;
        Debug.Log("Speed Boost Activated!");

        yield return new WaitForSeconds(boostDuration);

        player.moveSpeed -= boostAmount;
        Debug.Log("Speed Boost Ended!");
    }

    /*public void TimeToRespawn()
    {
        float spawnTime = Time.time+spawnCooldown;
        if (Time.time > spawnTime)
        {
            gameObject.SetActive(true);

            gameObject.transform.position = ColaLocation.Instance.SetNewColaLocation();
        }
        
    }*/
    private IEnumerator TimeToRespawn()
    {
        //gameObject.SetActive(true);
        yield return new WaitForSeconds(spawnCooldown);
        gameObject.transform.position = ColaLocation.Instance.SetNewColaLocation();
    }
}
