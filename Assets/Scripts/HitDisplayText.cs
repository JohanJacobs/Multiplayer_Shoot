using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class HitDisplayText : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private TextMeshProUGUI hitsDisplay;
    private void Awake()
    {
        PlayerStats.OnReceivedHit += PlayerStats_OnRecievedhit;
    }

    private void PlayerStats_OnRecievedhit()
    {
        UpdateDisplay(playerStats.HITS);
    }

    private void UpdateDisplay(int value)
    {
        hitsDisplay.text = value.ToString();
    }

}
