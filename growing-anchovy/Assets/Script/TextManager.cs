using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private PlayerManager playerManager;

    public TMP_Text goldText;
    public TMP_Text expText;

    public Image[] equipmentImages = new Image[4];
    private Sprite[] itemSprites;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        itemSprites = Resources.LoadAll<Sprite>("Equipment");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGoldText(int gold) {
        goldText.text = "Gold : " + gold;
    }

    public void SetExpText(int exp, int maxExp) {
        expText.text = exp + " / " + maxExp;
    }

    public void SetEquipmentSprite(int index, int itemId) {
        if(itemId < itemSprites.Length) {
            equipmentImages[index].sprite = itemSprites[itemId];
        } else {
            Debug.LogError("Invalid item ID: " + itemId);
        }
    }
}   
