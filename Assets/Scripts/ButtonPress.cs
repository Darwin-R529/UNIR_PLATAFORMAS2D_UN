using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public Sprite spriteNormal;
    public Sprite spritePresionado;

    public GameObject objetoQueSeAbre; // muro, puerta, pasadizo, etc.

    private SpriteRenderer sr;
    private bool presionado = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = spriteNormal;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (presionado) return;

        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            // Solo se activa si el jugador cae desde arriba
            if (rb.linearVelocity.y <= -0.1f)
            {
                ActivarBoton();
            }
        }
    }

    void ActivarBoton()
    {
        presionado = true;
        sr.sprite = spritePresionado;

        // Abrir pasadizo
        if (objetoQueSeAbre != null)
        {
            objetoQueSeAbre.SetActive(false);
        }
    }
}