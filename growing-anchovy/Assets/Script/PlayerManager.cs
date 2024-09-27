using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Player player;
    private TextManager textManager;

    public Slider expBar;
    // Start is called before the first frame update
    void Awake() {
    }

    void Start()
    {
        LoadData();
        textManager = GetComponent<TextManager>();
        textManager.SetGoldText(player.GetGold());
        UpdateHp();
        for(int i = 0; i < 4; i++) {
            textManager.SetEquipmentSprite(i, player.GetEquipmentItem(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHp() {
        expBar.maxValue = player.GetMaxExp();
        expBar.value = player.GetExp();
    }

    public void LoadData() {
        PlayerData playerData = DataManager.Instance.playerData;

        int gold = playerData.gold;
        int level = playerData.level;
        string grade = playerData.grade;
        int exp = playerData.exp;
        int maxExp = playerData.maxExp;
        int[] equipments = playerData.equipments;

        player = new Player(gold, level, grade, exp, maxExp, equipments);
        Debug.Log("플레이어 데이터 로드 성공");
    }
}
