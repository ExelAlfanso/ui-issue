using TMPro;
using UnityEngine;

public class UILottery : MonoBehaviour
{

    public int lotteryAmount = 0;
    void IncrementLottery()
    {
        lotteryAmount++;
    }
    void OnEnable()
    {
        IncrementLottery();
    }
}
