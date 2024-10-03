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
    public TMP_Text gradeText;

    public TMP_Text[] statsText = new TMP_Text[4];
    public TMP_Text[] requireStatsText = new TMP_Text[4];
    private string[] statsName = new string[4] {"체력", "근력", "민첩성", "유연성"};

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
        goldText.text = "골드 : " + gold;
    }

    public void SetExpText(int exp, int maxExp) {
        expText.text = exp + " / " + maxExp;
    }

    public void SetStatsText(int[] stats) {
        for(int i = 0; i < 4; i++) {
            statsText[i].text = statsName[i] + " : " + stats[i];
        }
    }
    
    public void SetEquipmentSprite(int index, int itemId) {
        if(itemId < itemSprites.Length) {
            equipmentImages[index].sprite = itemSprites[itemId];
        } else {
            Debug.LogError("Invalid item ID: " + itemId);
        }
    }

    public void SetGradeText(string grade) {
        gradeText.text = grade;
    }

    public void SetRequireStatText(int index, int requireStat) {
        requireStatsText[index].text = "요구 : " +statsName[index] + " " + requireStat;
    }
}   
