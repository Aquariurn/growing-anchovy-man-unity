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
    string filename = "save";

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(Instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Path.Combine(Application.dataPath, "savedata.json");
    }
    public PlayerData playerData = new PlayerData();

    // Start is called before the first frame update
    void Start()
    {
        if(!File.Exists(path)) {
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
        File.WriteAllText(path, data);
        Debug.Log("플레이어 데이터 생성");
    }

    public void LoadPlayerData() {
        string data = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(data);
        Debug.Log("플레이어 데이터 로드");
    }
}
