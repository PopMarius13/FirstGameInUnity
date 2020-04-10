using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text CoinsText , livesText;
    public void UpdateCoinsDisplay (int coins)
    {
        CoinsText.text = "Coins: " + coins.ToString();
    }

    public void UpdateLives (int lives)
    {
        livesText.text = "Lives: " + lives.ToString();
    }
}
