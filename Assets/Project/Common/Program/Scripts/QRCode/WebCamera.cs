#nullable enable

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.QRCode
{
    public class WebCamera : MonoBehaviour
    {
        [SerializeField] private RawImage _cameraScreen = null!;
        [SerializeField] private TextMeshProUGUI _qrScanResultUI = null!;
        private WebCamTexture? _webCamTexture;
        private bool _isCameraVisible = false;
        public string QrScanResult { get; private set; } = string.Empty;

        private void Start()
        {
            StartCamera();
        }

        private void Update()
        {
            if (_webCamTexture != null)
            {
                QrScanResult = QRCodeReader.ReadQRCodeWebCameraTexture(_webCamTexture);
                _qrScanResultUI.text = QrScanResult;
            }
        }

        public void HandleClick()
        {
            if (_isCameraVisible)
            {
                _cameraScreen.gameObject.SetActive(false);
                _qrScanResultUI.gameObject.SetActive(false);
                _isCameraVisible = false;
            }
            else
            {
                _cameraScreen.gameObject.SetActive(true);
                _qrScanResultUI.gameObject.SetActive(true);
                _isCameraVisible = true;
            }
        }

        private void StartCamera()
        {
            _cameraScreen.gameObject.SetActive(false);
            _qrScanResultUI.gameObject.SetActive(false);
            float width = _cameraScreen.rectTransform.rect.width;
            float height = _cameraScreen.rectTransform.rect.height;
            _webCamTexture = new((int)width, (int)height)
            {
                autoFocusPoint = new Vector2(width * 0.5f, height * 0.5f)
            };
            _cameraScreen.texture = _webCamTexture;
            _webCamTexture.Play();
        }
    }
}