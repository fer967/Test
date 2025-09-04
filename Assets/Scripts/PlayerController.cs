using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // --- Movimiento ---
        movement.x = Input.GetAxisRaw("Horizontal");  // -1, 0 o 1
        movement.y = Input.GetAxisRaw("Vertical");    // -1, 0 o 1

        // --- Parámetros del Animator ---
        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        // --- Ataque ---
        if (Input.GetKeyDown(KeyCode.Space))  // podes cambiar la tecla
        {
            animator.SetTrigger("attack");
        }
    }

    private void FixedUpdate()
    {
        // Movimiento físico
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
