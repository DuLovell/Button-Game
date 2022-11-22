using System;
using System.Threading;
using _Project.Scripts.MiniGame.Common;
using _Project.Scripts.MiniGame.Games.Test.Model;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Zenject;
using Object = UnityEngine.Object;

namespace _Project.Scripts.MiniGame.Games.Test
{
	[UsedImplicitly]
	public class TestMiniGameLogic : IMiniGameLogic
	{
		[Inject]
		private TestMiniGameDescriptor _gameDescriptor = null!;
		[Inject]
		private TestMiniGameModel _gameModel = null!;

		public event Action<bool>? OnGameFinished;

		private TestMiniGameWorld _gameWorld = null!;
		private CancellationTokenSource? _cancelToken;

		public void StartGame()
		{
			_gameWorld = Object.FindObjectOfType<TestMiniGameWorld>();
			_cancelToken = new CancellationTokenSource();

			Cube.StartRotating();
			CheckLoseAsync().Forget();
		}

		public void OnMainButtonPressed()
		{
			_gameModel.TapCount++;
			CheckWin();
			Cube.InverseRotationDirection();
		}

		private void StopGame(bool win)
		{
			if (_cancelToken != null) {
				_cancelToken.Cancel();
				_cancelToken.Dispose();
				_cancelToken = null;
			}
			
			Cube.StopRotating();
			OnGameFinished?.Invoke(win);
		}

		private async UniTaskVoid CheckLoseAsync()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(_gameDescriptor.SecondsToWin), DelayType.DeltaTime, cancellationToken: _cancelToken!.Token);
			StopGame(false);
		}

		private void CheckWin()
		{
			if (_gameModel.TapCount < _gameDescriptor.TapsToWin) {
				return;
			}
			StopGame(true);
		}

		private TestMiniGameCube Cube
		{
			get { return _gameWorld.Cube; }
		}
	}
}
