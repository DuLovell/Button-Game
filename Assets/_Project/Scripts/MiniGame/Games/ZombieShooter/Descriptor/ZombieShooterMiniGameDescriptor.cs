using UnityEngine;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.Descriptor
{
	[CreateAssetMenu(fileName = "ZombieShooterMiniGameDescriptor", menuName = "Data/MiniGames/ZombieShooter/Descriptor", order = 0)]
	public class ZombieShooterMiniGameDescriptor : ScriptableObject
	{
		[field: Header("Ammo")]
		[field: SerializeField]
		public int StartAmmoCount { get; private set; }
		[field: SerializeField]
		public int HeadshotBonusAmmo { get; private set; }
		
		[field: Header("Aim")]
		[field: SerializeField]
		public float StartAimMoveSpeed { get; private set; }
		[field: SerializeField]
		public float NextRoomAimMoveSpeedDelta { get; private set; }
		
		[field: Header("Zombies")]
		[field: SerializeField]
		public int InRoomZombieCount { get; private set; }
		[field: SerializeField]
		public GameObject ZombiePrefab { get; private set; } = null!;
	}
}
