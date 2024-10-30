using UnityEngine;
using UnityEngine.UI;

namespace BattleField.Script.HpBar.View {
    public class HpBarView : MonoBehaviour
    {
        public Image _hpBar;
        public void SetRate(int max, int value)
        {
            _hpBar.fillAmount = (float)value / max;
        }
    }
}

