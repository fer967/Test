using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float detectionRange = 2f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // El enemigo se queda quieto, solo revisa si el player está cerca
        if (player != null && Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            // Podrías activar animación de "alerta" o "ataque" más adelante
            Debug.Log("Player detectado cerca!");
        }
    }
}
