using _Project.Scripts.MainButton;
using _Project.Scripts.UI;
using Cysharp.Threading.Tasks;
using Zenject;

namespace _Project.Scripts.MiniGame.Games.Ui
{
	public class ReadyOverlay : View
	{
		[Inject]
		private MainButtonController _mainButtonController = null!;
		
		public async UniTask ShowAsync()
		{
			gameObject.SetActive(true);
			await UniTask.WaitUntil(_mainButtonController.IsButtonTouched);
			Hide();
		}
		
		private void Awake()
		{
			Hide();
		}
		
		private void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}
