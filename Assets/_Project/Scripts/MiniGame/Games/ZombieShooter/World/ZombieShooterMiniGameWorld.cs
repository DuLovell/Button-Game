using System;
using _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World
{
	public class ZombieShooterMiniGameWorld : MonoBehaviour
	{
		public event Action<bool>? OnAnyZombieKilled;
		
		private void OnEnable()
		{
			ZombieShooterMiniGameZombie.OnAnyKilled += OnAnyKilled;
		}

		private void OnDisable()
		{
			ZombieShooterMiniGameZombie.OnAnyKilled -= OnAnyKilled;
		}
		
		private void OnAnyKilled(bool headShot)
		{
			OnAnyZombieKilled?.Invoke(headShot);
		}
		
		//TODO Заспавнить зомби
	}
}
