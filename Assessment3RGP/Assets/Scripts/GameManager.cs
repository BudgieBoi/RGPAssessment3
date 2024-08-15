using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Player player;
	public Player opponent;

	private Player currentPlayer;

	void Start()
	{
		currentPlayer = player; // Player starts first
	}

	public void EndTurn()
	{
		// Switch turn
		currentPlayer = currentPlayer == player ? opponent : player;

		// Assign new items
		currentPlayer.AssignRandomItems();
	}
}