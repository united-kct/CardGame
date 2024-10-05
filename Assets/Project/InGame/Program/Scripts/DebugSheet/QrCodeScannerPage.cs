#if !EXCLUDE_UNITY_DEBUG_SHEET
#nullable enable

using Common.QRCode;
using System.Threading.Tasks;
using UnityDebugSheet.Runtime.Core.Scripts;
using UnityDebugSheet.Runtime.Core.Scripts.DefaultImpl.Cells;
using UnityEngine.UI;

public sealed class QrCodeScannerPage : DefaultDebugPageBase
{
    protected override string Title => "QrCodeScanner";
    private RawImage _scannerScreen = null!;
    private QrCodeScannerModel _model = null!;
    private InputFieldCellModel _scanResultModel = null!;
    private int _scanResultId;

    private void Update()
    {
        _scanResultModel.Value = _model.QrScanResult;
        RefreshDataAt(_scanResultId);
    }

    public void Setup(RawImage scannerScreen, QrCodeScannerModel model)
    {
        _scannerScreen = scannerScreen;
        _model = model;
    }

    public override Task Initialize()
    {
        AddSwitch(_model.IsScannerEnable, "IsScannerEnable", valueChanged: x => { _model.IsScannerEnable = x; });

        _scanResultModel = new(false);
        _scanResultModel.CellTexts.Text = "QrScanResult";
        _scanResultModel.Value = _model.QrScanResult;
        _scanResultModel.Placeholder = "値は空です";
        _scanResultModel.ValueChanged += x => { _model.QrScanResult = x; };
        _scanResultId = AddInputField(_scanResultModel);

        AddSwitch(false, "QrCodeScannerScreenを表示する", valueChanged: x => { _scannerScreen.gameObject.SetActive(x); });

        return Task.CompletedTask;
    }
}

#endif