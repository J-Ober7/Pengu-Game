using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public int hungerCount = 15;

    public Timer timer;

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
        if (collision.CompareTag("Fish"))
        {
            Debug.Log("fish");
            Destroy(collision.gameObject);
            if (!Timer.isGameOver)
            {
                //hungerCount++;

                if (timer.hunger < timer.maxhunger)
                {
                    if(timer.hunger + 15 > timer.maxhunger)
                    {
                        timer.hunger = timer.maxhunger;
                    }
                    timer.hunger += 15;
                    Debug.Log(timer.hunger);
                }
            }
        }
    }

    private void OnDestroy()
    {
        
    }
}