using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Controller : MonoBehaviour {

    public int start_screen_index = 0;
    public int highscore_screen_index = 2;
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().buildIndex == start_screen_index)
        {
            Increase_On_Button();
        }
        else if(SceneManager.GetActiveScene().buildIndex == highscore_screen_index)
        {
            Reset_On_Button();
        }
	}

    void Increase_On_Button()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Reset_On_Button()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
