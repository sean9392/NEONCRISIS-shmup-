using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroy : MonoBehaviour {

    public GameObject explosion, splash;
    public GameObject[] pickups;
    public int health;
    public int score_amount;
    bool spawned_pickup = false;

	// Use this for initialization
	void Start () {

	}

    public void Take_Health(int _amount)
    {
        health -= _amount;
        if(health <= 0)
        {
            Die();
        }
    }
	
	void OnCollisionEnter2D (Collision2D col) {
        
		if (col.gameObject.CompareTag("Pew")) {
            if (health <= 0)
            {
                Die();
            }
            else
            {
                if (splash != null)
                {
                    GameObject splash_inst = Instantiate(splash, this.transform.position, Quaternion.identity) as GameObject;
                    Destroy(splash_inst, 1);
                }
                health--;
            }
		}
	}

    void Die()
    {
        if (explosion != null)
        {
            GameObject explosion_inst = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
            Destroy(explosion_inst, 4);

        }
        if (Random.Range(0, 2) == 1 && pickups.Length != 0 && spawned_pickup == false)
        {
            Instantiate(pickups[Random.Range(0, pickups.Length)], this.transform.position, Quaternion.identity);
            spawned_pickup = true;
        }
        if (Score_Updater.score_updater != null && Pickup_Controller.pickup_controller_instance != null)
        {
            Score_Updater.score_updater.Add_Score(score_amount * Pickup_Controller.pickup_controller_instance.score_multiplier);
        }
        if (Laser_Power_Holder.laser_power_holder_instance != null)
        {
            Laser_Power_Holder.laser_power_holder_instance.Add_Power();
        }
        Destroy(this.gameObject);
    }
}