using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Multiplier : MonoBehaviour {

    public Text multiplier_text;

    public static UI_Multiplier ui_multiplier_instance;

	// Use this for initialization
	void Start () {
        ui_multiplier_instance = this;
        if(multiplier_text == null)
        {
            multiplier_text = GetComponent<Text>();
        }
	}
	
	public void Update_Multiplier(int _amount)
    {
        multiplier_text.text = "x" + _amount.ToString();
    }
}
