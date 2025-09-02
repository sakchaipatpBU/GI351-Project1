using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public float xRange;
    public float yRange;

    private float horizontalInput;
    private float verticalInput;

    private InputAction moveAction;
    private InputAction interactAction;
    private InputAction escapeAction;

    private bool canInteractPizzaStore;
    private bool canInteractDelivery;
    public bool canMove;

    bool isHoldPizza = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
        escapeAction = InputSystem.actions.FindAction("Escape");
        canMove = true;

    }
    void Start()
    {

    }

    void Update()
    {
        if (!canMove) return;

        horizontalInput = moveAction.ReadValue<Vector2>().x;
        verticalInput = moveAction.ReadValue<Vector2>().y;
        transform.Translate(horizontalInput * moveSpeed * Time.deltaTime * Vector3.right);
        transform.Translate(verticalInput * moveSpeed * Time.deltaTime * Vector3.up);

        if (interactAction.IsPressed() && (canInteractDelivery || canInteractPizzaStore))
        {
            Interact();
        }
    }

    void Interact()
    {
        if(canInteractPizzaStore)
        {
            isHoldPizza = true;
        }
        else if (canInteractDelivery && isHoldPizza)
        {
            isHoldPizza = false;
            // add score
            GameManager.GetInstance().AddScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Delivery"))
        {
            canInteractDelivery = true;
            Debug.Log("Can Innteract Delivery now");
        }
        else if(collision.gameObject.CompareTag("PizzaStore"))
        {
            canInteractPizzaStore = true;
            Debug.Log("Can Innteract PizzaStore now");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Delivery") || collision.gameObject.CompareTag("PizzaStore"))
        {
            canInteractDelivery = false;
            Debug.Log("Can NOT Innteract Delivery now");
        }
        else if (collision.gameObject.CompareTag("PizzaStore")) 
        {
            canInteractPizzaStore = false;
            Debug.Log("Can NOT Innteract PizzaStore now");
        }
    }
}
