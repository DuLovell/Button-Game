using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Zenject;

namespace _Project.Scripts.MiniGame.Games
{
	[UsedImplicitly]
	public class TestMiniGameLogic
	{
		[Inject]
		private TestMiniGameWorld _gameWorld = null!;
		[Inject]
		private TestMiniGameDescriptor _gameDescriptor = null!;

		public event Action<bool>? OnGameFinished;

		private CancellationTokenSource? _cancelToken;
		private int _tapCounter;

		public void StartGame()
		{
			_cancelToken = new CancellationTokenSource();
			_tapCounter = 0;

			Cube.StartRotating();
			CheckLoseAsync().Forget();
		}

		public void OnMainButtonPressed()
		{
			_tapCounter++;
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
			if (_tapCounter < _gameDescriptor.TapsToWin) {
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
