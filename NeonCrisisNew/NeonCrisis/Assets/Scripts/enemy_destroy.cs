using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroy : MonoBehaviour {

    public GameObject explosion, splash;
    public GameObject[] pickups;
    public int health;
    public int score_amount;


	// Use this for initialization
	void Start () {

	}
	
	void OnCollisionEnter2D (Collision2D col) {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

		if (col.gameObject.CompareTag("Pew")) {            
            if (health <= 0)
            {
                if (explosion != null)
                {
                    GameObject explosion_inst = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
                    Destroy(explosion_inst, 4);
                    
                }
                if (Random.Range(0, 2) == 1 && pickups.Length != 0)
                {
                    Instantiate(pickups[Random.Range(0, pickups.Length)], this.transform.position, Quaternion.identity);
                }
                if (Score_Updater.score_updater != null && Pickup_Controller.pickup_controller_instance != null)
                {
                    Score_Updater.score_updater.Add_Score(score_amount * Pickup_Controller.pickup_controller_instance.score_multiplier);
                }
                if(Laser_Power_Holder.laser_power_holder_instance != null)
                {
                    Laser_Power_Holder.laser_power_holder_instance.Add_Power();
                }
                Destroy(this.gameObject);
=======
=======
>>>>>>> parent of 1abeb0f2... Revert "Merge branch 'master' of https://github.com/sean9392/NEONCRISIS-shmup-"
=======
>>>>>>> parent of 3d8cbfe3... Merge branch 'master' of https://github.com/sean9392/NEONCRISIS-shmup-
=======
>>>>>>> parent of 3d8cbfe3... Merge branch 'master' of https://github.com/sean9392/NEONCRISIS-shmup-
        
		if (col.gameObject.CompareTag("Pew")) {
            if (health <= 0)
            {
                Die();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 3d8cbfe3... Merge branch 'master' of https://github.com/sean9392/NEONCRISIS-shmup-
=======
=======

        print("HIT");
		if (col.gameObject.CompareTag("Pew")) {            
            if (health <= 0)
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
                if(Laser_Power_Holder.laser_power_holder_instance != null)
                {
                    Laser_Power_Holder.laser_power_holder_instance.Add_Power();
                }
                Destroy(this.gameObject);
>>>>>>> 83ac80e79cd2160bf91dffad9d5d7de17f6e2f21
>>>>>>> parent of 1abeb0f2... Revert "Merge branch 'master' of https://github.com/sean9392/NEONCRISIS-shmup-"
=======
>>>>>>> parent of 3d8cbfe3... Merge branch 'master' of https://github.com/sean9392/NEONCRISIS-shmup-
=======
>>>>>>> parent of 3d8cbfe3... Merge branch 'master' of https://github.com/sean9392/NEONCRISIS-shmup-
            }
            else
            {
=======

		if (col.gameObject.CompareTag("Pew")) {            
            if (health <= 0)
            {
                if (explosion != null)
                {
                    GameObject explosion_inst = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
                    Destroy(explosion_inst, 4);
                    
                }
                if (Random.Range(0, 2) == 1 && pickups.Length != 0)
                {
                    Instantiate(pickups[Random.Range(0, pickups.Length)], this.transform.position, Quaternion.identity);
                }
                if (Score_Updater.score_updater != null && Pickup_Controller.pickup_controller_instance != null)
                {
                    Score_Updater.score_updater.Add_Score(score_amount * Pickup_Controller.pickup_controller_instance.score_multiplier);
                }
                if(Laser_Power_Holder.laser_power_holder_instance != null)
                {
                    Laser_Power_Holder.laser_power_holder_instance.Add_Power();
                }
                Destroy(this.gameObject);
            }
            else
            {
>>>>>>> parent of 9dae4760... no fucking clue
                GameObject splash_inst = Instantiate(splash, this.transform.position, Quaternion.identity) as GameObject;
                Destroy(splash_inst, 1);
                health--;
            }
		}
	}
}