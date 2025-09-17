using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;        // Empty delante del jugador
    public float attackRange = 0.5f;     // rango de golpe
    public LayerMask enemyLayers;        // capa "Enemy"

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))  // ataque con barra espaciadora
        {
            animator.SetTrigger("attack");
            Attack();
        }
    }

    void Attack()
    {
        // Detectar todos los enemigos en el rango de ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Golpe� a " + enemy.name);
            Destroy(enemy.gameObject); // lo elimina
            GameManager.Instance.AddKill(); // suma 1 al contador
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


