using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : enemy_destroy {

    public override void Update_UI()
    {
        base.Update_UI();
        if(Boss_Health_UI.boss_health_instance != null)
        {
            Boss_Health_UI.boss_health_instance.Update_Health(health, max_health);
        }
    }
}
