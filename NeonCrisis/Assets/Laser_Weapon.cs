using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Weapon : MonoBehaviour {
    Animator animator;
    public float damage;
    List<GameObject> enemy_objects = new List<GameObject>();
    List<enemy_destroy> enemy_health = new List<enemy_destroy>();
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(enemy_objects.Contains(collision.gameObject) == false)
        {
            if(collision.gameObject.GetComponent<enemy_destroy>() != null)
            {
                enemy_objects.Add(collision.gameObject);
                enemy_health.Add(collision.gameObject.GetComponent<enemy_destroy>());
                collision.gameObject.GetComponent<enemy_destroy>().Take_Health_Over_Time(damage * Time.deltaTime);
            }
        }
        if(collision.GetComponent<Basic_Bullet>() != null)
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        for(int i = 0; i < enemy_health.Count; i++)
        {
            enemy_health[i].Take_Health_Over_Time(damage * Time.deltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(enemy_health.Contains(collision.gameObject.GetComponent<enemy_destroy>()))
        {
            enemy_health.Remove(collision.gameObject.GetComponent<enemy_destroy>());
            if(enemy_objects.Contains(collision.gameObject))
            {
                enemy_objects.Remove(collision.gameObject);
            }
        }
    }

    public void Stop_Firing()
    {
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if(animator != null)
        {
            animator.SetTrigger("Key_Up");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Anim_End()
    {
        Destroy(this.gameObject);
    }
}
