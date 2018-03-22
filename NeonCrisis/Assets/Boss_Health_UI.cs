using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Health_UI : MonoBehaviour {

    public static Boss_Health_UI boss_health_instance;
    public Image background_image, foreground_image;

	// Use this for initialization
	void Start () {
        boss_health_instance = this;	
	}

    public void Update_Health(int _current, int _max)
    {
        if (background_image != null && foreground_image != null)
        {
            background_image.gameObject.SetActive(true);
            foreground_image.gameObject.SetActive(true);
            print((float)_current / (float)_max);
            foreground_image.fillAmount = ((float)_current / (float)_max);
        }
    }
}
