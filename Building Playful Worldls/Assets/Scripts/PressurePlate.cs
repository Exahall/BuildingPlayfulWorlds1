using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    //The default colour of the plate
    [SerializeField]
    private Color colour;

    //The colour of the plate after its tiggered
    [SerializeField]
    private Color triggeredColour;

    //Holds the object that activates or deactivates when the plate is triggered
    public GameObject triggeredObject;

    //Checks if the pressure plate has triggered yet
    private bool triggered = false;

    //The renderer of the pressure plate
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //Set the default colour on start
        rend = GetComponent<Renderer>();
        rend.material.color = colour;
    }

    // find out when it hit something
    void OnTriggerEnter(Collider c)
    {
        //If the player walks over the pressure plate, trigger it.
        if (c.gameObject.tag == "Player" && triggered == false || c.gameObject.tag == "Ball" && triggered == false)
        {
            //Move down the pressure plate, change the colour, activate/deactivate the connected gameobject and set triggered to true.
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f, gameObject.transform.position.z);
            rend.material.color = triggeredColour;
            triggeredObject.active = !triggeredObject.active;
            triggered = true;

            //Play the related audio clip
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

}
