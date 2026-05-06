using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public int coinsCollected = 0;
    public int coinsNeeded = 10;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI finalStatsText;

    public GameObject completionPanel;
    public Transform player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        completionPanel.SetActive(false);
        UpdateCoinText();
    }

    private void Update()
    {
        UpdateNearestCoinDistance();
    }

    public void AddCoin()
    {
        coinsCollected++;
        UpdateCoinText();

        if (coinsCollected >= coinsNeeded)
        {
            CompleteLevel();
        }
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins collected: " + coinsCollected + "/" + coinsNeeded;
    }

    void UpdateNearestCoinDistance()
    {
        if (coinsCollected >= coinsNeeded) return;

        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        if (coins.Length == 0)
        {
            distanceText.text = "No coins left!";
            return;
        }

        float closestDistance = Mathf.Infinity;

        foreach (GameObject coin in coins)
        {
            float distance = Vector3.Distance(player.position, coin.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
            }
        }

        distanceText.text = "Nearest coin: " + closestDistance.ToString("F1") + " m";
    }

    void CompleteLevel()
    {
        completionPanel.SetActive(true);

        distanceText.text = "All coins collected!";

        if (finalStatsText != null)
        {
            finalStatsText.text = "Coins Collected: " + coinsCollected + "/" + coinsNeeded;
        }

        Debug.Log("Level Complete!");
    }
}