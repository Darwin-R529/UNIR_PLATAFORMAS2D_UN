using UnityEngine;

public class SpikeToggle : MonoBehaviour
{
    public float intervalo = 2f;

    private SpriteRenderer sr;
    private Collider2D col;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        InvokeRepeating(nameof(TogglePuas), intervalo, intervalo);
    }

    void TogglePuas()
    {
        bool activo = !sr.enabled;

        sr.enabled = activo;
        col.enabled = activo;
    }

}
