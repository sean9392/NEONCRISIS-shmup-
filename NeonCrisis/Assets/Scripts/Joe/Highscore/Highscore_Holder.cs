using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore_Holder: MonoBehaviour {

    public Text name_text, score_text;

    public void Update_UI(string _name, string _score)
    {
        if (name_text != null && score_text != null)
        {
            name_text.text = _name;
            score_text.text = _score;
        }
    }
}
