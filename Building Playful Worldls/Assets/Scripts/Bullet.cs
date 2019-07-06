using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //The time after which a bullet is despawned
    private float destroyTimer = 10.0f;

    //The speed at which a bullet travels
    public float speed = 2000.0f;

    //The explosion that appears when a bullet hits something
    //public GameObject explosionPrefab;

    //The tag of the gameobject that shot the bullet
    public string ownerTag;

    //The amount of damage the bullet deals
    [SerializeField]
    private float dmg;

    //Initialization
    private void Start()
    {
        //Destroy the bullet after x seconds of spawing it, to prevent it from lingering if it doesnt collide.
        Destroy(gameObject, destroyTimer);

        //Set the colour of the bullet to black
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = Color.black;
    }

    // find out when it hit something
    void OnCollisionEnter(Collision c)
    {
        //If the thing hit is not the owner of the bullet
        if (ownerTag != c.gameObject.tag)
        {
            //Check if its something that can take damage and if so, apply damage to it
            switch (c.gameObject.tag)
            {
                case "Player":
                    c.gameObject.GetComponent<Health>().TakeDamage(dmg);
                    break;
                case "Enemy":
                    c.gameObject.GetComponent<Enemy>().TakeDamage(dmg);
                    break;
                case "Explodable":
                    c.gameObject.GetComponent<DestructableObject>().TakeDamage(dmg);
                    break;

            }
        }
        
        // show an explosion
        // - transform.position because it should be
        //   where the rocket is
        // - Quaternion.identity because it should
        //   have the default rotation
        /*Instantiate(explosionPrefab,
                    transform.position,
                    Quaternion.identity);*/

        // destroy the rocket
        // note:
        //  Destroy(this) would just destroy the rocket
        //                script attached to it
        //  Destroy(gameObject) destroys the whole thing
        Destroy(gameObject);
    }
}
