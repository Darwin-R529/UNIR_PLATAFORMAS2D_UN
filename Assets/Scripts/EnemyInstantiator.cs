using System.Collections;
using UnityEngine;

public class EnemyInstantiator : MonoBehaviour
{

    [SerializeField] Transform player;
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
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            EnemyController enemyController = newEnemy.GetComponent<EnemyController>();
            enemyController.player = player;

            //Instanciamos enemigos
            yield return new WaitForSeconds(timeBetweenInstantiations);
        }
    }
}
