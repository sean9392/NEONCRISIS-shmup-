using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Load_On_Video_Stop : MonoBehaviour {

    VideoPlayer video_player;
    float delay = 2;
    float time = 0;

	// Use this for initialization
	void Start () {
        video_player = GetComponent<VideoPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
		if(video_player.isPlaying == false && time > delay)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
	}
}
