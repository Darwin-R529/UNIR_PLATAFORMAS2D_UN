using UnityEngine;

public class PlatformSpikeController : MonoBehaviour
{
    [SerializeField] float intervalo = 2f;
    [SerializeField] bool iniciarVolteado = false;

    private bool volteado;

    void Start()
    {
        volteado = iniciarVolteado;
        AplicarRotacion();

        InvokeRepeating(nameof(Voltear), intervalo, intervalo);
    }

    void Voltear()
    {
        volteado = !volteado;
        AplicarRotacion();
    }

    void AplicarRotacion()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, volteado ? 180f : 0f);
    }


}
