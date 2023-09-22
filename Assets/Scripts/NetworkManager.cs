using System.Collections;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class NetworkManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] TMP_InputField imputedText;

        private PhotonView m_View;

        private void Start()
        {
            m_View = GetComponent<PhotonView>();
        }

        public void SendButton()
        {
            m_View.RPC("SendData", RpcTarget.AllBuffered, imputedText.text);
        }

        [PunRPC]
        public void SendData(string messageText)
        {
            text.text = messageText;
        }
    }
}