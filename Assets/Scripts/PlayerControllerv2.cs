using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerv2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5.0f;
    public float jumpHeight = 250.0f;
    public bool isGrounded = false;
    public float slideSpeed = 50.0f;
    public bool facing = false;
    public float slideTimer = 1.0f;
    public SpriteRenderer sr;
    public Sprite slide_sprite;
    public Sprite idle_sprite;
    public BoxCollider2D collider;
    public bool inWater = false;
    public float gravityFactor = -1.0f;
    public float swimSpeed = 1.0f;
    public float maxWaterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementHandling();   
    }

    private void OnCollisionEnter2D(Collision2D other) {
        isGrounded = true;
	}

    private void MovementHandling() {

        if (!inWater)
        {

            rb.gravityScale = 1f;
            if (slideTimer == 1.0f)
            {
                if (Input.GetKeyDown(KeyCode.S) && isGrounded)
                {
                    if (isGrounded)
                    {
                        if (facing)
                        {
                            
                            collider.offset = new Vector2(-0.25f, -1.5f);
                            collider.size = new Vector2(5f, 2f);
                            rb.AddForce(new Vector2(slideSpeed, 0));
                            slideTimer -= 0.001f;
                            sr.sprite = slide_sprite;

                        }
                        else
                        {
                            
                            collider.offset = new Vector2(-0.25f, -1.5f);
                            collider.size = new Vector2(5f, 2f);
                            rb.AddForce(new Vector2(slideSpeed * -1, 0));
                            slideTimer -= 0.001f;
                            sr.sprite = slide_sprite;

                        }
                    }
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(new Vector2(0, moveSpeed * -.4f * Time.deltaTime));
                }



                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(new Vector2(moveSpeed * -1 * Time.deltaTime, 0));
                    if (facing)
                    {
                        sr.flipX = false;
                    }
                    facing = false;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0));
                    if (!facing)
                    {
                        sr.flipX = true;
                    }
                    facing = true;
                }
                if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                {
                    rb.AddForce(new Vector2(0, jumpHeight));
                    isGrounded = false;
                }
            }
            else if (slideTimer <= 0)
            {
                slideTimer = 1.0f;
                rb.velocity = new Vector2(0, 0);
                sr.sprite = idle_sprite;
                collider.offset = new Vector2(0.42f, 0.08f);
                collider.size = new Vector2(3.88f, 5f);

            }
            else
            {
                slideTimer -= Time.deltaTime;
            }
        }
        else
        {
            rb.gravityScale = .05f;
            sr.sprite = slide_sprite;
            collider.offset = new Vector2(-0.25f, -1.5f);
            collider.size = new Vector2(5f, 2f);
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector2(0, swimSpeed));
            }
            else
            {
               //rb.AddForce(new Vector2(0, gravityFactor));
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(new Vector2(swimSpeed * -1, 0));
                if (facing)
                {
                    sr.flipX = false;
                }
                facing = false;
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(new Vector2(0, -1 * swimSpeed));
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(new Vector2(swimSpeed, 0)); 
                if (!facing)
                {
                    sr.flipX = true;
                }
                facing = true;
            }

            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxWaterSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ocean"))
        {
            inWater = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ocean"))
        {
            inWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ocean"))
        {

            sr.sprite = idle_sprite;
            inWater = false;
        }
    }


}
