using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public GameObject playerObject;
    
    public GameObject shopWindow;
    public GameObject workoutWindow;

    private PlayerManager playerManager;
    private TextManager textManager;

    public Button[] equipmentButtons;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEquipmentButtonClick(int index) {
        player = playerManager.player;
        if(player != null) {
            Debug.Log(index + "번 째 장비 업그레이드");
            player.SetEquipmentItem(index, player.GetEquipmentItem(index) + 1);
            textManager.SetEquipmentSprite(index, player.GetEquipmentItem(index));
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

    
}
