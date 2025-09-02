using UnityEngine;

public class PizzaStore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.GetInstance().canInteractPizzaStore = true;
            Debug.Log("Can Innteract PizzaStore now");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.GetInstance().canInteractPizzaStore = false;
            Debug.Log("Can NOT Innteract PizzaStore now");

        }
    }
}
