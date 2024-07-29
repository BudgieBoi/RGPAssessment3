using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
	public GameManager gameManager;
	public Button crossButton;
	public Button syringeButton;
	public Button shootButton;
	public TextMeshProUGUI playerHealthText;
	public TextMeshProUGUI opponentHealthText;

	void Start()
	{
		crossButton.onClick.AddListener(OnCrossButtonClicked);
		syringeButton.onClick.AddListener(OnSyringeButtonClicked);
		shootButton.onClick.AddListener(OnShootButtonClicked);
	}

	void Update()
	{
		UpdateUI();
		crossButton.interactable = gameManager.isPlayerTurn && gameManager.player.crossPrefab != null;
		syringeButton.interactable = gameManager.isPlayerTurn && gameManager.player.syringePrefab != null;
		shootButton.interactable = gameManager.isPlayerTurn;
	}

	void OnCrossButtonClicked()
	{
		gameManager.player.UseCross(gameManager.opponent);
		if (gameManager.player.crossUsed)
		{
			gameManager.EndTurn();
		}
	}

	void OnSyringeButtonClicked()
	{
		gameManager.player.UseSyringe();
		if (gameManager.player.crossUsed)
		{
			gameManager.EndTurn();
		}
	}

	void OnShootButtonClicked()
	{
		gameManager.player.Shoot(gameManager.opponent);
		gameManager.EndTurn();
	}

	void UpdateUI()
	{
		playerHealthText.text = "Player Health: " + gameManager.player.health;
		opponentHealthText.text = "Opponent Health: " + gameManager.opponent.health;
	}
}