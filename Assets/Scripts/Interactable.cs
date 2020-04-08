using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    // Use this for initialization
    public GameObject interactionObject;
    public GameObject player;
    private float interactionDistance = 5.0f;
    public Interaction interactionScript;
	void Start () {
        player = GameObject.FindWithTag("Player");
        interactionScript = interactionObject.GetComponent<Interaction>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance(player.transform.position, transform.position) <= interactionDistance && Input.GetKeyDown(KeyCode.E))
        {
            interactionScript.SwitchOn();
        }
	}
}
