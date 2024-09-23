using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject player;
    
    public GameObject shopWindow;
    public GameObject workoutWindow;

    private PlayerManager playerManager;
    private TextManager textManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = player.GetComponent<PlayerManager>();
        textManager = player.GetComponent<TextManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickGold() {
        playerManager.player.SetGold(playerManager.player.GetGold() + 10);
        textManager.SetGoldText(playerManager.player.GetGold());
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
        Player player = playerManager.player;
        player.SetExp(player.GetExp() + 10);
        if(player.GetExp() + 10 >= player.GetMaxExp()) {
            player.SetMaxExp(player.GetMaxExp() * 2);
            player.SetExp(player.GetExp() - player.GetExp());
        }
        playerManager.UpdateHp();
        textManager.SetExpText(player.GetExp(), player.GetMaxExp());
    }
}
