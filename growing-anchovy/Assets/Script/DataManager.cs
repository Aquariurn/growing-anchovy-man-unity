using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData {
    public int gold = 0;
    public int level = 1;
    public string grade = "비기너";
    public int exp = 0;
    public int maxExp = 50;
}

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;
    
    string path;
    string filename = "save";

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(Instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/";
    }
    public PlayerData playerData = new PlayerData();

    // Start is called before the first frame update
    void Start()
    {
        if(!File.Exists(path + "playerData")) {
            NewPlayerData();
        } else {
            LoadPlayerData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewPlayerData() {
        string data = JsonUtility.ToJson(playerData);
        File.WriteAllText(path + "playerData", data);
        Debug.Log("플레이어 데이터 생성");
    }

    public void LoadPlayerData() {
        string data = File.ReadAllText(path + "playerData");
        playerData = JsonUtility.FromJson<PlayerData>(data);
        Debug.Log("플레이어 데이터 로드");
    }
}
