#nullable enable

using Common.QRCode;
using R3;
using R3.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Title.Program.Scripts.Title
{
    public class TitlePresenter : MonoBehaviour
    {
        private ScannerModel _scannerModel = null!;
        
        public void Initialize(ScannerModel scannerModel)
        {
            _scannerModel = scannerModel;

            this.UpdateAsObservable().Subscribe(_ => OnScan()).AddTo(this);
        }

        private void OnScan()
        {
            if (_scannerModel.QrScanResult != "")
            {
                SceneManager.LoadScene("RuleExplanation");
            }
        }
    }
}
