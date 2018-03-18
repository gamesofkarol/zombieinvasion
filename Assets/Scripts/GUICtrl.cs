using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUICtrl : MonoBehaviour {

    public Text livesTxt;
    public Text killsTxt;
    public Text killsRecordTxt;
    public GameObject pauseGUI;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        livesTxt.text = "Lives: " + PlayerCtrl.instance.lives;
        killsTxt.text = "Kills: " + PlayerCtrl.instance.kills;
        killsRecordTxt.text = "Kills record: " + GameDataCtrl.instance.gameData.killRecord;

        if (GameManager.instance.gameState == GameState.PAUSE)
        {
            pauseGUI.SetActive(true);
        }else if (GameManager.instance.gameState == GameState.GAME)
        {
            pauseGUI.SetActive(false);
        }
    }
}
