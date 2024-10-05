#nullable enable

namespace Common.QRCode
{
    public class QrCodeScannerModel
    {
        public bool IsScannerEnable { get; set; } = true;
        public string QrScanResult { get; set; } = string.Empty;
    }
}