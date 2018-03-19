using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public struct Score_Data
{
    public Score_Data(string _name, int _score)
    {
        name = _name;
        score = _score;
    }
    public string name;
    public int score;
}

public class Save_Highscore_Data : MonoBehaviour {

    public void Add_Highscore(string _name, int _score)
    {
        Score_Data score = new Score_Data(_name, _score);

        List<Score_Data> current_scores = Get_Highscores();
        for (int i = 0; i < current_scores.Count; i++)
        {
            if(score.score > current_scores[i].score)
            {
                current_scores.Insert(i, score);
                current_scores.RemoveAt(current_scores.Count - 1);
                break;
            }
        }
        Write_Scores(current_scores);
    }

    public bool Is_Highscore(int _score)
    {
        List<Score_Data> current_scores = Get_Highscores();
        for(int i = 0; i < current_scores.Count; i++)
        {
            if (_score > current_scores[i].score)
            {
                return true;
            }
        }
        return false;
    }

    public List<Score_Data> Get_Highscores()
    {
        List<Score_Data> score_data = new List<Score_Data>();
        List<string> score_strings = Read_File();
        for(int i = 0; i < score_strings.Count; i++)
        {
            string score_name = score_strings[i].Substring(0, score_strings[i].IndexOf(" "));
            string score_score = score_strings[i].Substring(score_strings[i].IndexOf(" "), score_strings[i].Length - score_strings[i].IndexOf(" "));
            Score_Data current_score = new Score_Data();
            current_score.name = score_name;
            current_score.score = System.Int32.Parse(score_score);
            score_data.Add(current_score);
        }
        return score_data;
    }

    List<string> Read_File()
    {
        List<string> file_content = new List<string>();
        if (File.Exists(Application.persistentDataPath + "/highscore_data.dt") == false)
        {
            Write_Default_Content();
        }
        if(File.Exists(Application.persistentDataPath + "/highscore_data.dt") == true)
        {
            StreamReader reader = new StreamReader(Application.persistentDataPath + "/highscore_data.dt");
            while (reader.EndOfStream == false)
            {
                file_content.Add(reader.ReadLine());
            }
            reader.Close();
        }
        return file_content;
    }

    void Write_Scores(List<Score_Data> _scores)
    {
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/highscore_data.dt", false);
        for(int i=  0; i < _scores.Count; i++)
        {
            writer.WriteLine(_scores[i].name + " " + _scores[i].score.ToString());
        }
        writer.Close();

    }

    void Write_Default_Content()
    {
        string[] names = new string[10] { "ANT", "ADY", "PHL", "COL", "STV", "JOD", "TIM", "CRG", "JDH", "BBY"};
        string[] scores = new string[10] { "2000", "1800", "1600", "1400", "1200", "1000", "800", "600", "400", "200" };
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/highscore_data.dt", false);
        for(int i = 0; i < 10; i++)
        {
            string current = names[i] + " " + scores[i];
            writer.WriteLine(current);
        }
        writer.Close();
    }
}
