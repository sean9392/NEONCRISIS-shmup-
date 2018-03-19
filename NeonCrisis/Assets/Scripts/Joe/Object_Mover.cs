using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Mover : MonoBehaviour {

    public float move_speed;
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(this.transform.up * move_speed * Time.deltaTime);
	}
}
