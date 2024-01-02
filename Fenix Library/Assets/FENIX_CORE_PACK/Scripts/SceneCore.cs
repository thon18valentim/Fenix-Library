using Fenix.Animations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneCore : MonoBehaviour
{
	public static SceneCore Instance { get; private set; }

	public Anime _animationMachine;

	[SerializeField]
	private TextMeshProUGUI sceneTitle;
	[SerializeField]
	private TextMeshProUGUI sceneSubTitle;

	private void Awake()
	{
		Instance = this;
	}

	public void Start()
	{
		StartupAnimationMachine();
		StartupControllers();
	}

	private void StartupAnimationMachine()
	{
		_animationMachine = new Anime();
	}

	private void StartupControllers()
	{
		PageFlowController.Instance.Startup();
	}

	public Anime GetAnimationMachine()
	{
		return _animationMachine;
	}

	public void SetSceneTitles(Dictionary<string, string> titles)
	{
		sceneTitle.text = titles["Title"];
		sceneSubTitle.text = titles["SubTitle"];
	}
}
