using UnityEngine;

public class SlimeFollow : MonoBehaviour
{
    public Transform player;
    public float jumpForce = 5f;
    public float moveSpeed = 3f;
    public float jumpInterval = 2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody rb;
    private float jumpTimer;

    private Vector3 originalScale;
    public float squashAmount = 0.5f;
    public float stretchAmount = 1.0f;
    public float scaleSpeed = 12f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpTimer = jumpInterval;
        originalScale = transform.localScale;
    }

    void Update()
    {
  
        
        transform.LookAt(player);
        

        jumpTimer -= Time.deltaTime;

        if (IsGrounded() && jumpTimer <= 0f)
        {
            JumpTowardsPlayer();
            jumpTimer = jumpInterval;
        }

        

    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void JumpTowardsPlayer()
    {
        if (player == null) return;

        Vector3 flatDirection = new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z).normalized;
        Vector3 jumpDirection = flatDirection * moveSpeed + Vector3.up * jumpForce;
        rb.linearVelocity = jumpDirection;
    }

    void UpdateSquashStretch()
    {
        Vector3 targetScale;

        if (IsGrounded())
        {
            targetScale = new Vector3(originalScale.x + squashAmount, originalScale.y - squashAmount, originalScale.z + squashAmount);
        }
        else
        {
            targetScale = new Vector3(originalScale.x, originalScale.y + stretchAmount, originalScale.z);
        }

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }
}
