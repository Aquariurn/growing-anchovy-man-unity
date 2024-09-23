using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private PlayerManager playerManager;

    public TMP_Text goldText;
    public TMP_Text expText;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
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
}
