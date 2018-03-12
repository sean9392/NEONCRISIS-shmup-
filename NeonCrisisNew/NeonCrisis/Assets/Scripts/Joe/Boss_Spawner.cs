using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spawner : MonoBehaviour {

    public GameObject boss_object;

    float spawn_time;


	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        spawn_time = (Time.fixedTime) + (this.transform.position.y / 1.5f) - (6 / 1.5f);
=======
        spawn_time = Time.fixedTime + this.transform.position.y - 6;
>>>>>>> 83ac80e79cd2160bf91dffad9d5d7de17f6e2f21
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.fixedTime > spawn_time && boss_object != null)
        {
            Instantiate(boss_object, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
	}
}
