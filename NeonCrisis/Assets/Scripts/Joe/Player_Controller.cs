using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
    public GameObject laser_weapon;
    GameObject instantiated_laser;
    Laser_Weapon laser_weapon_script;
    public float move_speed;
    public Transform shot_position, shot_position_two, shot_position_three, shot_position_four, shot_position_five;
    Rigidbody2D rigidbody;
    public GameObject bullet;
    public float init_shot_delay;
    public float shot_delay;
    float next_shot_time;
    public Shield shield;
    public AudioSource pew_source;
    public Vector3 min, max;

    int pickup_index;
    int shot_level = 1;

	// Use this for initialization
	void Start () {
        
        init_shot_delay = shot_delay;
        rigidbody = GetComponent<Rigidbody2D>();
        min = new Vector3(-3.4f, -4.65f, 0f);
        max = new Vector3(3.33f, 4.65f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        Handle_User_Input();
        Check_Bounds();
        if(Laser_Power_Holder.laser_power_holder_instance != null && instantiated_laser != null)
        {
            Laser_Power_Holder.laser_power_holder_instance.Take_Power_Over_Time(2 * Time.deltaTime);
            if (Laser_Power_Holder.laser_power_holder_instance.Get_Power() <= 0)
            {
                End_Laser();
            }
        }
	}

    void Handle_User_Input()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(hor * move_speed, ver * move_speed, 0);
        rigidbody.velocity = move;
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Fire_Laser();
        }
        else if(Input.GetButtonUp("Fire2"))
        {
            End_Laser();
        }
    }

    void Check_Bounds()
    {
        Vector3 current_position = this.transform.position;
        if(current_position.x < min.x)
        {
            current_position.x = min.x;
        }
        if(current_position.x > max.x)
        {
            current_position.x = max.x;
        }
        if(current_position.y < min.y)
        {
            current_position.y = min.y;
        }
        if(current_position.y > max.y)
        {
            current_position.y = max.y;
        }
        this.transform.position = current_position;
    }

    void Fire()
    {
        if(bullet != null && shot_position != null)
        {
            //do firing
            Instantiate(bullet, shot_position.position, this.transform.rotation);
            if(pickup_index >= 2)
            {
                Instantiate(bullet, shot_position_two.position, this.transform.rotation);
                Instantiate(bullet, shot_position_three.position, this.transform.rotation);
            }
            if(pickup_index >= 4)
            {
                Instantiate(bullet, shot_position_four.position, this.transform.rotation);
                Instantiate(bullet, shot_position_five.position, this.transform.rotation);
            }
            next_shot_time = Time.fixedTime + shot_delay;

            if (pew_source.isPlaying == false)
            {
                pew_source.Play();
            }
        }
    }

    void Fire_Laser()
    {
        if(Laser_Power_Holder.laser_power_holder_instance != null && Laser_Power_Holder.laser_power_holder_instance.Get_Power() > 0 && instantiated_laser == null)
        {
            Vector3 position = this.transform.position;
            position.y += 5;
            instantiated_laser = Instantiate(laser_weapon, position, Quaternion.identity) as GameObject;
            laser_weapon_script = instantiated_laser.GetComponent<Laser_Weapon>();
            instantiated_laser.transform.SetParent(this.transform);
        }
    }

    void End_Laser()
    {
        if(laser_weapon_script != null)
        {
            laser_weapon_script.Stop_Firing();
        }
    }
    
    public void Update_Pickup_Index()
    {
        pickup_index++;
        
        if (Weapon_Display.weapon_display != null)
        {
            Weapon_Display.weapon_display.Update_Weapon(pickup_index);
        }
        if (pickup_index == 2)
        {
            shot_delay /= 2;
        }
    }  
}
