using System.Collections;
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
    private bool doubleJump = false;
    private float bottomThreshold = -15f;

    public AudioClip damageSound; // Sound effect for when the player takes damage
    public AudioClip deathSound; // Sound effect for when the player dies
    private AudioSource audioSource;


    public float damageCooldownDuration = 2f; // Cooldown duration after taking damage
    private bool isImmune = false; // Flag to indicate player immunity
    private float cooldownTimer = 0f; // Timer for cooldown duration

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        UpdateHearts();
        respawnPoint = transform.position;

        speed = 6f;
        jumpForce = 20f;

        Vector3 minScreenBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // Set the boundaries
        minX = minScreenBounds.x;
        maxX = maxScreenBounds.x;
        minY = minScreenBounds.y;
        maxY = maxScreenBounds.y;

        // Set the gravity scale to control the falling speed
        rb.gravityScale = 3f;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add an AudioSource component if it's not already present
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                doubleJump = true;
            }
            else if (doubleJump)
            {
                Jump();
                doubleJump = false;
            }
        }

        // Update cooldown timer if player is currently immune
        if (isImmune)
        {
            cooldownTimer -= Time.deltaTime;

            // Reset immunity flag and cooldown timer when cooldown period ends
            if (cooldownTimer <= 0f)
            {
                isImmune = false;
                cooldownTimer = 0f;
            }
        }
    }

    void FixedUpdate()
    {
        // Update horizontal movement
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        // Apply horizontal movement
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        // Flip the player sprite if moving left or right
        if (moveHorizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        // Update walking animation
        if (Mathf.Abs(moveHorizontal) > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        // Clamp player's position within screen bounds
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;

        if (transform.position.y < bottomThreshold)
        {
            transform.position = respawnPoint;
            rb.velocity = Vector2.zero; // Reset velocity
        }
    }



    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Set vertical velocity to jumpForce
    }


    public void TakeDamage(int damageAmount)
    {
        // Check if the player is immune to damage
        if (!isImmune)
        {
            currentHealth -= damageAmount;
            UpdateHearts();

            // Play the damage sound
            if (audioSource != null && damageSound != null)
            {
                audioSource.PlayOneShot(damageSound);
            }

            if (currentHealth <= 0)
            {
                Die();
            }

            // Activate cooldown and set cooldown timer
            isImmune = true;
            cooldownTimer = damageCooldownDuration;
        }
    }

    private void Die()
    {
        if (audioSource && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a cloud platform
        if (collision.gameObject.CompareTag("CloudPlatform"))
        {
            isGrounded = true; // Set the flag to true
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player leaves the cloud platform
        if (collision.gameObject.CompareTag("CloudPlatform"))
        {
            isGrounded = false; // Reset the flag
        }
    }
}
