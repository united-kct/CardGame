#nullable enable

using UnityEngine;

namespace Common
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Texture2D _texture = null!;

        // Start is called before the first frame update
        private void Start()
        {
            string str = new QRCodeReader().ReadQRCodeTexture(_texture);
            Debug.Log(str);
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}