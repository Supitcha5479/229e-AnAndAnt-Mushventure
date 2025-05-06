using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : Character
{
    Rigidbody2D rb2d;

    //AddF
    Vector2 moveInput;
    //walk 
    float move;
    [SerializeField] float speed;
    //jump
    [SerializeField] float jumpForce;
    [SerializeField] bool isjumping;

    bool facingRight = true;

    void Start()
    {
        Init(100);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Too fast if flip
        /*moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * speed);*/
        float move = Input.GetAxisRaw("Horizontal");
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);

        //Flip
        // หันซ้าย-ขวา
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        IsJumping();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void IsJumping()
    {
        if (Input.GetButtonDown("Jump") && !isjumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
            Debug.Log("Jump!");
        }
    }

    
}