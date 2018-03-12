using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save_Data {

    string[] names;
    int[] scores;
    
    public string[] Get_Names()
    {
        return names;
    }

    public int[] Get_Scores()
    {
        return scores;
    }

    public void Add_Player(string _name, int _score)
    {
        int index = 0;
        for(int i = 0; i < scores.Length; i++)
        {
            if(_score > scores[i])
            {
                Replace_Score(_name, _score, i);
                break;
            }
        }
    }

    void Instantiate()
    {
        if(names.Length != 10)
        {
            names = new string[10];
        }
        if(scores.Length != 10)
        {
            scores = new int[10];
        }
    }

    public void Replace_Score(string _name, int _score, int _index)
    {
        for(int i = names.Length; i > _index; i--)
        {
            if (i - 1 > 0)
            {
                names[i] = names[i - 1];
                scores[i] = scores[i - 1];
            }
        }
        names[_index] = _name;
        scores[_index] = _score;
    }

    public void Print_Stats()
    {
        for(int i = 0; i < names.Length; i++)
        {
            Debug.Log(names[i]);
        }
        for(int i = 0; i < scores.Length; i++)
        {
            Debug.Log(scores[i]);
        }
    }
}
