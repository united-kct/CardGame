#nullable enable

using UnityEngine;

namespace Common.QRCode
{
    public class ScannerModel
    {
        public bool IsScannerEnable { get; set; } = true;
        public string QrScanResult { get; set; } = string.Empty;
        public WebCamTexture CameraTexture { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ScannerModel()
        {
            Width = 200;
            Height = 200;
            CameraTexture = new(Width, Height)
            {
                autoFocusPoint = new Vector2(Width * 0.5f, Height * 0.5f)
            };
        }
    }
}