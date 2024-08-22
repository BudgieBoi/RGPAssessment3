using UnityEngine;

public enum ItemType { Cross, Syringe, Mirror, Coin }

public class Item : MonoBehaviour
{
	public ItemType itemType;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void UseItem()
    {
        switch (itemType)
        {
            case ItemType.Cross:
                UseCross();
                break;
            case ItemType.Syringe:
                UseSyringe();
                break;
            case ItemType.Mirror:
                UseMirror();
                break;
            case ItemType.Coin:
                UseCoin();
                break;
        }

        gameManager.UpdateHealthUI();
    }

    void UseCross()
    {
        // Cross logic: Make the opponent do only one action during their turn
        gameManager.opponentHasSingleAction = true; // Flag to allow only one action for the opponent

        Debug.Log("Player used Cross: Opponent can only take one action during their turn.");
    }

    void UseSyringe()
    {
        // Syringe logic: Add 1 health to the player
        gameManager.playerHealth = Mathf.Min(gameManager.playerHealth + 1, 3); // Ensure health doesn't exceed max health

        Debug.Log("Player used Syringe: +1 Health.");
    }

    void UseMirror()
    {
        // Mirror logic: Copy opponent's item (but not another Mirror)
        Item opponentItem = gameManager.opponentItemSlot.GetComponentInChildren<Item>();

        if (opponentItem != null && opponentItem.itemType != ItemType.Mirror)
        {
            this.itemType = opponentItem.itemType; // Copy the opponent's item type
            UseItem(); // Use the copied item immediately
        }
        else
        {
            Debug.Log("Player used Mirror: No valid item to copy.");
        }
    }

    void UseCoin()
    {
        // Coin logic: Get a random item
        ItemType randomItem = (ItemType)Random.Range(0, System.Enum.GetValues(typeof(ItemType)).Length);

        // Change this item's type to the randomly selected item
        this.itemType = randomItem;

        Debug.Log("Player used Coin: Got a random item - " + randomItem.ToString());

        // Use the randomly assigned item immediately
        UseItem();
    }

	void CopyOpponentItem()
	{
		Item opponentItem = gameManager.opponentItemSlot.GetComponentInChildren<Item>();
		if (opponentItem != null && opponentItem.itemType != ItemType.Mirror)
		{
			this.itemType = opponentItem.itemType;
			UseItem(); // Use the copied item immediately
		}
	}

	void UseRandomItem()
	{
		itemType = (ItemType)Random.Range(0, System.Enum.GetValues(typeof(ItemType)).Length);
		UseItem(); // Use the random item immediately
	}
}