#nullable enable

using BattleField.Script.Progress;
using Common.QRCode;
using InGame.Debug;
using InGame.Turn;
using UnityEngine;

namespace InGame
{
    public class Game : MonoBehaviour
    {
        private GameSettings _gameSettings = null!;
        private ScannerModel _scannerModel = null!;
        [SerializeField] private Scanner _scanner = null!;
        [SerializeField] private TurnPresenter _turn = null!;
        [SerializeField] private Progressor _progressor = null!;
        [SerializeField] private InGameDebugSheetController _debugController = null!;

        private void Start()
        {
            _gameSettings = new();
            _scannerModel = new();

            _scanner.Initialize(_scannerModel);
            _turn.Initialize(_gameSettings.Player, _gameSettings.OpponentPlayer, _scannerModel, _gameSettings.MaxTurn);
            _progressor.Initialize(_gameSettings);

#if !EXCLUDE_UNITY_DEBUG_SHEET
            _debugController.Initialize(_scannerModel);
#endif
        }
    }
}