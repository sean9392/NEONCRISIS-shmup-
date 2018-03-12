using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_End : MonoBehaviour {

    public static Game_End game_end_instance;
    float end_time;

	// Use this for initialization
	void Start () {
        game_end_instance = this;
        end_time = Time.fixedTime + this.transform.position.y - 6;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.fixedTime > end_time)
        {
            Player_Health health = FindObjectOfType<Player_Health>();
            if (health != null)
            {
                health.On_End();
            }
        }
	}

    public void On_End()
    {
        StartCoroutine(End_Game());
    }

    IEnumerator End_Game()
    {
        if (Score_Updater.score_updater != null)
        {
            Score_Updater.score_updater.On_End();
        }
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
