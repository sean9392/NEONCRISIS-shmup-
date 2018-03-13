using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore_Table_Updater : MonoBehaviour {

    public Highscore_Holder[] holder;
    Save_Highscore_Data highscore_data;

	// Use this for initialization
	void Start () {
        highscore_data = FindObjectOfType<Save_Highscore_Data>();
        List<Score_Data> data = highscore_data.Get_Highscores();
        if(data != null)
        {
            for(int i=  0; i < holder.Length; i++)
            {
                holder[i].Update_UI(data[i].name, data[i].score.ToString());
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
