using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    //The colour of the object
    [SerializeField]
    private Color colour;

    //The explosion that appears after destruction
    public GameObject explosionPrefab;
    
    //The objects health
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = colour;
    }

    //This is called every frame
    private void Update()
    {
        if (health <= 0)
        {
            Dies();
        }
    }

    // find out when it hit something
    /*void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Bullet")
        {
            Dies();
        }
    }*/

    //Handles the object taking damage
    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }
    
    //When the object is destroyed, explode it!
    private void Dies()
    {
        Instantiate(explosionPrefab,
                transform.position,
                Quaternion.identity);

        Destroy(gameObject);
    }

}
