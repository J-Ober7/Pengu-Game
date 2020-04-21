using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float move_speed = 0.01f;
    public Transform anchor;
    public Vector3 wander_area = new Vector2(10, 10);

    private Vector3 current_destination;
    void Start()
    {
        
        current_destination = ChooseDestination();
    }
    
    void Update()
    {
        if (Vector2.Distance((Vector2)transform.position, current_destination) <= 0.1f)
        {
            current_destination = ChooseDestination();
        }
        transform.position = Vector2.MoveTowards(transform.position, current_destination, move_speed);
        transform.right = current_destination - transform.position;
    }

    Vector3 ChooseDestination()
    {
        return new Vector3(Random.Range(wander_area.x * -1, wander_area.x), Random.Range(wander_area.y * -1, wander_area.y), 0) + anchor.position;
    }
}
