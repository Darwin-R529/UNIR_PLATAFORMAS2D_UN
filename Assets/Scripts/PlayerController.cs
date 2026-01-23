using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MovementController
{
    [Header("Escalar")]
    [SerializeField] float velocidadEscalar;
    [SerializeField] float gravedadInicial;
    [SerializeField] float JumpForce;
    [SerializeField] float fuerzaDeRebote = 10f;

    private bool escalando;
    private Vector2 input;

    private CapsuleCollider2D capsuleCollider2D;
    private bool enSuelo;
    private bool estaEscalando = false;
    private bool Grounded;
    private bool Damage;




    private void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        gravedadInicial = rb2D.gravityScale;
    }

    // Update is called once per frame
    protected override void Update()
    {

        UpdateRawMove();

        base.Update();

        animator.SetBool("Damage", Damage);
    }

    private void FixedUpdate()
    {
        Escalar();
    }


    private void UpdateRawMove()
    {
        Vector2 rawMove = Vector2.zero;

        if (Keyboard.current.aKey.isPressed)
        { rawMove += Vector2.left; }
        else if (Keyboard.current.dKey.isPressed)
        { rawMove += Vector2.right; }

        desiredMove = rawMove;

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && Grounded)
        { mustJump = true; }


        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            PerformPunch();
        }
    }

    public override void NotifyHit(HitBox2D hitBox2D)
    {
        Debug.Log("Este es el notifyyhit de la clase derivada");
        gameObject.SetActive(false);
        Invoke(nameof(ActivatePlayer), 3f);
    }

    void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }

    private void Escalar()
    {
        // Lee el eje vertical como valor continuo
        float inputY = Keyboard.current[Key.W].ReadValue() - Keyboard.current[Key.S].ReadValue();

        bool tocandoEscalera = capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("ladders"));


        // Activar escalada SOLO si toca la escalera Y hay input
        if (tocandoEscalera && Mathf.Abs(inputY) > 0.01f)
        {
            estaEscalando = true;
        }

        if (estaEscalando)
        {
            rb2D.gravityScale = 0f;

            // Movimiento proporcional a la presión
            rb2D.linearVelocity = new Vector2(
                rb2D.linearVelocity.x,
                inputY * velocidadEscalar
            );

            // Si no hay input, se queda quieto
            if (Mathf.Abs(inputY) < 0.01f)
            {
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, 0f);
            }

            // Activar animación
            animator.SetBool("IsLadder", true);
        }
        else
        {
            animator.SetBool("IsLadder", false);
        }

        // Salir de la escalera
        if (!tocandoEscalera)
        {
            estaEscalando = false;
            rb2D.gravityScale = 1f;
        }
    }


    public void RecibiendoDanio(Vector2 direction, int cantDanio)
    {
        if (!Damage)
        {
            Damage = true;
            Vector2 rebote = new Vector2(transform.position.x - direction.x, 1).normalized;
            rb2D.AddForce(rebote * fuerzaDeRebote, ForceMode2D.Impulse);
        }
    }

    public void DesactivaDanio()
    {
        Damage = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Lava"))
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("Jugador murió en lava");
    }
}
