﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Controller : MonoBehaviour {

    public static Pickup_Controller pickup_controller_instance;
    public float score_multiplier_time, damage_multiplier_time;
    public int score_multiplier, damage_multiplier;
    Player_Health player_health;
    Player_Controller player_controller;

	// Use this for initialization
	void Start () {
        pickup_controller_instance = this;
        player_health = GetComponent<Player_Health>();
        player_controller = GetComponent<Player_Controller>();
        score_multiplier = 1;
        damage_multiplier = 1;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pickup pickup = collision.GetComponent<Pickup>();
        if(pickup != null)
        {
            switch (pickup.pickup_type)
            {
                case Pickup.pickup_types.damage_multiplier:
                    StartCoroutine(Apply_Damage_Multiplier(pickup.amount));
                    break;
                case Pickup.pickup_types.score_multiplier:
                    StartCoroutine(Apply_Score_Multiplier(pickup.amount));
                    break;
                case Pickup.pickup_types.energy:
                    Add_Energy(pickup.amount);
                    break;
                case Pickup.pickup_types.health:
                    Add_Health(pickup.amount);
                    break;
            }
        }
        Destroy(collision.gameObject);
    }

    void Add_Health(int _amount)
    {
        if(player_health == null)
        {
            player_health = GetComponent<Player_Health>();
        }
        if(player_health != null)
        {
            player_health.Add_Health(_amount);
        }
    }

    void Add_Energy(int _amount)
    {
        Laser_Power_Holder.laser_power_holder_instance.Add_Power(_amount);
    }

    IEnumerator Apply_Damage_Multiplier(int _amount)
    {
        damage_multiplier *= _amount;
        if(player_controller == null)
        {
            player_controller = GetComponent<Player_Controller>();
        }
        if(player_controller != null)
        {
            player_controller.Update_Pickup_Index(damage_multiplier);
        }
        yield return new WaitForSeconds(damage_multiplier_time);
        damage_multiplier = 1;
        if (player_controller == null)
        {
            player_controller = GetComponent<Player_Controller>();
        }
        if (player_controller != null)
        {
            player_controller.Update_Pickup_Index(damage_multiplier);
        }

    }

    IEnumerator Apply_Score_Multiplier(int _amount)
    {
        score_multiplier *= _amount;
        UI_Multiplier.ui_multiplier_instance.Update_Multiplier(score_multiplier);
        yield return new WaitForSeconds(score_multiplier_time);
        score_multiplier = 1;
        UI_Multiplier.ui_multiplier_instance.Update_Multiplier(score_multiplier);
    }
}
