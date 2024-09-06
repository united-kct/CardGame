#nullable enable

using UnityEngine;
using ZXing;

namespace Common
{
    public static class QRCodeReader
    {
        public static string ReadQRCodeWebCameraTexture(WebCamTexture? tex)
        {
            if (tex == null)
            {
                return string.Empty;
            }

            BarcodeReader reader = new();
            Result r = reader.Decode(tex.GetPixels32(), tex.width, tex.height);

            return r != null ? r.Text : string.Empty;
        }
    }
}