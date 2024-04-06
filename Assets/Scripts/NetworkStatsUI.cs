using UnityEngine;
using UnityEngine.UI;
public class NetworkStatsUI : MonoBehaviour
{
    [SerializeField] private GameObject networkStatsDisplay;
    [SerializeField] private Button statsButton;
    public void Awake()
    {
        statsButton.onClick.AddListener(() =>
        {
            networkStatsDisplay.SetActive(!networkStatsDisplay.activeSelf);
        });
    }
}
