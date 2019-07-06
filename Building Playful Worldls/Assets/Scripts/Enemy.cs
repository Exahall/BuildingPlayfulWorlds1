using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //The bullet prefab
    public GameObject bullet;

    //Is the enemy able to shoot?
    private bool shoot = true;

    //The player character
    public GameObject player;

    //The location from which the bullet is fired, as to prevent the bullet from spawning inside the enemy model
    public Transform fireLocation;

    //The prefab for the explosion upon death
    public GameObject explosionPrefab;

    //The amount of health the enemy has
    public float health;


    // Update is called once per frame
    void Update()
    {
        //If the enemy can shoot, fire a bullet
        if (shoot)
        {
            GameObject g = (GameObject)Instantiate(bullet,
                                                   fireLocation.position,
                                                   transform.rotation);

            g.GetComponent<Bullet>().ownerTag = gameObject.tag;
            float force = g.GetComponent<Bullet>().speed;
            g.GetComponent<Rigidbody>().AddForce(g.transform.forward * force);

            //After firing a bullet, there will be a short cooldown before the enemy can fire again
            shoot = false;
            StartCoroutine(Cooldown());
        }

        //Always let the enemy face the player
        gameObject.transform.LookAt(player.transform);

        //If the enemies HP drops below 0, it dies.
        if (health <= 0)
        {
            Dies();
        }
    }

    //Handles the cooldown timer on shooting and re-enables the enemies ability to shoot afterwards.
    private IEnumerator Cooldown()
    {
        float wait = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(wait);
        shoot = true;
    }

    //Reduce the enemies health
    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            if(other.GetComponent<Bullet>().ownerTag != this.gameObject.tag)
            {
                Dies();
            }
        }
    }*/

        //Destroy the enemy with a beautiful explosion
    private void Dies()
    {
        Instantiate(explosionPrefab,
                transform.position,
                Quaternion.identity);

        Destroy(gameObject);
    }

}
