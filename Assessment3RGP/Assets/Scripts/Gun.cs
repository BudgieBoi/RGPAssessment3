using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
	public GameObject shootUI;
	public Player player;
	public Player opponent;

	private bool isHovering = false;

	void Update()
	{
		// Check for hover
		if (isHovering && Input.GetMouseButtonDown(0))
		{
			// Show shoot options
			shootUI.SetActive(true);
		}
	}

	void OnMouseEnter()
	{
		isHovering = true;
		// Display gun description
		DisplayTooltip("Shotgun", "Click to choose who to shoot.");
	}

	void OnMouseExit()
	{
		isHovering = false;
		// Hide tooltip
		HideTooltip();
	}

	public void ShootPlayer()
	{
		player.LoseHealth();
		shootUI.SetActive(false);
		// Proceed to the next turn
	}

	public void ShootOpponent()
	{
		opponent.LoseHealth();
		shootUI.SetActive(false);
		// Proceed to the next turn
	}

	private void DisplayTooltip(string itemName, string description)
	{
		// Implement a UI tooltip to display the name and description
	}

	private void HideTooltip()
	{
		// Hide the tooltip UI
	}
}