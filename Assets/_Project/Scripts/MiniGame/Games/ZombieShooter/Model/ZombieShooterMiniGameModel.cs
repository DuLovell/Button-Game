﻿using _Project.Scripts.MiniGame.Common;
using JetBrains.Annotations;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.Model
{
	[UsedImplicitly]
	public class ZombieShooterMiniGameModel : IMiniGameModel
	{
		public int AmmoCount;
		public float AimMoveSpeed;
		public int ZombieKilledCount;
		public int RoomClearedCount;
		
		public void Reset()
		{
			AmmoCount = 0;
			AimMoveSpeed = 0f;
			ZombieKilledCount = 0;
			RoomClearedCount = 0;
		}
	}
}