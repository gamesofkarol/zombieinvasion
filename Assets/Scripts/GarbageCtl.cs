using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCtl : MonoBehaviour {

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
        }    
    }

}
