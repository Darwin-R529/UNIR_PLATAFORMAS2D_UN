using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherLevelController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int escenaActual = SceneManager.GetActiveScene().buildIndex;
            int totalEscenas = SceneManager.sceneCountInBuildSettings;

            int siguienteEscena = (escenaActual + 1) % totalEscenas;

            SceneManager.LoadScene(siguienteEscena);
        }
    }

}
