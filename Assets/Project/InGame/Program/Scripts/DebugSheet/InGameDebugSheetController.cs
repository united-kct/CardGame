#if !EXCLUDE_UNITY_DEBUG_SHEET
#nullable enable

using Common.QRCode;
using UnityDebugSheet.Runtime.Core.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace InGame.Debug
{
    public sealed class InGameDebugSheetController : MonoBehaviour
    {
        [SerializeField] private RawImage _qrCodeScannerScreen = null!;
        private ScannerModel _scannerModel = null!;

        public void Initialize(ScannerModel scannerModel)
        {
            _scannerModel = scannerModel;

            var rootPage = DebugSheet.Instance.GetOrCreateInitialPage("InGame");

            rootPage.AddPageLinkButton<ScannerPage>("QrCodeScanner", onLoad: x => x.page.Setup(_qrCodeScannerScreen, _scannerModel));
        }
    }
}

#endif