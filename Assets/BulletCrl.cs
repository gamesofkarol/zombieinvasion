﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCrl : MonoBehaviour {

    public float bulletSpeed;

	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
	}
	
}
