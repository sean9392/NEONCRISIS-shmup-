using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    Vector3 position = new Vector3(0, 3.17f, 0);
    public float move_speed, evade_speed;
    public GameObject[] fire_points;
    bool in_position = false;
    Vector3 initial_position;
    public GameObject spawner;
    public float spawn_delay;

	// Use this for initialization
	void Start () {
        StartCoroutine(Move_To_Position());
        StartCoroutine(Spawn_Helpers());
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator Move_To_Position()
    {
        while (this.transform.position != position)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, position, move_speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        for(int i = 0; i < fire_points.Length; i++)
        {
            fire_points[i].SetActive(true);
        }
        in_position = true;
        initial_position = this.transform.position;
        StartCoroutine(Move_Around());
    }

    IEnumerator Move_Around()
    {
        while (true)
        {
            Vector3 target = initial_position;
            target.x += Random.Range(-2f, 2f);
            while (this.transform.position != target)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, target, evade_speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    IEnumerator Spawn_Helpers()
    {
        while(true)
        {
            GameObject spawner_inst = Instantiate(spawner, new Vector3(Random.Range(-2f, 2f), this.transform.position.y + 3, 0), Quaternion.identity) as GameObject;
            Move_Down mover = spawner_inst.AddComponent<Move_Down>();
            mover.speed = 8;            
            Moving_Spawner spawner_script = spawner_inst.GetComponent<Moving_Spawner>();
            spawner_script.Set_Random();
            yield return new WaitForSeconds(spawn_delay);
        }
    }

    private void OnDestroy()
    {
        print("DESTROY");
        if (Game_End.game_end_instance != null)
        {
            Game_End.game_end_instance.On_End();
        }
    }
}
