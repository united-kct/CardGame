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
        //[SerializeField] private RawImage _scannerScreen = null!;
        private QrCodeScannerModel _model = null!;

        //private WebCamTexture? _webCamTexture;

        public void Initialize(QrCodeScannerModel model)
        {
            _model = model;

            _model.CameraTexture.Play();

            this.UpdateAsObservable().Subscribe(_ => UpdateQrScanResult()).AddTo(this);
        }

        //private void StartCamera()
        //{
        //    var rect = _scannerScreen.rectTransform.rect;
        //    var width = rect.width;
        //    var height = rect.height;
        //    _webCamTexture = new(_model.Width, _model.Height)
        //    {
        //        autoFocusPoint = new Vector2(width * 0.5f, height * 0.5f)
        //    };
        //    _scannerScreen.texture = _webCamTexture;
        //    _webCamTexture.Play();
        //}

        private void UpdateQrScanResult()
        {
            if (_model.IsScannerEnable)
            {
                _model.QrScanResult = QRCodeReader.ReadQRCodeWebCameraTexture(_model.CameraTexture);
            }
        }
    }
}