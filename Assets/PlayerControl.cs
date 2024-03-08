using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float moveHorizontal;
    private Animator anim;
    public float jumpForce;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;
    private float minX, maxX, minY, maxY;
    //public GameObject endSceneAnimator;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        speed = 6f;
        jumpForce = 20f;
        //transform.position = new Vector3(-83.1f, -38f, 0);

        Vector3 minScreenBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // Set the boundaries
        minX = minScreenBounds.x;
        maxX = maxScreenBounds.x;
        minY = minScreenBounds.y;
        maxY = maxScreenBounds.y;

        // Set the gravity scale to control the falling speed
        rb.gravityScale = 3f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");

            if (moveHorizontal > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (moveHorizontal < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

            if (moveHorizontal == 0)
            {
                anim.SetBool("isWalking", false);
            }
            else
            {
                anim.SetBool("isWalking", true);
            }

            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
            transform.position = newPosition;
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Set vertical velocity to jumpForce
        isGrounded = false; // Update grounded state
    }

//private void OnTriggerEnter2D(Collider2D other)
    //{
        //if (other.CompareTag("MonsterCounter"))
        //{
            //endSceneAnimator.GetComponent<Animator>().SetTrigger("StartEndSceneAnimation");
            // Load MainMenu scene after a delay
            //Invoke(nameof(ReturnToMainMenu), 1.5f);
        //}
    //}

    //private void ReturnToMainMenu()
    //{
        //SceneManager.LoadScene("MainMenu");
    //}
}
