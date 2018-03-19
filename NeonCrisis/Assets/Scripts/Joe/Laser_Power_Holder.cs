using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Power_Holder : MonoBehaviour
{
    public static Laser_Power_Holder laser_power_holder_instance;
    public GameObject laser_ready;
    UI_Laser ui_laser;
    int power_level;
    float taken_amount;

    private void Start()
    {
        ui_laser = FindObjectOfType<UI_Laser>();
        laser_power_holder_instance = this;
    }

    public void Add_Power()
    {
        if (power_level == 9 && laser_ready != null)
        {
            GameObject laser_object = Instantiate(laser_ready, laser_ready.transform.position, Quaternion.identity);
            Destroy(laser_object, 1.5f);
        }
        power_level++;
        power_level = Mathf.Clamp(power_level, 0, 10);
        Update_Power();
    }

    public void Add_Power(int _amount)
    {
        print(power_level);
        if (power_level == 9 && laser_ready != null)
        {
            GameObject laser_object = Instantiate(laser_ready, laser_ready.transform.position, Quaternion.identity);
            Destroy(laser_object, 1);
        }
        power_level += _amount;
        power_level = Mathf.Clamp(power_level, 0, 10);
        Update_Power();
    }

    void Update_Power()
    {
        if (ui_laser == null)
        {
            ui_laser = FindObjectOfType<UI_Laser>();
        }
        if (ui_laser != null)
        {
            ui_laser.Update_Laser_Power(power_level);
        }
    }

    public int Get_Power()
    {
        return power_level;
    }

    public int Take_Power(int _amount)
    {
        if (power_level > _amount)
        {
            power_level -= _amount;
            Update_Power();
            return _amount;
        }
        else
        {
            int power = power_level;
            power_level = 0;
            Update_Power();
            return power;
        }
    }

    public void Take_Power_Over_Time(float _amount)
    {
        taken_amount += _amount;
        if(taken_amount >= 1)
        {
            Take_Power(1);
            taken_amount = 0;
        }
    }
}