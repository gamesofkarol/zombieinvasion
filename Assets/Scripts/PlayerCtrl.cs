using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    public GameObject basicBullet;
    public Transform barrel;
    public float fireDelay;
    private Vector3 mousePos;
    private float lastShot;
    

	void Start () {
        lastShot = 0;
	}
	

	void Update () {
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
