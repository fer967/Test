using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Avisar al GameManager
            GameManager.Instance.AddKill();

            // Eliminar al enemigo
            Destroy(gameObject);
        }
    }
}
