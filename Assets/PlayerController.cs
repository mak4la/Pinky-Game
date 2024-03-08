using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    int jumpPower;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }




}


