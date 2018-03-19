using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Display : MonoBehaviour {

    public GameObject sprite_object;

    private void OnDestroy()
    {
        Instantiate(sprite_object, this.transform.position, Quaternion.identity);
    }
}
