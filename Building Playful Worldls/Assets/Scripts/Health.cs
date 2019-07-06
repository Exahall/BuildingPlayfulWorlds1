using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //The players current health
    public float health;

    //The players max health
    [SerializeField]
    private float maxHealth;

    //The game over panel
    [SerializeField]
    private GameObject gameOverPanel;

    //the game win panel
    //[SerializeField]
    //private GameObject gameWinPanel;

    //The label displaying player health
    [SerializeField]
    private Text healthLabel;

    //Is the player game over or not?
    private bool gameOver = false;

    //Has the player won the game?
    private bool gameWin = false;

    //Initiates stuff
    private void Start()
    {
        health = maxHealth;
        healthLabel.text = $"Health: {health}";
    }

    //Reduces player HP when taking damage and updates the UI box
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        healthLabel.text = $"Health: {health}";
    }

    //Is called every frame
    private void Update()
    {
        //If your health drops below 0, you die and the game over screen will be shown
        if(health <= 0)
        {
            gameOverPanel.SetActive(true);
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameOver = true;
        }

        //While you are dead, you can restart the game by pressing LMB
        if(gameOver && Input.GetMouseButtonDown(0))
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
}
