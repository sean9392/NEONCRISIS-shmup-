using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muter : MonoBehaviour {
    	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Mute"))
        {
            AudioSource[] sources = FindObjectsOfType<AudioSource>();
            for(int i = 0; i < sources.Length; i++)
            {
                sources[i].enabled = false;
            }
        }
	}
}
