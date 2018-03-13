using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;

public static class Save_Load_Data{

    //get all lines
    //parse lines into arrays of names and scores
    //check for highscore
    //replace highscore and shift everything down
    //clear file
    //write scores back

	public static void Save_Game(string _name, int _score)
    {
        List<string> names = new List<string>();
        List<int> scores = new List<int>();
        List<string> lines = Get_Lines();
        for(int i = 0; i < lines.Count; i++)
        {
            string score = lines[i].Substring(lines[i].IndexOf(' '), lines[i].Length - lines[i].IndexOf(' '));
        }

    }

    public static List<string> Get_Lines()
    {
        List<string> lines = new List<string>();

        StreamReader reader = new StreamReader(Application.persistentDataPath + "/save_data.txt");
        
        while(reader.EndOfStream == false)
        {
            lines.Add(reader.ReadLine());
        }
        reader.Close();
        return lines;
    }
}
