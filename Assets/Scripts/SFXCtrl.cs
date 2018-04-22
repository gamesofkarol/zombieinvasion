using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour {

    public static SFXCtrl instance;
    public SFX sfx;

	
	void Awake () {
        if (instance == null)
            instance = this;
	}

    public void CreateBloodEffect(Vector3 pos)
    {
        Instantiate(sfx.bloodEffect, pos, Quaternion.identity);
    }
}
