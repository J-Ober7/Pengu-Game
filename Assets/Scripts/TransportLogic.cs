using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportLogic : MonoBehaviour
{
    public int type;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && type == 1)
        {
            Transport(collision.gameObject);
        }

    }
    public void Transport(GameObject Player) {
        Player.transform.position = target.transform.position;

    }
}
