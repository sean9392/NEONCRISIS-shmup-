using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Down : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(-this.transform.up * speed * Time.deltaTime);
	}
}
