using System;
using System.Collections.Generic;
using _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World
{
	public class ZombieShooterMiniGameWorld : MonoBehaviour
	{
		[field: SerializeField]
		public Camera TVScreenCamera { get; private set; } = null!;
		[field: SerializeField]
		public List<ZombieShooterMiniGameZombie> Zombies { get; private set; } = new();

		//TODO Заспавнить зомби (пока вместо спавна serialize поле)
	}
}
