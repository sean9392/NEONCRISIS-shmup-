using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Letter_Selection : MonoBehaviour {

    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    int name_position = 0;
    int letter_index = 0;
    char[] name_array;

    bool resting = true;

    string player_name;
    Text text;
    

    private void Start()
    {
        name_array = new char[] { ' ', ' ', ' ' };
        text = GetComponent<Text>();
    }

    private void Update()
    {
        int axis = (int)Input.GetAxisRaw("Vertical");
        if(axis != 0 && resting == true)
        {
            if(axis > 0)
            {
                Stick_Up();
            }
            else
            {
                Stick_Down();
            }
        }
        if(axis == 0)
        {
            resting = true;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Submit();
        }
        if(Input.GetButtonDown("Fire2"))
        {
            Back();
        }
        name_array[name_position] = alphabet[letter_index];
        Display_Name();
    }

    void Stick_Up()
    {
        letter_index++;
        if(letter_index > 25)
        {
            letter_index = 0;
        }
        resting = false;
    }

    void Stick_Down()
    {
        letter_index--;
        if(letter_index < 0)
        {
            letter_index = 25;
        }
        resting = false;
    }

    void Display_Name()
    {
        text.text = "" + name_array[0] + name_array[1] + name_array[2];
    }

    void Submit()
    {
        if (name_position == 2)
        {
            player_name = "" + name_array[0] + name_array[1] + name_array[2];
        }
        else
        {
            letter_index = 0;
            name_position++;
        }
    }

    void Back()
    {
        letter_index = 0;
        name_position--;
        if(name_position < 0)
        {
            name_position = 0;
        }
    }
}
