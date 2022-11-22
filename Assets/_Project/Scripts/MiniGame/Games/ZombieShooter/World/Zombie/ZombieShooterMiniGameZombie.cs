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
        
        public event Action<bool>? OnKilled; // bool - хедшот или нет

        private void Awake()
        {
            _head.OnShot += () => {
                OnKilled?.Invoke(true);
                IsKilled = true;
            };
            _body.OnShot += () => {
                OnKilled?.Invoke(false);
                IsKilled = true;
            };
        }
        
        public bool IsKilled { get; private set; }
        
        //TODO Ходить с остановками в случайные места в комнате
    }
}
