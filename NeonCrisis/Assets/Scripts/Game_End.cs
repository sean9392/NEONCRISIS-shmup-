using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_End : MonoBehaviour {

    public static Game_End game_end_instance;
    float end_time; //what the hell was this for?
    public GameObject game_over_object;
    public GameObject game_won_text;

	// Use this for initialization
	void Start () {
        game_end_instance = this;
        end_time = Time.fixedTime + this.transform.position.y - 6;
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Time.fixedTime > end_time)
        {
            Player_Health health = FindObjectOfType<Player_Health>();
            if (health != null)
            {
                health.On_End();
            }
        }*/
	}

    public void On_End()
    {
        StartCoroutine(End_Game());
    }

    IEnumerator End_Game()
    {
        Score_Updater score_updater = Score_Updater.score_updater;
        if (score_updater != null)
        {
            score_updater.On_End();
        }
        if(game_over_object != null && game_won_text != null)
        {
            Player_Health health = FindObjectOfType<Player_Health>();
            if(health == null || health.health <= 0)
            {
                game_over_object.SetActive(true);
            }
            else
            {
                game_won_text.SetActive(true);
            }
        }
        yield return new WaitForSeconds(5);
        Save_Highscore_Data highscore_data = FindObjectOfType<Save_Highscore_Data>();
        if(score_updater != null && highscore_data != null && highscore_data.Is_Highscore(score_updater.score) == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 2);
        }
        
        
    }
}
