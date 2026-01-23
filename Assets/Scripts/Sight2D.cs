using Unity.VisualScripting;
using UnityEngine;

public class Sight2D : MonoBehaviour
{

    [SerializeField] float radius = 5f;
    [SerializeField] float checkFrequency = 5f;

    float lastCheckTime = 0.0f;
    Collider2D[] colliders = new Collider2D[0];
    // Update is called once per frame
    void Update()
    {

        if ((Time.time - lastCheckTime) > (1f / checkFrequency))
        {
            lastCheckTime = Time.time;

            //GameObject[] arrayConTresBooleanos = new bool[3];   

            // bool[] arrayConTresBooleanos = { true, false, false };

            // Debug.Log("Checking sight");
            colliders = Physics2D.OverlapCircleAll(transform.position, radius);

            // for (int i = 0; i < colliders.Length; i++)
            // {
            //     Debug.Log($"El colliders {i} se llama {colliders[i].name}.", colliders[i]);
            // }
        }
    }

    public bool IsPlayerInSight()
    {
        bool isPlayerInSight = false;

        for (int i = 0; !isPlayerInSight && (i < colliders.Length); i++)
        {
            if (colliders[i].CompareTag("Player"))
            {
                isPlayerInSight = true;
            }
        }
        return isPlayerInSight;
    }
}
