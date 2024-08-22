using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject descriptionPanel;
    public TextMeshProUGUI descriptionText;

    private Item currentItem;
    private GameObject hoveredObject;

    // Gun control variables
    public Transform gun; // Reference to the gun's Transform
    public Transform playerGunPosition; // Position in front of the player
    public Transform opponentGunPosition; // Position in front of the opponent
    public float gunMoveSpeed = 2f;

    // UI Buttons
    public GameObject shootSelfButton;
    public GameObject shootOpponentButton;

    // Input control
    private bool inputDisabled = false;

    void Start()
    {
        descriptionPanel.SetActive(false);

        shootSelfButton.SetActive(false);  // Hide the shoot buttons at the start
        shootOpponentButton.SetActive(false);
    }

    void Update()
    {
        if (!inputDisabled)
        {
            HandleMouseHover();
            HandleMouseClick();
        }
    }

    void HandleMouseHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject != hoveredObject)
            {
                hoveredObject = hitObject;

                if (hoveredObject.CompareTag("Gun"))
                {
                    ShowGunInfo();
                }
                else if (hoveredObject.CompareTag("Cross") || 
                         hoveredObject.CompareTag("Syringe") || 
                         hoveredObject.CompareTag("Mirror") || 
                         hoveredObject.CompareTag("Coin"))
                {
                    ShowItemInfo(hoveredObject);
                }
                else
                {
                    HideInfo();
                }
            }
        }
        else
        {
            hoveredObject = null;
            HideInfo();
        }
    }

    void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && hoveredObject != null)
        {
            if (hoveredObject.CompareTag("Gun"))
            {
                StartCoroutine(OnGunClick());
            }
            else if (hoveredObject.CompareTag("Cross") || 
                     hoveredObject.CompareTag("Syringe") || 
                     hoveredObject.CompareTag("Mirror") || 
                     hoveredObject.CompareTag("Coin"))
            {
                OnItemClick(hoveredObject);
            }
        }
    }

    void ShowGunInfo()
    {
        descriptionPanel.SetActive(true);
        descriptionText.text = "308 Rifle\nA powerful weapon with a chance to fire a live or blank Round.";
    }

    void ShowItemInfo(GameObject itemObject)
    {
        ItemType itemType = GetItemTypeFromTag(itemObject.tag);
        descriptionPanel.SetActive(true);
        descriptionText.text = GetItemDescription(itemType);
        currentItem = itemObject.GetComponent<Item>();
    }

    void HideInfo()
    {
        descriptionPanel.SetActive(false);
    }

    IEnumerator OnGunClick()
    {
        // Disable input
        inputDisabled = true;

        // Play gun animation
        PlayGunAnimation();

        // Pan camera up towards the opponent
        // Display shoot options
        shootSelfButton.SetActive(true);
        shootOpponentButton.SetActive(true);

        // Wait for player to make a choice
        while (!shootSelfButton.GetComponent<Button>().onClick.GetPersistentEventCount().Equals(0) && !shootOpponentButton.GetComponent<Button>().onClick.GetPersistentEventCount().Equals(0))
        {
            yield return null;
        }

        // Determine the target position based on player choice
        Transform targetPosition = shootSelfButton.GetComponent<Button>().onClick.GetPersistentEventCount().Equals(0) ? playerGunPosition : opponentGunPosition;

        // Move gun to the selected target position
        // Execute shooting logic
        if (targetPosition == playerGunPosition)
        {
            gameManager.Shoot(true);  // Shoot self
        }
        else
        {
            gameManager.Shoot(false); // Shoot opponent
        }

        // Hide shoot options
        shootSelfButton.SetActive(false);
        shootOpponentButton.SetActive(false);
    }

    void OnItemClick(GameObject itemObject)
    {
        if (currentItem != null)
        {
            currentItem.UseItem();
            HideInfo();
        }
    }

    string GetItemDescription(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Cross:
                return "Cross\nAllows only one action for the opponent on their turn.";
            case ItemType.Syringe:
                return "Syringe\nRestores 1 health point.";
            case ItemType.Mirror:
                return "Mirror\nCopies the opponent's item (except Mirror).";
            case ItemType.Coin:
                return "Coin\nGrants a random item.";
            default:
                return "Unknown Item";
        }
    }

    ItemType GetItemTypeFromTag(string tag)
    {
        switch (tag)
        {
            case "Cross": return ItemType.Cross;
            case "Syringe": return ItemType.Syringe;
            case "Mirror": return ItemType.Mirror;
            case "Coin": return ItemType.Coin;
            default: return ItemType.Cross;
        }
    }

    void PlayGunAnimation()
    {
        // Trigger gun animation here
    }
}
