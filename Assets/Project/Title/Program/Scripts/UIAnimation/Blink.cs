using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Project.Common.Program.Scripts.UIAnimation
{
    public class Fade : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        private float _alpha = 0;

        private void FixedUpdate()
        {
            text.alpha = _alpha;
        }
    }
}
