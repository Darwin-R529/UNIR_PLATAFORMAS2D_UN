using UnityEngine;

public class MovementController : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float jumpSpeed = 10f;

    [Header("Combat Settings")]
    [SerializeField] Transform punchHit;
    [SerializeField] float punchHitDuration = 0.25f;

    Rigidbody2D rb2D;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Awake is called when the script instance is being loaded
    protected virtual void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    protected Vector2 desiredMove = Vector2.zero;
    protected bool mustJump = false;
    protected bool mustPunch = false;

    // Update is called once per frame
    protected virtual void Update()
    {
        rb2D.linearVelocityX = desiredMove.x * walkSpeed;

        if (desiredMove.x != 0)
        {
            animator.SetBool("IsWalking", true);
            // Vector3 scale = transform.localScale;
            // scale.x = Mathf.Sign(desiredMove.x) * Mathf.Abs(scale.x);
            // transform.localScale = scale;
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        // Flip sprite based on movement direction
        if (desiredMove.x > 0)
        {
            // spriteRenderer.flipX = false;
            transform.localScale = Vector3.one;
        }
        else if (desiredMove.x < 0)
        {
            // spriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (mustPunch)
        {
            animator.SetTrigger("PerformPunch");
            mustPunch = false;
        }

        if (mustJump)
        {
            rb2D.linearVelocityY = jumpSpeed;
            mustJump = false;
        }
    }

    protected void PerformPunch()
    {
        mustPunch = true;
        punchHit.gameObject.SetActive(true);
        Invoke(nameof(DeactivatePunchHit), punchHitDuration);
    }

    void DeactivatePunchHit()
    {
        punchHit.gameObject.SetActive(false);
    }

    public virtual void NotifyHit(HitBox2D hitBox2D)
    {
        Destroy(gameObject);
    }
}
