using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class TextEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI _damageText;
    
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damaged(int x) {
        _damageText.color = ColorCodeExchanger("#FF2700");
        _damageText.outlineColor = ColorCodeExchanger("#915B00");
        _damageText.text = x.ToString() + "ダメージ";
    }

    public void Win() {
        
    }

    public void Lose() {
        _damageText.outlineColor = ColorCodeExchanger("#636363");
    }

    private Color ColorCodeExchanger(string colorCode) {
        Color color;
        ColorUtility.TryParseHtmlString(colorCode, out color);
        return color;
    }
}
