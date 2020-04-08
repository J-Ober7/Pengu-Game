using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanInteraction : Interaction {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (on)
        {
            Act();
        }
		
	}

    public override void Act()
    {
        transform.Translate(0.1f, 0.1f, 0);
    }
}
