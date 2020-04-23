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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            Debug.Log("fish");
            Destroy(other.gameObject);
            if (!Timer.isGameOver)
            {
                //hungerCount++;

                if (timer.hunger + hungerCount < 100)
                {
                    timer.hunger += hungerCount;
                }
            }
        }
    }

    private void OnDestroy()
    {
        
    }
}