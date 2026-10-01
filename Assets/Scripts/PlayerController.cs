using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rd;
    public float speed = 5f;
    public float jumForce = 7f;

    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        rd.velocity = new Vector2(move * speed, rd.velocity.y);

        //salto

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rd.AddForce(Vector2.up * jumForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
