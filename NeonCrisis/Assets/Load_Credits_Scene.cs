using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Credits_Scene : MonoBehaviour {

    public float wait_time;

	// Use this for initialization
	void Start () {
		
	}

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator Load_Credits()
    {
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene("Credits");
    }
}
