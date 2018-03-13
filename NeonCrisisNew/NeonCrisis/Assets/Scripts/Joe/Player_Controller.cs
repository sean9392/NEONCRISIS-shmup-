using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

	}
=======
=======
=======
        Save_Load_Data.Save_Game("Test", 500);
>>>>>>> 83ac80e79cd2160bf91dffad9d5d7de17f6e2f21
>>>>>>> parent of 1abeb0f2... Revert "Merge branch 'master' of https://github.com/sean9392/NEONCRISIS-shmup-"
=======
>>>>>>> parent of 3d8cbfe3... Merge branch 'master' of https://github.com/sean9392/NEONCRISIS-shmup-
=======
>>>>>>> parent of 3d8cbfe3... Merge branch 'master' of https://github.com/sean9392/NEONCRISIS-shmup-
    }
>>>>>>> parent of 3d8cbfe3... Merge branch 'master' of https://github.com/sean9392/NEONCRISIS-shmup-
=======

	}
>>>>>>> parent of 9dae4760... no fucking clue
=======

	}
>>>>>>> parent of 2624d7c1... aoeu
	
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
    
    public void Update_Pickup_Index()
    {
        pickup_index++;
        if(pickup_index == 2)
        {
            shot_delay /= 2;
        }
    }  
}
