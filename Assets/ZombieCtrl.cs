using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCtrl : MonoBehaviour {

	public float zombieSpeed;

	void Start () {
		transform.rotation = Quaternion.LookRotation (Vector3.forward, Vector3.zero - transform.position) * Quaternion.Euler(0,0,90);
	}
	

	void Update () {
		transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), Vector2.zero, zombieSpeed * Time.deltaTime);
	}
}
