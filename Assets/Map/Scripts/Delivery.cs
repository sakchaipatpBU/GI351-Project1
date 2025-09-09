using UnityEngine;

public class Delivery : MonoBehaviour
{
    public Transform[] locations;
    public Transform tempLocation;
    public Transform newLocation;
    int rand;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.GetInstance().canInteractDelivery = true;
            Debug.Log("Can Innteract Delivery now");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.GetInstance().canInteractDelivery = false;
            Debug.Log("Can NOT Innteract Delivery now");

        }
    }

    public void SetLocation()
    {
        rand = Random.Range(0, locations.Length);

    }
}
