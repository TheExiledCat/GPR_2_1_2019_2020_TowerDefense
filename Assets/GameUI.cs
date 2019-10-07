using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUI : MonoBehaviour
{
    public Image hpBar;
    public TextMeshProUGUI text;
    public TextMeshProUGUI cash;
    private void Update()
    {
        hpBar.fillAmount = 1f / (float)GameManager.GM.MaxHP * (float)GameManager.GM.HP;
        text.text = GameManager.GM.HP.ToString() + "/" + GameManager.GM.MaxHP.ToString();
        cash.text = "$"+GameManager.GM.cash.ToString("000");
    }
}
