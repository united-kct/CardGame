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
    }
}