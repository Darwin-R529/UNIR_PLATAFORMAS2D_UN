using Unity.VisualScripting;
using UnityEngine;

public class Sight2D : MonoBehaviour
{

    [SerializeField] float radius = 5f;
    [SerializeField] float checkFrequency = 5f;

    float lastCheckTime;
    Collider2D[] collider;
    // Update is called once per frame
    void Update()
    {

        if ((Time.time - lastCheckTime) > (1f / checkFrequency))
        {
            lastCheckTime = Time.time;

            //GameObject[] arrayConTresBooleanos = new bool[3];   

            // bool[] arrayConTresBooleanos = { true, false, false };

            Debug.Log("Checking sight");
            collider = Physics2D.OverlapCircleAll(transform.position, radius);

            for (int i = 0; i < collider.Length; i++)
            {
                Debug.Log($"El collider {i} se llama {collider[i].name}.", collider[i]);
            }
        }
    }

    public bool IsPlayerInSight()
    {
        bool isPlayerInSight = false;

        for (int i = 0; !isPlayerInSight && (i < collider.Length); i++)
        {
            if (collider[i].CompareTag("Player"))
            {
                isPlayerInSight = true;
            }
        }
        return isPlayerInSight;
    }
}
