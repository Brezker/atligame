using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // public float life = 300;
    public float velocity = 10f;
    private Vector3 direction;
    public float delay = 5.0f;

    void Start()
    {
        // Invoke("DestroyObject", delay);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void Init(Vector3 direction)
    {
        this.direction = direction.normalized;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Objeto muerto");
        }
    }

    void Update()
    {
        transform.Translate(direction * velocity * Time.deltaTime, Space.World);
    }
}
