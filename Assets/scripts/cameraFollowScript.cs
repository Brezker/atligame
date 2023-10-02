using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al transform del personaje.
    public float distance = 5.2f; // Distancia entre la cámara y el personaje.
    public float height = 3.3f; // Altura de la cámara con respecto al personaje.

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la nueva posición de la cámara.
            Vector3 targetPosition =
                target.position - (target.forward * distance) + (Vector3.up * height);

            // Hace que la cámara mire hacia el personaje.
            transform.LookAt(target);

            // Establece la nueva posición de la cámara.
            transform.position = targetPosition;
        }
    }
}
