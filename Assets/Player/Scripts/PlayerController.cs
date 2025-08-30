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

    private bool canInteract;
    public bool canMove;

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


    }
}
