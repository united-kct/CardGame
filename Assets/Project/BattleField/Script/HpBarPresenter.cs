using UnityEngine;
using R3;
using UnityEditor;
using BattleField.Script.HpBar.Model;
using BattleField.Script.HpBar.View;

namespace BattleField.Script.HpBar.Presenter {
    public class HpBarPresenter : MonoBehaviour
    {
    // public StatusModel _model;
        public HpBarView _healthView;
        public HpBarModel _model;
        void Start() {
            _model._hp.Subscribe(value => {
                if (value > _model._healthMax) _model.Health = _model._healthMax;
                if (value < 0) _model.Health = 0;
                _healthView.SetRate(_model._healthMax, value);});
            }
            /*_model._hp.Subscribe(value => { 
                if (value > _model._healthMax) _model.Health = _model._healthMax;
                if (value < 0) _model.Health = 0;
                _healthView.SetRate(_model._healthMax, value);});*/
        
    }
}
