using UnityEngine;

namespace _Project.Scripts.Npc
{
	public class NpcAnimator : MonoBehaviour
	{
		private static readonly int _showHash = Animator.StringToHash("Show");
		private static readonly int _hideHash = Animator.StringToHash("Hide");
		private static readonly int _idleHash = Animator.StringToHash("Idle");
		private static readonly int _explodeHash = Animator.StringToHash("Explode");
		
		private Animator _animator = null!;

		public void PlayShow()
		{
			_animator.CrossFade(_showHash, 0);
		}

		public void PlayHide()
		{
			_animator.CrossFade(_hideHash, 0);
		}

		public void PlayIdle()
		{
			_animator.CrossFade(_idleHash, 0);
		}

		public void PlayExplode()
		{
			_animator.CrossFade(_explodeHash, 0);
		}

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}
	}
}
