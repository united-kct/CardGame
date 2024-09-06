#nullable enable

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class WebCamera : MonoBehaviour
    {
        [SerializeField] private RawImage _cameraScreen = null!;
        [SerializeField] private TextMeshProUGUI _qrScanResult = null!;
        private WebCamTexture? _webCamTexture;
        private bool _isCameraVisible = false;

        private void Start()
        {
            StartCamera();
        }

        private void Update()
        {
            if (_webCamTexture != null)
            {
                _qrScanResult.text = QRCodeReader.ReadQRCodeWebCameraTexture(_webCamTexture);
            }
        }

        public void HandleClick()
        {
            if (_isCameraVisible)
            {
                _cameraScreen.gameObject.SetActive(false);
                _qrScanResult.gameObject.SetActive(false);
                _isCameraVisible = false;
            }
            else
            {
                _cameraScreen.gameObject.SetActive(true);
                _qrScanResult.gameObject.SetActive(true);
                _isCameraVisible = true;
            }
        }

        private void StartCamera()
        {
            float width = _cameraScreen.rectTransform.rect.width;
            float height = _cameraScreen.rectTransform.rect.height;
            _webCamTexture = new((int)width, (int)height)
            {
                autoFocusPoint = new Vector2(width * 0.5f, height * 0.5f)
            };
            _cameraScreen.gameObject.SetActive(false);
            _qrScanResult.gameObject.SetActive(false);
            _cameraScreen.texture = _webCamTexture;
            _webCamTexture.Play();
        }
    }
}