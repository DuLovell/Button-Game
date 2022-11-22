using System;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie
{
    public interface IShootable
    {
        event Action? OnShot;
        
        void Shoot();
    }
}