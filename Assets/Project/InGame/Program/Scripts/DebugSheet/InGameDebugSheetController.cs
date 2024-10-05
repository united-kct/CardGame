#if !EXCLUDE_UNITY_DEBUG_SHEET
#nullable enable

using Common.QRCode;
using UnityDebugSheet.Runtime.Core.Scripts;
using UnityEngine;
using UnityEngine.UI;

public sealed class InGameDebugSheetController : MonoBehaviour
{
    [SerializeField] private RawImage _qrCodeScannerScreen = null!;
    private QrCodeScannerModel _scannerModel = null!;

    public void Initialize(QrCodeScannerModel scannerModel)
    {
        _scannerModel = scannerModel;

        var rootPage = DebugSheet.Instance.GetOrCreateInitialPage("InGame");

        rootPage.AddPageLinkButton<QrCodeScannerPage>("QrCodeScanner", onLoad: x => x.page.Setup(_qrCodeScannerScreen, _scannerModel));
    }
}

#endif