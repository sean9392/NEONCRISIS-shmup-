using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
    public GameObject laser_weapon;
    public float move_speed;
    public Transform shot_position, shot_position_two, shot_position_three, shot_position_four, shot_position_five;
    Rigidbody2D rigidbody;
    public GameObject bullet;
    public float init_shot_delay;
    public float shot_delay;
    float next_shot_time;
    public Shield shield;
    public AudioSource pew_source;

    int pickup_index;
    int shot_level = 1;

	// Use this for initialization
	void Start () {
        
        init_shot_delay = shot_delay;
        rigidbody = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
=======
        Save_Load_Data.Save_Game("Test", 500);
>>>>>>> 83ac80e79cd2160bf91dffad9d5d7de17f6e2f21
    }
	
	// Update is called once per frame
	void Update () {
        Handle_User_Input();
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
        if(Laser_Power_Holder.laser_power_holder_instance != null && Laser_Power_Holder.laser_power_holder_instance.Get_Power() >= 10)
        {
            Vector3 position = this.transform.position;
            position.y += 5;
            GameObject laser = Instantiate(laser_weapon, position, Quaternion.identity) as GameObject;
            Destroy(laser, 1);
            Laser_Power_Holder.laser_power_holder_instance.Take_Power(10);

            //Ray2D ray = new Ray2D(this.transform.position, this.transform.up);
            RaycastHit2D[] hit_out = Physics2D.CircleCastAll(this.transform.position, 0.5f, this.transform.up, 10);
            //RaycastHit2D[] hit_out = Physics2D.RaycastAll(position, this.transform.up, 10);
            for(int i=  0; i < hit_out.Length; i++)
            {
                if(hit_out[i].collider != null)
                {
                    enemy_destroy enemy = hit_out[i].collider.GetComponent<enemy_destroy>();
                    if(enemy != null)
                    {
                        enemy.Take_Health(100);
                    }
                }
            }
        }
    }
    
    public void Update_Pickup_Index()
    {
        pickup_index++;
        if(pickup_index == 2)
        {
            shot_delay /= 2;
        }
    }  
}
