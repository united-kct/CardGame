#nullable enable

using Cysharp.Threading.Tasks;
using R3;
using R3.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace Common.QRCode
{
    public class QrCodeScanner : MonoBehaviour
    {
        [SerializeField] private RawImage _scannerScreen = null!;
        private QrCodeScannerModel _model = null!;
        private WebCamTexture? _webCamTexture;

        public void Initialize(QrCodeScannerModel model)
        {
            _model = model;

            StartCamera();

            this.UpdateAsObservable().Subscribe(_ => UpdateQrScanResult()).AddTo(this);
        }

        private void StartCamera()
        {
            var rect = _scannerScreen.rectTransform.rect;
            var width = rect.width;
            var height = rect.height;
            _webCamTexture = new((int)width, (int)height)
            {
                autoFocusPoint = new Vector2(width * 0.5f, height * 0.5f)
            };
            _scannerScreen.texture = _webCamTexture;
            _webCamTexture.Play();
        }

        private void UpdateQrScanResult()
        {
            if (_webCamTexture != null && _model.IsScannerEnable)
            {
                _model.QrScanResult = QRCodeReader.ReadQRCodeWebCameraTexture(_webCamTexture);
            }
        }

        //public void HandleDebugCamera()
        //{
        //    if (_isCameraVisible)
        //    {
        //        _cameraScreen.gameObject.SetActive(false);
        //        _qrScanResultUI.gameObject.SetActive(false);
        //        _isCameraVisible = false;
        //    }
        //    else
        //    {
        //        _cameraScreen.gameObject.SetActive(true);
        //        _qrScanResultUI.gameObject.SetActive(true);
        //        _isCameraVisible = true;
        //    }
        //}

        //public void HandleDebugScanResult()
        //{
        //    QrScanResult = "1";
        //    _isScanDisable = true;
        //}
    }
}