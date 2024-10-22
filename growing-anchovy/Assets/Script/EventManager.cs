using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject shopObject;
    public GameObject workoutObject;
    
    public GameObject shopWindow;
    public GameObject workoutWindow;
    public GameObject[] lockPanel = new GameObject[4];

    private PlayerManager playerManager;
    private TextManager textManager;
    private EffectManager effectManager;
    private PlayerAnimator playerAnimator;
    private Animator shopAnimator;
    private Animator workoutAnimator;
    private Animator shopWindowAnimator;
    private Animator workoutWindowAnimator;

    public Button[] equipmentButtons;
    public Button[] workoutButtons;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = playerObject.GetComponent<PlayerManager>();
        textManager = playerObject.GetComponent<TextManager>();
        playerAnimator = playerObject.GetComponent<PlayerAnimator>();
        effectManager = GetComponent<EffectManager>();
        shopAnimator = shopObject.GetComponent<Animator>();
        workoutAnimator = workoutObject.GetComponent<Animator>();
        shopWindowAnimator = shopWindow.GetComponent<Animator>();
        workoutWindowAnimator = workoutWindow.GetComponent<Animator>();

        for (int i = 0; i < equipmentButtons.Length; i++)
        {
            int index = i;
            Button button = equipmentButtons[i];
            button.onClick.AddListener(() => OnEquipmentButtonClick(index, button.gameObject));
            Debug.Log(index + "번 째 장비 버튼 추가");
        }
        Debug.Log("equipmentButtons 길이: " + equipmentButtons.Length);

        for (int i = 0; i < workoutButtons.Length; i++) {
            int index = i;
            Button button = workoutButtons[i];
            button.onClick.AddListener(() => OnWorkoutButtonClick(index, button.gameObject));
            Debug.Log(index + "번 째 운동 버튼 추가");
        }
        Debug.Log("workoutButtons 길이: " + workoutButtons.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEquipmentButtonClick(int index, GameObject buttonObject) {
        player = playerManager.player;
        if(player != null) {
            if(player.GetGold() >= 10) {
                Debug.Log(index + "번 째 장비 업그레이드");
                player.SetGold(player.GetGold() - 10);
                player.SetEquipmentItem(index, player.GetEquipmentItem(index) + 1);
                playerAnimator.LevelUp();
                textManager.SetEquipmentSprite(index, player.GetEquipmentItem(index));
                textManager.SetGradeText(player.GetGrade());
                textManager.SetGoldText(player.GetGold());
                CheckStat();
                CheckEquipment();
                effectManager.BuyEffect(buttonObject);
                playerManager.SaveData();
            } else {
                Debug.LogError("골드가 부족합니다.");
            }
        } else {
            Debug.LogError("player 객체가 null입니다.");
        }
    }

    public void OnWorkoutButtonClick(int index, GameObject buttonObject) {
        player = playerManager.player;
        if(player != null) {
            if(player.GetGold() >= 3) { 
                Debug.Log(index + "번 째 스탯 업그레이드");
                player.SetGold(player.GetGold() - 3);
                player.SetStat(index, player.GetStat(index) + 1);
                textManager.SetStatsText(player.GetStats());
                textManager.SetGoldText(player.GetGold());
                effectManager.BuyEffect(buttonObject);
                playerManager.SaveData();
            } else {
                Debug.LogError("골드가 부족합니다.");
            }
        } else {
            Debug.LogError("player 객체가 null입니다.");
        }
    }

    public void OnClickShop() {
        CheckStat();
        CheckEquipment();
        shopWindow.SetActive(true);
        shopWindowAnimator.SetTrigger("Open");
        shopAnimator.SetTrigger("Open");
    }

    public void OnClickWorkout() {
        workoutWindow.SetActive(true);
        playerManager.player.SetGold(playerManager.player.GetGold() + 10);
        textManager.SetGoldText(playerManager.player.GetGold());
        workoutWindowAnimator.SetTrigger("Open");
        workoutAnimator.SetTrigger("Open");
    }

    public void OnClickShopExit() {
        shopWindowAnimator.SetTrigger("Close");
        shopAnimator.SetTrigger("Close");
        StartCoroutine(CloseShopAfterAnimation(shopAnimator));
    }

    public void OnClickWorkoutExit() {
        workoutWindowAnimator.SetTrigger("Close");
        workoutAnimator.SetTrigger("Close");
        StartCoroutine(CloseShopAfterAnimation(workoutAnimator));
    }

    private IEnumerator CloseShopAfterAnimation(Animator animator)
    {
        // 애니메이션이 완료될 때까지 기다립니다.
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        shopWindow.SetActive(false);
        workoutWindow.SetActive(false);
    }

    private void CheckStat() {
        player = playerManager.player;
        for(int i = 0; i < 4; i++) {
            switch(player.GetEquipmentItem(i)) {
                case 0:
                    if(player.GetStat(i) >= 3) {
                        lockPanel[i].SetActive(false);
                    } else {
                        lockPanel[i].SetActive(true);
                    }
                    break;
                case 1:
                    if(player.GetStat(i) >= 7) {
                        lockPanel[i].SetActive(false);
                    } else {
                        lockPanel[i].SetActive(true);
                    }
                    break;
                case 2:
                    if(player.GetStat(i) >= 15) {
                        lockPanel[i].SetActive(false);
                    } else {
                        lockPanel[i].SetActive(true);
                    }   
                    break;
                case 3:
                    if(player.GetStat(i) >= 25) {
                        lockPanel[i].SetActive(false);
                    } else {
                        lockPanel[i].SetActive(true);
                    }
                    break;
            }
        }
    }

    private void CheckEquipment() {
        player = playerManager.player;
        for(int i = 0; i < 4; i++) {
            switch(player.GetEquipmentItem(i)) {
                case 0:
                    textManager.SetRequireStatText(i, 3);
                    break;
                case 1:
                    textManager.SetRequireStatText(i, 7);
                    break;
                case 2:
                    textManager.SetRequireStatText(i, 15);
                    break;
                case 3:
                    textManager.SetRequireStatText(i, 25);
                    break;
            }
        }
    }
}
