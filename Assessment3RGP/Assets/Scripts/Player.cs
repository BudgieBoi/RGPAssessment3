using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public int health = 3;
	public Transform itemSlot1, itemSlot2; // Assign these in the inspector for each player
	public GameObject[] itemPrefabs; // Array to hold Cross and Syringe prefabs

	private GameObject currentItem1, currentItem2;

	void Start()
	{
		// Randomly assign items at the start of each round
		AssignRandomItems();
	}

	public void AssignRandomItems()
	{
		if (currentItem1 != null) Destroy(currentItem1);
		if (currentItem2 != null) Destroy(currentItem2);

		currentItem1 = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], itemSlot1.position, Quaternion.identity, itemSlot1);
		currentItem2 = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], itemSlot2.position, Quaternion.identity, itemSlot2);
	}

	public void UseItem(int itemIndex)
	{
		// Implement item use logic
		// For example, if the player uses a cross, enforce only one turn
		// If using syringe, increase health by 1
	}

	public void LoseHealth()
	{
		health--;
		if (health <= 0)
		{
			// Handle player defeat
			Debug.Log("Player Defeated");
		}
	}
}