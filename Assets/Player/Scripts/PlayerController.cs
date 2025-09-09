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

    public bool canInteractPizzaStore;
    public bool canInteractDelivery;
    public bool canMove;

    public bool isHoldPizza = false;
    public bool isPause = false;

    private static PlayerController instance;
    public static PlayerController GetInstance()
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

        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        interactAction = InputSystem.actions.FindAction("Interact");
        escapeAction = InputSystem.actions.FindAction("Escape");
        canMove = true;
        isPause = false;

    }
    void Start()
    {

    }

    void Update()
    {
        /*if (!canMove) return;

        horizontalInput = moveAction.ReadValue<Vector2>().x;
        verticalInput = moveAction.ReadValue<Vector2>().y;
        transform.Translate(horizontalInput * moveSpeed * Time.deltaTime * Vector3.right);
        transform.Translate(verticalInput * moveSpeed * Time.deltaTime * Vector3.up);*/
        if (!canMove)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        horizontalInput = moveAction.ReadValue<Vector2>().x;
        verticalInput = moveAction.ReadValue<Vector2>().y;

        Vector2 move = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;
        // Debug.Log($"Move Input: {horizontalInput}, {verticalInput}");

        rb.linearVelocity = move;

        if (interactAction.IsPressed() && (canInteractDelivery || canInteractPizzaStore))
        {
            Interact();
        }
        if (interactAction.IsPressed())
        {
            Debug.Log("Iteract");
        }

        if (escapeAction.triggered)
        {
            if(!isPause)
            {
                GameManager.GetInstance().PauseEnnable();
            }
            else
            {
                GameManager.GetInstance().PauseDisable();
            }
        }
    }

    void Interact()
    {
        if (canInteractPizzaStore)
        {
            isHoldPizza = true;
        }
        else if (canInteractDelivery && isHoldPizza)
        {
            isHoldPizza = false;
            // add score
            GameManager.GetInstance().AddScore();

            RandomOrderLocation.Instance.ChangeDeliveryLocation();

            RandomOrderLocation.Instance.ChangeStoreLocation();
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Delivery"))
        {
            canInteractDelivery = true;
            Debug.Log("Can Innteract Delivery now");
        }
        else if (collision.gameObject.CompareTag("PizzaStore"))
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Delivery"))
        {
            canInteractDelivery = true;
            Debug.Log("Can Innteract Delivery now");
        }
        else if (collision.gameObject.CompareTag("PizzaStore"))
        {
            canInteractPizzaStore = true;
            Debug.Log("Can Innteract PizzaStore now");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
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
    }*/


}
