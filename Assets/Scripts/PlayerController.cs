using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float jumpSpeed = 10f;

    Rigidbody2D rb2D;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    Vector2 rawMove = Vector2.zero;
    bool mustJump = false;
    bool mustPunch = false;

    // Update is called once per frame
    void Update()
    {
        UpdateRawMove();

        rb2D.linearVelocityX = rawMove.x * walkSpeed;

        if (rawMove.x != 0)
        {
            animator.SetBool("IsWalking", true);
            // Vector3 scale = transform.localScale;
            // scale.x = Mathf.Sign(rawMove.x) * Mathf.Abs(scale.x);
            // transform.localScale = scale;
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        // Flip sprite based on movement direction
        if (rawMove.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (rawMove.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (mustPunch)
        {
            animator.SetTrigger("PerformPunch");
        }

        if (mustJump)
        {
            rb2D.linearVelocityY = jumpSpeed;
            mustJump = false;
        }
    }

    private void UpdateRawMove()
    {
        rawMove = Vector2.zero;
        if (Keyboard.current.aKey.isPressed)
        { rawMove += Vector2.left; }
        else if (Keyboard.current.dKey.isPressed)
        { rawMove += Vector2.right; }


        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        { mustJump = true; }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        { mustPunch = true; }
    }
}
