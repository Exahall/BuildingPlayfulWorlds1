using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameButton : MonoBehaviour
{
    //The default colour of the plate
    [SerializeField]
    private Color colour;

    //Has the player won the game?
    private bool gameWin = false;

    //The game over panel
    [SerializeField]
    private GameObject gameWinPanel;

    //The renderer of the pressure plate
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //Set the default colour on start
        rend = GetComponent<Renderer>();
        rend.material.color = colour;
    }

    //Is called every frame
    private void Update()
    {
        //While you are dead, you can restart the game by pressing LMB
        if (gameWin && Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        //When your health becomes more that 100, you win the level and the win screen will be shown
        //if(health >=0)
        //{
        //    gameWinPanel.SetActive(true);
        //    gameObject.GetComponent<CharacterController>().enabled = false;
        //    gameWin = true;
        //}
    }

    // find out when it hit something
    void OnTriggerEnter(Collider c)
    {
        //If the player walks over the pressure plate, they win the game.
        if (c.gameObject.tag == "Player")
        {

            //Show the window that says they have won the game and disable their ability to play.
            gameWinPanel.SetActive(true);
            c.gameObject.GetComponent<CharacterController>().enabled = false;
            gameWin = true;

            //Play the related audio clip
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

}