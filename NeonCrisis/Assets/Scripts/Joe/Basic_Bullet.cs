using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Bullet : MonoBehaviour {

    Rigidbody2D rigidbody;
    public float bullet_speed;
    float destroy_time;

	// Use this for initialization
	void Start () {
        destroy_time = Time.fixedTime + 5;
        //Destroy(this.gameObject, 5);
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = this.transform.up * bullet_speed;
	}

    private void Update()
    {
        if(Time.fixedTime > destroy_time)
        {
            if(Score_Updater.score_updater != null)
            {
                Score_Updater.score_updater.Take_Score(1);
            }
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        Destroy(this.gameObject);
    }
}
