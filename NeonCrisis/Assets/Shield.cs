using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
   
    public int shield_cost;
    public float shield_time;
    MeshRenderer shield_renderer;
    CircleCollider2D shield_collider;
    public bool active;

	// Use this for initialization
	void Start () {
        shield_renderer = GetComponent<MeshRenderer>();
        shield_collider = GetComponent<CircleCollider2D>();
        Deactivate();
	}

    private void Update()
    {
        this.transform.position = this.transform.parent.transform.position;

        if (Input.GetButton("Fire3"))
        {
            if(Laser_Power_Holder.laser_power_holder_instance != null && Laser_Power_Holder.laser_power_holder_instance.Get_Power() > 0 && active == false)
            {
                Activate();
            }
            if(Laser_Power_Holder.laser_power_holder_instance != null && active ==true)
            {
                Laser_Power_Holder.laser_power_holder_instance.Take_Power_Over_Time(shield_cost * Time.deltaTime);
            }
        }
        if(Input.GetButtonUp("Fire3"))
        {
            Deactivate();
        }
        if(Laser_Power_Holder.laser_power_holder_instance != null && Laser_Power_Holder.laser_power_holder_instance.Get_Power() <= 0)
        {
            Deactivate();
        }

    }

    void Activate()
    {
        shield_collider.enabled = true;
        shield_renderer.enabled = true;
        active = true;
    }

    void Deactivate()
    {
        shield_collider.enabled = false;
        shield_renderer.enabled = false;
        active = false;
    }

    IEnumerator Activate_Shield()
    {
        Activate();
        yield return new WaitForSeconds(shield_time);
        Deactivate();
    }

}
