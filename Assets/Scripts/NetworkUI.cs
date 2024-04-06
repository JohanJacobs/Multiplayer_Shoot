using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class NetworkUI : MonoBehaviour
{
    [SerializeField] private Button clientButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button serverButton;
    private void Awake()
    {

        clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });

        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });

        serverButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });
    }
}
