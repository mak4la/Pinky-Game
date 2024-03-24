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
    public int maxHealth = 3;
    public int currentHealth;
    public HeartController heartController;
    public PlayerInventory playerInventory; // Reference to the player's inventory
    private Vector3 respawnPoint;




    //public GameObject endSceneAnimator;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        UpdateHearts();
        respawnPoint = transform.position;

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

    // This method is called when the player collects a new item

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

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHearts();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("MainMenu"); // Change this to your main menu scene name
    }

    private void UpdateHearts()
    {
        heartController.SetHeartState(currentHealth);
    }
    // This method is called when the player collects a new item
    public void CollectItem(Sprite itemSprite)
    {
        // Add the collected item sprite to the player's inventory
        playerInventory.AddItem(itemSprite);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = transform.position;
        }
        //else if (collision.CompareTag("PreviousLevel"))
        //{
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //respawnPoint = transform.position;
        //}
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a cloud platform
        if (collision.gameObject.CompareTag("CloudPlatform"))
        {
            isGrounded = true; // Set the flag to true
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the player leaves the cloud platform
        if (collision.gameObject.CompareTag("CloudPlatform"))
        {
            isGrounded = false; // Reset the flag
        }
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