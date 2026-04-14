using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject lotteryUI;
    public TextMeshProUGUI refresherUIEnabledText;
    public enum Language
    {
        English,
        Spanish,
        French,
        German,
        Chinese
    }
    public Language currentLanguage = Language.English;
    public TextMeshProUGUI currentLanguageText;
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

    public void CycleLanguage()
    {
        currentLanguage = (Language)(((int)currentLanguage + 1) % System.Enum.GetValues(typeof(Language)).Length);
        switch (currentLanguage)
        {
            case Language.English:
                lotteryUI.GetComponentInChildren<TextMeshProUGUI>().text = "Lottery Amount: " + lotteryUI.GetComponent<UILottery>().lotteryAmount;
                break;
            case Language.Spanish:
                lotteryUI.GetComponentInChildren<TextMeshProUGUI>().text = "Cantidad de Lotería: " + lotteryUI.GetComponent<UILottery>().lotteryAmount;
                break;
            case Language.French:
                lotteryUI.GetComponentInChildren<TextMeshProUGUI>().text = "Montant de la loterie: " + lotteryUI.GetComponent<UILottery>().lotteryAmount;
                break;
            case Language.German:
                lotteryUI.GetComponentInChildren<TextMeshProUGUI>().text = "Lotto Betrag: " + lotteryUI.GetComponent<UILottery>().lotteryAmount;
                break;
            case Language.Chinese:
                lotteryUI.GetComponentInChildren<TextMeshProUGUI>().text = "彩票金额: " + lotteryUI.GetComponent<UILottery>().lotteryAmount;
                break;
        }
        currentLanguageText.text = "Current Language: " + currentLanguage.ToString();
    }
    public void RefreshUI()
    {
        lotteryUI.GetComponent<RefreshUI>().StartRefresh();
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
        lotteryUI.GetComponent<RefreshUI>().enabled = !lotteryUI.GetComponent<RefreshUI>().enabled;
    }

}
