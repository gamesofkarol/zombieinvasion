using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { GAME, PAUSE};

public class GameManager : MonoBehaviour {

    
    public static GameManager instance;
    public GameState gameState;


	void Awake () {
		if(instance == null)
        {
            instance = this;
        }
	}

    void Start()
    {
        gameState = GameState.GAME;
    }

    // Update is called once per frame
    void Update () {
        HandleInput();
        CheckGameOver();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if(gameState == GameState.GAME)
        {
            gameState = GameState.PAUSE;
            Time.timeScale = 0;
        }
        else
        {
            gameState = GameState.GAME;
            Time.timeScale = 1;
        }
    }

    private void CheckGameOver()
    {
        if(gameState == GameState.GAME && PlayerCtrl.instance.lives <= 0)
        {
            RestartGame();
            PauseGame();
        }
    }

    public void RestartGame()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Zombie");
        foreach(GameObject obj in objects)
        {
            Destroy(obj);
        }

        objects = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }

        PlayerCtrl.instance.transform.rotation = Quaternion.Euler(0, 0, 90);
        PlayerCtrl.instance.lives = PlayerCtrl.instance.startLives;
        PlayerCtrl.instance.transform.rotation = Quaternion.Euler(0, 0, 90);
        PlayerCtrl.instance.kills = 0;
    }
}
