using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleField.Script.Janken {
    public class JankenSelector : MonoBehaviour
    {
        [SerializeField] private Sprite _gu_;
        [SerializeField] private Sprite _choki;
        [SerializeField] private Sprite _pa_;
        [SerializeField] private Image _jankenSelector;

        private void Gu_() {
            _jankenSelector.sprite = _gu_;
        }
        private void Choki() {
            _jankenSelector.sprite = _choki;
        }
        private void Pa_() {
            _jankenSelector.sprite = _pa_;
        }
        public enum Hands {
            guu,choki,paa
        }
        public void SetOptions(Hands option) {
            switch (option) {
                case Hands.guu:
                    Gu_();
                    break;
                case Hands.choki:
                    Choki();
                    break;
                case Hands.paa:
                    Pa_();
                    break;
            }
        }
    }

}
