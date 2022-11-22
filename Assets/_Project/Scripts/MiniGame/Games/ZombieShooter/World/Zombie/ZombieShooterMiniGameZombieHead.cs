using System;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie
{
    public class ZombieShooterMiniGameZombieHead : MonoBehaviour, IShootable
    {
        public event Action? OnShot;

        public void Shoot()
        {
            OnShot?.Invoke();
        }
    }
}