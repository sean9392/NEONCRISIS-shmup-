using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public enum pickup_types { score_multiplier, damage_multiplier, health, energy};
    public pickup_types pickup_type;
    public int amount;
}
