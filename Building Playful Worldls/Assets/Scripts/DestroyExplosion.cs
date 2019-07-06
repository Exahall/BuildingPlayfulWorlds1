using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    //The time after which an explosion is despawned
    [SerializeField]
    private float time = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Despawn the explosion object after X seconds
        Destroy(gameObject, time);   
    }
}
