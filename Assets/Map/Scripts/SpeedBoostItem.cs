using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float boostAmount = 3f;
    public float boostDuration = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.StartCoroutine(SpeedBoost(player));
                Destroy(gameObject);
            }
        }
    }

    private System.Collections.IEnumerator SpeedBoost(PlayerController player)
    {
        player.moveSpeed += boostAmount;
        Debug.Log("Speed Boost Activated!");

        yield return new WaitForSeconds(boostDuration);

        player.moveSpeed -= boostAmount;
        Debug.Log("Speed Boost Ended!");
    }
}
