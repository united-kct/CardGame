#nullable enable

using Common.QRCode;
using UnityEngine;

namespace InGame
{
    public class Game : MonoBehaviour
    {
        private GameSettings _gameSettings = null!;
        private QrCodeScannerModel _scannerModel = null!;
        [SerializeField] private QrCodeScanner _scanner = null!;
        [SerializeField] private Turn _turn = null!;
        [SerializeField] private InGameDebugSheetController _debugController = null!;

        private void Start()
        {
            _gameSettings = new();
            _scannerModel = new();

            _scanner.Initialize(_scannerModel);
            _turn.Initialize(_gameSettings.Player, _gameSettings.OpponentPlayer, _scannerModel, _gameSettings.MaxTurn);

#if !EXCLUDE_UNITY_DEBUG_SHEET
            _debugController.Initialize(_scannerModel);
#endif
        }
    }
}