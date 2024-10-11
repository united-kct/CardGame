using UnityEngine;

using R3;

public class HpBarModel : MonoBehaviour
{
    public int _healthMax;
    public SerializableReactiveProperty<int> _hp = new SerializableReactiveProperty<int>();

    void Awake() {
        Health = _healthMax;
    }

    public int Health
    {
        get { return _hp.Value; }
        set { _hp.Value = value; }
    }
}