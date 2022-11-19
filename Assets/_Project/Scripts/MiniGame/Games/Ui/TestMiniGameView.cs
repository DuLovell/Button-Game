using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.MiniGame.Games.Ui
{
	public class TestMiniGameView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _tapCounterTextMesh = null!;
		[Inject]
		private TestMiniGameModel _gameModel = null!;

		private void Update()
		{
			TapCounter = _gameModel.TapCount.ToString();
		}

		private string TapCounter
		{
			set
			{
				_tapCounterTextMesh.text = value;
			}
		}
	}
}
