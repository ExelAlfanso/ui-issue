using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject lotteryUI;
    public TextMeshProUGUI refresherUIEnabledText;
    public static GameManager Instance { get; private set; }
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }
    void Start()
    {
        refresherUIEnabledText.text = "Refresher UI is " + (lotteryUI.GetComponent<RefreshUI>().enabled ? "Enabled" : "Disabled");
    }
    public void ToggleLottery()
    {
        lotteryUI.SetActive(!lotteryUI.activeSelf);
    }

    public void EnableRefreshUI()
    {
        refresherUIEnabledText.text = "Refresher UI is " + (lotteryUI.GetComponent<RefreshUI>().enabled ? "Enabled" : "Disabled");
        var lotteryRefreshUIs = lotteryUI.GetComponentsInChildren<RefreshUI>(true);
        foreach (var refreshUI in lotteryRefreshUIs)
        {
            refreshUI.enabled = !refreshUI.enabled;
        }
    }

}
