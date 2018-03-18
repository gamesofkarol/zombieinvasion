using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class GameDataCtrl : MonoBehaviour {

    public static GameDataCtrl instance;
    public GameData gameData;

    private string gameDataPath;
    private BinaryFormatter bf;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start () {
        gameDataPath = Application.persistentDataPath + "/data.dat";
        bf = new BinaryFormatter();
        LoadData();
    }
	

	public void LoadData() {
        if (File.Exists(gameDataPath))
        {
            FileStream fs = new FileStream(gameDataPath, FileMode.Open);
            gameData = (GameData)bf.Deserialize(fs);
            fs.Close();

        }
        else
        {
            gameData = new GameData();
            SaveData();
        }

    }

    public void SaveData()
    {
        FileStream fs = new FileStream(gameDataPath, FileMode.Create);
        bf.Serialize(fs, gameData);
        fs.Close();
    }
}
