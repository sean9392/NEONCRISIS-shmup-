using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_And_Destroy : MonoBehaviour {

    SpriteRenderer sprite;
    public float fade_speed;
    public float move_speed;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(this.transform.up * move_speed * Time.deltaTime);
		if(sprite.color.a > 0)
        {
            Color color = sprite.color;
            color.a -= fade_speed * Time.deltaTime;
            sprite.color = color;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
}
