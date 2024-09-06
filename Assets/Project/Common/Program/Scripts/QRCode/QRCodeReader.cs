#nullable enable

using UnityEngine;
using ZXing;

namespace Common
{
    public class QRCodeReader
    {
        public string ReadQRCodeTexture(Texture2D tex)
        {
            BarcodeReader reader = new BarcodeReader();
            // 読み込み
            Result r = reader.Decode(tex.GetPixels32(), tex.width, tex.height);

            return r != null ? r.Text : string.Empty;
        }

        public string ReadQRCodeWebCamTexture(WebCamTexture? tex)
        {
            if (tex == null)
            {
                return string.Empty;
            }

            BarcodeReader reader = new();
            // 読み込み
            ZXing.Result r = reader.Decode(tex.GetPixels32(), tex.width, tex.height);

            return r != null ? r.Text : string.Empty;
        }
    }
}