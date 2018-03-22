using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Attract_Mode : MonoBehaviour {

    public float wait_time;

	// Use this for initialization
	void Start () {
        StartCoroutine(Attract_Load());
	}

    private void Update()
    {
        if(Input.GetButtonDown("Submit") || Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator Attract_Load()
    {
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene("Attract_Mode");
    }
}
