using UnityEngine;

public class LizardBullet : MonoBehaviour
{
    public float velocidad = 5f;
    public float tiempoVida = 3f;

    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("colisionó");
            Vector2 direccionDanio = new Vector2(transform.position.x, 0);

            other.gameObject.GetComponent<PlayerController>().RecibiendoDanio(direccionDanio, 1);
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("colisionó");
    //         Vector2 direccionDanio = new Vector2(transform.position.x, 0);

    //         collision.gameObject.GetComponent<PlayerController>().RecibiendoDanio(direccionDanio, 1);
    //     }
    // }
}
