using System;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie
{
    public class ZombieShooterMiniGameZombie : MonoBehaviour
    {
        [SerializeField] 
        private ZombieShooterMiniGameZombieHead _head = null!;
        [SerializeField] 
        private ZombieShooterMiniGameZombieBody _body = null!;
        
        public static event Action<bool>? OnAnyKilled; // bool - хедшот или нет

        private void Awake()
        {
            _head.OnShot += () => OnAnyKilled?.Invoke(true);
            _body.OnShot += () => OnAnyKilled?.Invoke(false);
        }
        
        //TODO Ходить с остановками в случайные места в комнате
    }
}