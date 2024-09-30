using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public GameObject playerObject;
    
    public GameObject shopWindow;
    public GameObject workoutWindow;
    public GameObject[] lockPanel = new GameObject[4];

    private PlayerManager playerManager;
    private TextManager textManager;

    public Button[] equipmentButtons;
    public Button[] workoutButtons;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = playerObject.GetComponent<PlayerManager>();
        textManager = playerObject.GetComponent<TextManager>();
        for (int i = 0; i < equipmentButtons.Length; i++)
        {
            int index = i; // 클로저를 위해 로컬 변수로 복사
            equipmentButtons[i].onClick.AddListener(() => OnEquipmentButtonClick(index));
            Debug.Log(index + "번 째 장비 버튼 추가");
        }
        Debug.Log("equipmentButtons 길이: " + equipmentButtons.Length);

        for (int i = 0; i < workoutButtons.Length; i++  ) {
            int index = i;
            workoutButtons[i].onClick.AddListener(() => OnWorkoutButtonClick(index));
            Debug.Log(index + "번 째 운동 버튼 추가");
        }
        Debug.Log("workoutButtons 길이: " + workoutButtons.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEquipmentButtonClick(int index) {
        player = playerManager.player;
        if(player != null) {
            Debug.Log(index + "번 째 장비 업그레이드");
            player.SetGold(player.GetGold() - 10);
            player.SetEquipmentItem(index, player.GetEquipmentItem(index) + 1);
            textManager.SetEquipmentSprite(index, player.GetEquipmentItem(index));
            textManager.SetGradeText(player.GetGrade());
            textManager.SetGoldText(player.GetGold());
            CheckStat();
        } else {
            Debug.LogError("player 객체가 null입니다.");
        }
    }

    public void OnWorkoutButtonClick(int index) {
        player = playerManager.player;
        if(player != null) {
            Debug.Log(index + "번 째 스탯 업그레이드");
            player.SetGold(player.GetGold() - 3);
            player.SetStat(index, player.GetStat(index) + 1);
            textManager.SetStatsText(player.GetStats());
            textManager.SetGoldText(player.GetGold());
        } else {
            Debug.LogError("player 객체가 null입니다.");
        }
    }

    public void OnClickGold() {
        player = playerManager.player;
        player.SetGold(player.GetGold() + 10);
        textManager.SetGoldText(player.GetGold());
    }

    public void OnClickShop() {
        shopWindow.SetActive(true);
        CheckStat();
    }

    public void OnClickWorkout() {
        workoutWindow.SetActive(true);
    }

    public void OnClickExit() {
        shopWindow.SetActive(false);
        workoutWindow.SetActive(false);
    }

    public void OnClickExp() {
        player = playerManager.player;
        player.SetExp(player.GetExp() + 10);
        if(player.GetExp() + 10 >= player.GetMaxExp()) {
            player.SetMaxExp(player.GetMaxExp() * 2);
            player.SetExp(player.GetExp() - player.GetExp());
        }
        playerManager.UpdateHp();
        textManager.SetExpText(player.GetExp(), player.GetMaxExp());
    }

    private void CheckStat() {
        player = playerManager.player;
        for(int i = 0; i < 4; i++) {
            switch(player.GetEquipmentItem(i)) {
                case 0:
                    if(player.GetStat(i) >= 1) {
                        lockPanel[i].SetActive(false);
                    } else {
                        lockPanel[i].SetActive(true);
                    }
                    break;
                case 1:
                    if(player.GetStat(i) >= 5) {
                        lockPanel[i].SetActive(false);
                    } else {
                        lockPanel[i].SetActive(true);
                    }
                    break;
                case 2:
                    if(player.GetStat(i) >= 10) {
                        lockPanel[i].SetActive(false);
                    } else {
                        lockPanel[i].SetActive(true);
                    }   
                    break;
                case 3:
                    if(player.GetStat(i) >= 15) {
                        lockPanel[i].SetActive(false);
                    } else {
                        lockPanel[i].SetActive(true);
                    }
                    break;
            }
        }
    }
}
