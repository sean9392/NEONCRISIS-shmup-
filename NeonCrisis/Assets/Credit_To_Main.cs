using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit_To_Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Load_Main());
	}

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Submit"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

    }

    IEnumerator Load_Main()
    {
        yield return new WaitForSeconds(9);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
