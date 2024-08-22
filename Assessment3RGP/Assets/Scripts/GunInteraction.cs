using UnityEngine;
using UnityEngine.UI;

public class GunInteraction : MonoBehaviour
{
	public GameObject shootOptionsUI;
	public Button shootSelfButton;
	public Button shootOpponentButton;

	private GameManager gameManager;

	void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
		shootOptionsUI.SetActive(false);

		shootSelfButton.onClick.AddListener(() => Shoot(true));
		shootOpponentButton.onClick.AddListener(() => Shoot(false));
	}

	void OnMouseEnter()
	{
		// Display gun information
		ShowGunInfo();
	}

	void OnMouseExit()
	{
		// Hide gun information
		HideGunInfo();
	}

	void OnMouseDown()
	{
		// Show shooting options
		shootOptionsUI.SetActive(true);
	}

	void Shoot(bool shootSelf)
	{
		gameManager.Shoot(shootSelf);
		shootOptionsUI.SetActive(false);
	}

	void ShowGunInfo()
	{
		// Show UI with gun info
	}

	void HideGunInfo()
	{
		// Hide UI with gun info
	}
}