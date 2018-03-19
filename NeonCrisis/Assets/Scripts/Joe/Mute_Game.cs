using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Mute_Game : MonoBehaviour {
    
    public AudioMixer mixer;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Mute") && mixer != null)
        {
            float current_volume;
            mixer.GetFloat("Master_Volume", out current_volume);
            if(current_volume == -80)
            {
                mixer.SetFloat("Master_Volume", -5);
            }
            else
            {
                mixer.SetFloat("Master_Volume", -80);
            }
        }
	}
}
