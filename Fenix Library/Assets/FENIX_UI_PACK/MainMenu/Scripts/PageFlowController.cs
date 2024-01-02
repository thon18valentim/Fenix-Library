using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageFlowController : MonoBehaviour
{
	[SerializeField]
	private List<Page> Pages;

	[SerializeField]
	private Button FowardPageButton;

	[SerializeField]
	private Button BackwardPageButton;

	private int currentPageIndex;
	private int lastPageIndex;
	private int nextPageIndex;

	public static PageFlowController Instance { get; private set; }
	private SceneCore sceneCore;

	private void Awake()
	{
		Instance = this;
	}

	public void Startup()
	{
		currentPageIndex = 0;
		lastPageIndex = -1;
		nextPageIndex = -1;

		Pages[currentPageIndex].EnableButtons();
		Pages[currentPageIndex].SetButtonsAsVisible();
		SetCurrentPageInFrontOfScreen();

		FowardPageButton.interactable = false;
		BackwardPageButton.interactable = false;

		sceneCore = SceneCore.Instance;
		sceneCore.SetSceneTitles(Pages[currentPageIndex].GetTitles());
	}

	#region Controlls

	public void AdvanceToPage(int pageIndex)
	{
		StartCoroutine(FowardPage(pageIndex));
	}

	public void BackToPage(int pageIndex)
	{
		StartCoroutine(BackwardPage(pageIndex));
	}

	public void FowardToNextPage()
	{
		if (nextPageIndex == -1)
			return;

		AdvanceToPage(nextPageIndex);
	}

	public void BackWardToLastPage()
	{
		if (lastPageIndex == -1) 
			return;

		BackToPage(lastPageIndex);
	}

	#endregion

	#region Animations

	private IEnumerator FowardPage(int nextPage)
	{
		Pages[currentPageIndex].FadeOut();
		Pages[currentPageIndex].DisableButtons();
		
		yield return new WaitForSeconds(0.3f);

		Pages[nextPage].EnableButtons();
		Pages[nextPage].PlayFowardAnimationAsNextPage();
		Pages[nextPage].FadeIn();

		lastPageIndex = currentPageIndex;
		currentPageIndex = nextPage;
		nextPageIndex = -1;

		SetCurrentPageInFrontOfScreen();

		sceneCore.SetSceneTitles(Pages[currentPageIndex].GetTitles());

		FowardPageButton.interactable = false;
		BackwardPageButton.interactable = true;
	}

	private IEnumerator BackwardPage(int lastPage)
	{
		Pages[currentPageIndex].FadeOut();
		Pages[currentPageIndex].DisableButtons();

		yield return new WaitForSeconds(0.3f);

		Pages[lastPage].EnableButtons();
		Pages[lastPage].PlayBackwardAnimation();
		Pages[lastPage].FadeIn();

		nextPageIndex = currentPageIndex;
		currentPageIndex = lastPage;

		SetCurrentPageInFrontOfScreen();

		if (currentPageIndex == 0)
		{
			lastPageIndex = -1;
			BackwardPageButton.interactable = false;
		}
		else
		{
			lastPageIndex = lastPage - 1;
			BackwardPageButton.interactable = true;
		}

		sceneCore.SetSceneTitles(Pages[currentPageIndex].GetTitles());

		FowardPageButton.interactable = true;
	}

	#endregion

	public void SetCurrentPageInFrontOfScreen()
	{
		var childObject = Pages[currentPageIndex].gameObject;
		childObject.transform.SetAsLastSibling();
	}
}
