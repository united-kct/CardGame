using UnityEngine;
using UnityEngine.UI;

public class HpBarView : MonoBehaviour
{
    public Image _hpBar;
    public void SetRate(int max, int value)
    {
        _hpBar.fillAmount = (float)value / max;
    }
}
