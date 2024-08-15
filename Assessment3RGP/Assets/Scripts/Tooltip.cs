using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
	public Text tooltipText;
	public GameObject tooltipObject;

	public void ShowTooltip(string itemName, string description)
	{
		tooltipObject.SetActive(true);
		tooltipText.text = $"{itemName}\n{description}";
	}

	public void HideTooltip()
	{
		tooltipObject.SetActive(false);
	}
}