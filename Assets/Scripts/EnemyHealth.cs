using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 4;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Enemigo recibió daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemigo derrotado!");
        Destroy(gameObject);
    }
}

