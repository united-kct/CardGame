using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BattleField.Script.HpBar.View {
    public class HpBarView : MonoBehaviour
    {
        // Color(0f ,1f ,0f); // スタートカラー
        // Color(1f ,0f ,0f); // エンドカラー
        public Image _hpBar;
        public TextMeshProUGUI _hpText;
        public void SetRate(int max, int value)
        {
            _hpText.text = value.ToString() + "/3000";
            float _hpPercent = (float)value / max;
            _hpBar.fillAmount = _hpPercent;
            float r = (0f - 1f) * _hpPercent + 1f; // 指定の色から指定色へグラデーション。 
            float g = (1f - 0f) * _hpPercent + 0f; // 指定の色から指定色へグラデーション。 
            float b = (0f - 0f) * _hpPercent + 0f; // 指定の色から指定色へグラデーション。
            _hpBar.color = new Color(r,g,b);
        }
    }
}

