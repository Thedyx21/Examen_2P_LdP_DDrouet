using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Prefabs de objetos que caerán
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 2f;
    public Transform[] spawnPoints; // Puntos desde donde los objetos caerán

    void Start()
    {
        StartCoroutine(SpawnCoroutine(0));
    }

    IEnumerator SpawnCoroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // Seleccionar aleatoriamente un punto de generación
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instanciar un objeto aleatorio en el punto seleccionado
        GameObject spawnedItem = Instantiate(
            itemPrefabs[Random.Range(0, itemPrefabs.Length)],
            spawnPoint.position,
            Quaternion.identity
        );

        // Destruir el objeto después de 5 segundos
        Destroy(spawnedItem, 5f);

        // Volver a ejecutar la rutina de generación con un tiempo aleatorio
        StartCoroutine(SpawnCoroutine(Random.Range(minSpawnTime, maxSpawnTime)));
    }
}

