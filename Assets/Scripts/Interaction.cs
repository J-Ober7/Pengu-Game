using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour {

    public bool on = false;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}


    public void SwitchOn()
    {
        on = true;
    }

    public abstract void Act();
}
