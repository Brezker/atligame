using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadAmmoScript : MonoBehaviour
{
    public GameObject counterAmmo;

    void Update()
    {
        // Obtén la rotación actual
        Quaternion currentRotation = transform.rotation;

        // Incrementa la rotación en el eje Y con el tiempo
        float rotationSpeed = -40f; // Velocidad de rotación
        currentRotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);

        // Aplica la nueva rotación
        transform.rotation = currentRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GuiScript.instance.TakeBullets();
        }
    }
}
