using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    public static PlayerCtrl instance;

    public GameObject basicBullet;
    public Transform barrel;
    public float fireDelay;
    public int lives;
    [HideInInspector]
    public int startLives;

    private Vector3 mousePos;
    private float lastShot;
   


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start () {
        lastShot = 0;
        startLives = lives;
	}
	

	void Update () {

        if(GameManager.instance.gameState == GameState.PAUSE)
        {
            return;
        }

        HandleAim();
        if (Input.GetMouseButton(0))
        {
            Fire();
        }

    }

    private void HandleAim()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position) * Quaternion.Euler(0, 0, 90);

    }

    private void Fire()
    {
        if(lastShot + fireDelay < Time.time)
        {
            Instantiate(basicBullet, barrel.position, transform.rotation);
            lastShot = Time.time;
        }
       
    }
}
