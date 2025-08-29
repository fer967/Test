using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 5f;

    [Header("Patrol")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime = 1f;
    private int currentWaypoint = 0;
    private bool isWaiting = false;
    private float minDistance = 0.1f;

    private enum State { Patrol, Follow }
    private State currentState = State.Patrol;

    private bool isFacingRight = true;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Cambiar estado según detección del jugador
        if (distanceToPlayer <= detectionRange)
        {
            currentState = State.Follow;
        }
        else if (currentState == State.Follow && distanceToPlayer > detectionRange + 1f) // un poco de histéresis
        {
            currentState = State.Patrol;
        }

        // Ejecutar comportamiento según el estado
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Follow:
                Follow();
                break;
        }

        // Manejar dirección (flip sprite)
        bool isPlayerRight = transform.position.x < player.transform.position.x;
        Flip(isPlayerRight);
    }

    private void Patrol()
    {
        if (!isWaiting)
        {
            float distance = Vector2.Distance(transform.position, waypoints[currentWaypoint].position);

            if (distance > minDistance)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    waypoints[currentWaypoint].position,
                    speed * Time.deltaTime
                );
            }
            else
            {
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
        isWaiting = false;
    }

    private void Follow()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attacking the player!");
        // Acá podés meter animación de ataque o daño
    }

    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
