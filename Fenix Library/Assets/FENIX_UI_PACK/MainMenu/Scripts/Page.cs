using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
	private Animator animator;

	[SerializeField]
	private List<Button> buttons;

	private void Awake()
	{
		animator = GetComponent<Animator>();

		DisableButtons();
		SetButtonsAsInvisible();
	}

	#region Animations

	public void PlayFowardAnimationAsNextPage()
	{
		animator.SetTrigger("foward_next");
	}

	public void PlayBackwardAnimation()
	{
		animator.SetTrigger("backward_last");
	}

	public void FadeOut()
	{
		var anime = SceneCore.Instance.GetAnimationMachine();

		foreach (var btn in buttons)
		{
			StartCoroutine(anime.FadeOut(btn.GetComponent<Graphic>(), 0.2f));
			StartCoroutine(anime.FadeOut(btn.transform.GetChild(0).
				GetComponent<TextMeshProUGUI>().GetComponent<Graphic>(), 0.2f));
		}
	}

	public void FadeIn()
	{
		var anime = SceneCore.Instance.GetAnimationMachine();

		foreach (var btn in buttons)
		{
			StartCoroutine(anime.FadeIn(btn.GetComponent<Graphic>(), 0.2f));
			StartCoroutine(anime.FadeIn(btn.transform.GetChild(0).
				GetComponent<TextMeshProUGUI>().GetComponent<Graphic>(), 0.2f));
		}
	}

	#endregion

	public void EnableButtons()
	{
		buttons.ForEach(btn => btn.interactable = true);
	}

	public void DisableButtons()
	{
		buttons.ForEach(btn => btn.interactable = false);
	}

	public void SetButtonsAsVisible()
	{
		foreach (var btn in buttons)
		{
			SetAsVisible(btn.GetComponent<Graphic>());
			SetAsVisible(btn.transform.GetChild(0).
				GetComponent<TextMeshProUGUI>().GetComponent<Graphic>());
		}
	}

	public void SetButtonsAsInvisible()
	{
		foreach (var btn in buttons)
		{
			SetAsInvisible(btn.GetComponent<Graphic>());
			SetAsInvisible(btn.transform.GetChild(0).
				GetComponent<TextMeshProUGUI>().GetComponent<Graphic>());
		}
	}

	#region Utils

	private void SetAsInvisible(Graphic graphic)
	{
		Color originalColor = graphic.color;
		graphic.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
	}

	private void SetAsVisible(Graphic graphic)
	{
		Color originalColor = graphic.color;
		graphic.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
	}

	#endregion
}
