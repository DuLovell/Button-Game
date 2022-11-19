using _Project.Scripts.MiniGame.Common;
using _Project.Scripts.UI;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.MiniGame.Games.Test
{
	public class TestMiniGameView : View, IMiniGameView
	{
		[SerializeField]
		private TextMeshProUGUI _tapCounterTextMesh = null!;
		[Inject]
		private TestMiniGameModel _gameModel = null!;

		public void DestroyView()
		{
			Destroy(gameObject);
		}

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
