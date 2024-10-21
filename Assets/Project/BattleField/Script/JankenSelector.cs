using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common.MasterData;

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
        public void SetOptions(CardHand option) {
            switch (option) {
                case CardHand.Rock:
                    Gu_();
                    break;
                case CardHand.Scissors:
                    Choki();
                    break;
                case CardHand.Paper:
                    Pa_();
                    break;
            }
        }
    }

}
