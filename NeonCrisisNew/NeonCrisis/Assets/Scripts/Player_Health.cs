using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour {

    public GameObject explosion;
    public int health = 24;
    public Shield shield;

    // Use this for initialization
    void Start () {
	}

    public void Add_Health(int _amount)
    {
        health += _amount;
        health = Mathf.Clamp(health, 0, 24);
        UI_Health.ui_health_instance.Update_Health(health);
    }
	
	// Update is called once per frame
	/*void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Pew" && shield.active == false) {

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
	}*/

    public void On_End()
    {
        if (Game_End.game_end_instance != null)
        {
            Game_End.game_end_instance.On_End();
        }
        Destroy(this.gameObject);
    }
}
