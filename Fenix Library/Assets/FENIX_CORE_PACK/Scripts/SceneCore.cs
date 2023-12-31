using Fenix.Animations;
using UnityEngine;

public class SceneCore : MonoBehaviour
{
	public static SceneCore Instance { get; private set; }

	public Anime _animationMachine;

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
}
