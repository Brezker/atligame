using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AmmoScript : MonoBehaviour
{
    public GameObject counterAmmo;
    public GameObject ammoBox;
    public GameObject badAmmoBox;

    void Sart()
    {
        // var x = Random.Range(-2.61f, 10.76f);
        // var y = 1.02f;
        // var z = Random.Range(-5.22f, 8.49f);
    }

    void Update()
    {
        // Obtén la rotación actual
        Quaternion currentRotation = transform.rotation;

        // Incrementa la rotación en el eje Y con el tiempo
        float rotationSpeed = 40f; // Velocidad de rotación
        currentRotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);

        // Aplica la nueva rotación
        transform.rotation = currentRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GuiScript.instance.AddBullets();
        }
    }
}
