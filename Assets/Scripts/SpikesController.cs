using UnityEngine;

public class SpikesController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("colisionó");
            Vector2 direccionDanio = new Vector2(transform.position.x, 0);

            other.gameObject.GetComponent<PlayerController>().RecibiendoDanio(direccionDanio, 1);
        }
    }
}
