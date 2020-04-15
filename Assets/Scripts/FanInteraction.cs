using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanInteraction : MonoBehaviour {
    GameObject player;
    public float force;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            Act();
        }
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
        }
    }
    public void Act()
    {
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force));
    }
}
