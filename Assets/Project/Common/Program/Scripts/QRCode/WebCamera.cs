#nullable enable

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class WebCamera : MonoBehaviour
    {
        [SerializeField] private RawImage _cameraScreen = null!;
        [SerializeField] private TextMeshProUGUI _buttonText = null!;
        [SerializeField] private TextMeshProUGUI _resultText = null!;
        private WebCamTexture? _webCamTexture;
        private QRCodeReader _qrCodeReader = new();
        private bool _isCameraStart = false;

        private void Update()
        {
            if (_isCameraStart)
            {
                _resultText.text = _qrCodeReader?.ReadQRCodeWebCamTexture(_webCamTexture);
            }
        }

        public void HandleClick()
        {
            if (!_isCameraStart)
            {
                StartCamera();
            }
            else
            {
                _resultText.text = string.Empty;
                _webCamTexture?.Stop();
                _buttonText.text = "Start Camera";
                _isCameraStart = false;
            }
        }

        private void StartCamera()
        {
            if (_webCamTexture == null)
            {
                float width = _cameraScreen.rectTransform.rect.width;
                float height = _cameraScreen.rectTransform.rect.height;
                _webCamTexture = new((int)width, (int)height)
                {
                    autoFocusPoint = new Vector2(width * 0.5f, height * 0.5f)
                };
                _cameraScreen.texture = _webCamTexture;
            }
            _webCamTexture.Play();
            _buttonText.text = "Stop Camera";
            _isCameraStart = true;
        }
    }
}