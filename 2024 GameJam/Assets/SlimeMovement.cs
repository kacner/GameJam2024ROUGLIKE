using System.Collections;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpInterval = 2f;
    private Rigidbody2D rb;
    private Transform player;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming your player has the "Player" tag
        StartCoroutine(JumpCoroutine());
    }

    void Update()
    {
        // Check if the slime is on the ground (you might need to adjust this based on your game setup)
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            isJumping = false;
        }
    }

    IEnumerator JumpCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(jumpInterval);
            JumpTowardsPlayer();
        }
    }

    void JumpTowardsPlayer()
    {
        if (!isJumping)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.AddForce(direction * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }
}