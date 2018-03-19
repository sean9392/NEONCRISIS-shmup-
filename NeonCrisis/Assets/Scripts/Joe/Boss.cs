using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    Vector3 position = new Vector3(0, 3.17f, 0);
    public float move_speed, evade_speed;
    public GameObject[] fire_points;
    bool in_position = false;
    Vector3 initial_position;

	// Use this for initialization
	void Start () {
        StartCoroutine(Move_To_Position());
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

    private void OnDestroy()
    {
        print("DESTROY");
        if (Game_End.game_end_instance != null)
        {
            Game_End.game_end_instance.On_End();
        }
    }
}
