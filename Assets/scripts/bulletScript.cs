using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // public float life = 300;
    public float velocity = 10f;
    private Vector3 direction;

    public void Init(Vector3 direction)
    {
        this.direction = direction.normalized;
    }

    void Awake()
    {
        // Destroy(gameObject, life); // Corregido para destruir el propio objeto (gameObject)
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Objeto muerto");
        }
        //https://www.youtube.com/watch?v=EwiUomzehKU
    }

    void Update()
    {
        transform.Translate(direction * velocity * Time.deltaTime, Space.World);
    }
}
