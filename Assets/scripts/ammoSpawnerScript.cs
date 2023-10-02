using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject ammoBoxPrefab;
    public int numberOfAmmoBoxes = 3;
    public Vector3 spawnArea = new Vector3(9, 0, 9); // Define el área en la que se generan las cajas de munición.

    void Start()
    {
        SpawnAmmoBoxes();
    }

    void SpawnAmmoBoxes()
    {
        for (int i = 0; i < numberOfAmmoBoxes; i++)
        {
            // Genera una posición aleatoria dentro del área definida.
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x),
                1, // Asegúrate de que la caja de munición esté en el suelo (y = 0).
                Random.Range(-spawnArea.z, spawnArea.z)
            );

            // Instancia una caja de munición en la posición aleatoria.
            Instantiate(ammoBoxPrefab, transform.position + randomPosition, Quaternion.identity);
        }
    }
}
