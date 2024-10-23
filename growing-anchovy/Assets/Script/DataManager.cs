using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData {
    public int gold = 0;
    public int level = 1;
    public string grade = "초보자";
    public int exp = 0;
    public int maxExp = 50;
    public int[] equipments = new int[4] {0, 0, 0, 0};
    public int[] stats = new int[4] {1, 1, 1, 1};
}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    
    string path;
    public PlayerData playerData = new PlayerData();
    
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(Instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/saveData.json";
        print(path);

        if(!File.Exists(path)) {
            SavePlayerData();
        } else {
            LoadPlayerData();
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerData() {
        string data = JsonUtility.ToJson(playerData);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
        string code = System.Convert.ToBase64String(bytes);
        print(code);
        File.WriteAllText(path, code);
        Debug.Log("플레이어 데이터 저장");
    }

    public void LoadPlayerData() {
        string code = File.ReadAllText(path);
        byte[] bytes = System.Convert.FromBase64String(code);
        string data = System.Text.Encoding.UTF8.GetString(bytes);
        playerData = JsonUtility.FromJson<PlayerData>(data);
        Debug.Log("플레이어 데이터 로드");
    }
}
