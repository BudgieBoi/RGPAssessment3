using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
	public int playerHealth = 3;
	public int opponentHealth = 3;
	public int maxShells = 6;
	public TextMeshProUGUI playerHealthText;
	public TextMeshProUGUI opponentHealthText;
	public TextMeshProUGUI shellCountText;
	public GameObject[] items;
	public Transform playerItemSlot;
	public Transform opponentItemSlot;

	public int currentShells;
	private GameObject playerItem;
	private GameObject opponentItem;
	private System.Random random = new System.Random();
	public bool opponentHasSingleAction;

	public GameObject gameOverPanel;

	void Start()
	{
		gameOverPanel.SetActive(false);
		NewRound();
	}

	void NewRound()
	{
		currentShells = random.Next(2, maxShells + 1);
		shellCountText.text = "Bullets: " + currentShells;

		playerItem = Instantiate(items[random.Next(items.Length)], playerItemSlot);
		opponentItem = Instantiate(items[random.Next(items.Length)], opponentItemSlot);

		UpdateHealthUI();
	}

	public void Shoot(bool shootSelf)
	{
		if (currentShells > 0)
		{
			currentShells--;
			if (shootSelf)
			{
				playerHealth--;
				if (playerHealth <= 0) EndGame(false);
			}
			else
			{
				opponentHealth--;
				if (opponentHealth <= 0) EndGame(true);
			}
		}

		if (currentShells <= 0) NewRound();

		UpdateHealthUI();
	}

	public void UpdateHealthUI()
	{
		playerHealthText.text = "Player Health: " + playerHealth;
		opponentHealthText.text = "Opponent Health: " + opponentHealth;
		shellCountText.text = "Shells: " + currentShells;
	}

	void EndGame(bool playerWon)
	{
		// Display game over message and restart or quit options
		Debug.Log(playerWon ? "Player Wins!" : "Opponent Wins!");
		gameOverPanel.SetActive(true);
	}
}