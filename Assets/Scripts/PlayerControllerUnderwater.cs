using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUnderwater : MonoBehaviour
{
    public Rigidbody2D rb;
    public float gravityFactor = -1.0f;
    public float swimSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementHandling();
    }

    private void movementHandling() {
        if (Input.GetKey(KeyCode.W)) {
                rb.AddForce(new Vector2(0, swimSpeed));
        }
        else {
            rb.AddForce(new Vector2(0, gravityFactor));
		}
        if (Input.GetKey(KeyCode.A)) {
                rb.AddForce(new Vector2(swimSpeed * -1, 0));
        }

        if (Input.GetKey(KeyCode.S)) {
                rb.AddForce(new Vector2(0, -1 * swimSpeed));
        }
        if (Input.GetKey(KeyCode.D)) {
                rb.AddForce(new Vector2(swimSpeed, 0));
        }
    }
}
