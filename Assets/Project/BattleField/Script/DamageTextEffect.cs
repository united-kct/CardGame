using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DamageTextEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI _damageText;
    
    void Start()
    {
        var colorCode = /*"#915B00"*/"#636363";
        Color color;
        ColorUtility.TryParseHtmlString(colorCode, out color);
        _damageText = GetComponent<TextMeshProUGUI>();
        _damageText.outlineColor = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}