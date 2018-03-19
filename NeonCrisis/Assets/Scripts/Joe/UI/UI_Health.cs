using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour {

    public Image health_bar;
    

    public static UI_Health ui_health_instance;

    private void Start()
    {
        ui_health_instance = this;
    }

    public void Update_Health(int _health)
    {
		float div = (float)_health / (float)24;
        health_bar.fillAmount = div;
    }
}
