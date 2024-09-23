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
        LoadData();
    }

    void Start()
    {
        textManager = GetComponent<TextManager>();
        textManager.SetGoldText(player.GetGold());
        UpdateHp();
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

        player = new Player(gold, level, grade, exp, maxExp);
    }
}
