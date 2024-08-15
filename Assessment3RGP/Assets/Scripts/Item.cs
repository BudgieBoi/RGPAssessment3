using UnityEngine;

public class Item : MonoBehaviour
{
	public string itemName;
	public string description;
	public Player player;
	public Player opponent;

	private bool isHovering = false;

	void Update()
	{
		// Check for hover and click
		if (isHovering && Input.GetMouseButtonDown(0))
		{
			UseItem();
		}
	}

	void OnMouseEnter()
	{
		isHovering = true;
		// Display item description
		DisplayTooltip(itemName, description);
	}

	void OnMouseExit()
	{
		isHovering = false;
		// Hide tooltip
		HideTooltip();
	}

	private void UseItem()
	{
		if (itemName == "Cross")
		{
			// Implement Cross logic
			// For example, make the opponent have only 1 turn
		}
		else if (itemName == "Syringe")
		{
			// Implement Syringe logic
			player.health++;
		}
		Destroy(gameObject); // Remove the item after use
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