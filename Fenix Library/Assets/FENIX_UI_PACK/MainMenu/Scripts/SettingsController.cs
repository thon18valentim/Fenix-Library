using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
	[SerializeField]
	private Button SettingsBtn;

	[SerializeField]
	private GameObject SettingsModal;

	private bool isModalOpen;

	public void Startup()
	{
		isModalOpen = false;
	}

	public void ShowSettingsDropdown()
	{
		isModalOpen = !isModalOpen;
		SettingsModal.SetActive(isModalOpen);
	}
}
