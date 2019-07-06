using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObject : MonoBehaviour
{
    //The amount of damage this object does
    [SerializeField]
    private float dmg;

    //When the ball hits the player, deal damage to it.
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            c.gameObject.GetComponent<Health>().TakeDamage(dmg);
        }
    }

    //For some weird reason some objects only work as a trigger?? Unity magic I suppose 
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log(c.gameObject.name);
            c.gameObject.GetComponent<Health>().TakeDamage(dmg);
        }
    }
}
