using UnityEngine;

public class LizardController : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;

    public void Disparar()
    {
        Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("colisionó");
            Vector2 direccionDanio = new Vector2(transform.position.x, 0);

            collision.gameObject.GetComponent<PlayerController>().RecibiendoDanio(direccionDanio, 1);
        }
    }

}
