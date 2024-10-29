#if !EXCLUDE_UNITY_DEBUG_SHEET
#nullable enable

using Common.QRCode;
using UnityDebugSheet.Runtime.Core.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Title.Program.Scripts.Debug
{
    public class TitleDebugSheetController : MonoBehaviour
    {
        [SerializeField] private RawImage qrCodeScannerScreen = null!;

        public void Initialize(ScannerModel scannerModel)
        {
            var rootPage = DebugSheet.Instance.GetOrCreateInitialPage("Title");
            
            rootPage.AddPageLinkButton<ScannerPage>("QrCodeScanner", onLoad: x => x.page.Setup(qrCodeScannerScreen, scannerModel));
        }
    }
}

#endif
