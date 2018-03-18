using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour {

    public GameObject explosion;
    public int health = 24;
    public Shield shield;
    Pickup_Controller pickup_controller;

    // Use this for initialization
    void Start () {
        pickup_controller = GetComponent<Pickup_Controller>();
	}

    public void Add_Health(int _amount)
    {
        health += _amount;
        health = Mathf.Clamp(health, 0, 24);
        UI_Health.ui_health_instance.Update_Health(health);
    }
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Pew" && shield.active == false) {

            if(pickup_controller == null)
            {
                pickup_controller = GetComponent<Pickup_Controller>();
            }
            if(pickup_controller != null)
            {
                pickup_controller.End_Score_Multiplier();
            }

            if (explosion != null)
            {
                GameObject explosion_inst = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
                Destroy(explosion_inst, 4);
            }

            health -= 3;
            if(UI_Health.ui_health_instance != null)
            {
                UI_Health.ui_health_instance.Update_Health(health);
            }

            if(health <= 0)
            {
                On_End();
            }
        }
	}

    public void On_End()
    {
        if (Game_End.game_end_instance != null)
        {
            Game_End.game_end_instance.On_End();
        }
        Destroy(this.gameObject);
    }
}
