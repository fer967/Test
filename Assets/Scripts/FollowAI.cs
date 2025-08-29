using UnityEditor.Tilemaps;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private Transform player;
    private bool isFacingRight = true;
        
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > minDistance)              //Follow the player
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            Attack();
        }

        bool isPlayerRight = transform.position.x < player.transform.position.x;
        Flip(isPlayerRight);
    }
    private void Attack()
    {
        // Implement attack logic here
        Debug.Log("Attacking the player!");
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
