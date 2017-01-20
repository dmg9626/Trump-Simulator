﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Damage : MonoBehaviour 
{
    public int Lives;
    private float _screenBoundaryLeft = -5.8F;
    private float _screenBoundaryRight = 10.25F;
    GameObject ScriptController;
    GameObject ScoreController;
    public GameObject Enemy;
    // Use this for initialization
    void Start () 
    {
        ScriptController = GameObject.Find("ScriptController");
        ScoreController = GameObject.Find("ScoreController");
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (Lives > 1)
            {
				if(gameObject.transform.position.x > _screenBoundaryLeft)
					gameObject.transform.position = new Vector2(gameObject.transform.position.x - 3, gameObject.transform.position.y);
                Lives--;
                ScriptController.GetComponent<Stats>().RemoveHeart(Lives);
            }
            else
            {
                // game over condition
                Enemy = col.gameObject;
                LoadGameOver();
            }
        }
    }

    public void LoadGameOver()
    {
        ScriptController.GetComponent<Stats>().SetUpNewScene("GameOver");
        ScoreController.GetComponent<GameOverController>().enabled = true;
        GameObject.Destroy(ScriptController);
        DontDestroyOnLoad(ScoreController);

        SceneManager.LoadScene("GameOver");
    }


}
