using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private Transform[] waypoints;

    private int currentWaypoint = 0;
    private bool isWaiting = false;
    private float minDistance = 0.1f; // tolerancia

    void Update()
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

        Flip();
    }

    private void Flip()
    {
        if (transform.position.x > waypoints[currentWaypoint].position.x)
        { 
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Mirar a la izquierda
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Mirar a la derecha
        }
    }
}
