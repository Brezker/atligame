using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed = 50.0f;
    public float jumpForce = 8.0f;
    private Rigidbody rb;
    private bool isGrounded;

    private bool isFlying = false;
    private bool doubleJumpAvailable = false;
    public float doubleJumpForce = 6.0f;

    public GameObject bulletPref;

    public float bulletSpeed = 10;
    public GameObject badCube;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 movement =
            new Vector3(horizontalMove, 0, verticalMove) * playerSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                // Salto normal cuando está en el suelo
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else if (doubleJumpAvailable)
            {
                // Doble salto cuando no está en el suelo y el doble salto está disponible
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Elimina la velocidad vertical actual
                rb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
                doubleJumpAvailable = false; // Desactiva el doble salto después de usarlo
                isFlying = true; // Bloquea la coordenada Y después del segundo salto
            }
        }

        // Bloquea la coordenada Y después del segundo salto
        if (isFlying)
        {
            rb.velocity = new Vector3(rb.velocity.x, +0.235f, rb.velocity.z);

            if (Input.GetKey(KeyCode.LeftControl))
            {
                rb.velocity = new Vector3(rb.velocity.x, -jumpForce, rb.velocity.z);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, +jumpForce, rb.velocity.z);
            }
            if (Input.GetKey(KeyCode.G))
            {
                // Gravity stikes back
                isFlying = false;
            }
        }
        // Crea una copia de el objeto en el mapa, todos tienen el mismo control
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(badCube, transform.position + transform.forward, Quaternion.identity);
            Debug.Log("Objeto Salido.");
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            // var bulletSp = transform.position + transform.forward;
            var bullet = Instantiate(
                bulletPref,
                transform.position + transform.forward,
                Quaternion.identity
            );
            // if (bullet != null)
            // {
            //     bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;
            // }
            bullet.GetComponent<BulletMove>().Init(transform.forward);
            // Destroy(bullet, 10);
            Debug.Log("Bala Salido.");
        }
    }

    // OnCollisionEnter is called when the object collides with something
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //Debug.Log("Colisión con el suelo detectada.");
            doubleJumpAvailable = true;
        }
        // if (collision.gameObject.CompareTag("Enemy"))
        // {
        //     Destroy(collision.rb);
        //     Destroy(rb);
        //     Debug.Log("Objeto muerto");
        // }
    }

    // OnCollisionExit is called when the object stops colliding with something
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            //Debug.Log("Salida de la colisión con el suelo.");
        }
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover_player : MonoBehaviour
{
    public float velocidad = 0f;
    private Rigidbody rb;
    private bool gravity_enable = true;
    // Start is called before the first frame update
    public GameObject obj1;
    
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        float mh = Input.GetAxis("Horizontal");
        float mv = Input.GetAxis("Vertical");

        float j = Input.GetAxis("Jump");

        Vector3 movimiento = new Vector3(mh, j, mv);

        transform.Translate(movimiento * velocidad * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(obj1, transform.position + transform.forward, Quaternion.identity);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            gravity_enable = !gravity_enable;
            if(gravity_enable){
                rb.useGravity = false;
            }else{
                rb.useGravity = true;
            }
            
        }
    }
}
*/
