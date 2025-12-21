using System.Collections;
using UnityEngine;

public class EnemyInstantiator : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeBetweenEnemyInstantiations = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(InstantiateEnemies(timeBetweenEnemyInstantiations));
    }

    IEnumerator InstantiateEnemies(float timeBetweenInstantiations)
    {
        while (true)
        {
            //hace una copia de un objeto
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            //Instanciamos enemigos
            yield return new WaitForSeconds(timeBetweenInstantiations);
        }
    }
}
