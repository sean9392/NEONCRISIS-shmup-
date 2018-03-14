using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Display : MonoBehaviour {

    public static Weapon_Display weapon_display;
    public GameObject[] level_display_objects;
    int cuurent_power = 0;

    private void Start()
    {
        weapon_display = this;
        Update_Weapon(0);
    }

    public void Update_Weapon(int _power)
    {
        for(int i = 0; i <= level_display_objects.Length - 1; i++)
        {
            if(i <= _power)
            {
                level_display_objects[i].SetActive(true);
            }
            else
            {
                if (level_display_objects[i] != null)
                {
                    level_display_objects[i].SetActive(false);
                }
            }
        }
    }
}

