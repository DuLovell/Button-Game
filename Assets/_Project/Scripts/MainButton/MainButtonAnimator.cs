using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.MainButton
{
	public class MainButtonAnimator : MonoBehaviour
	{
		private const float PUSH_END_Z_VALUE = -0.00758f;
		private const float PUSH_DURATION = 0.3f;

		[SerializeField] private Transform _pushTransform = null!;

		public void PlayPush()
		{
			_pushTransform.DOLocalMoveZ(PUSH_END_Z_VALUE, PUSH_DURATION);
		}

		public void PlayUnpush()
		{
			_pushTransform.DOLocalMoveZ(-0.005275526f, 0.1f);
		}
	}
}
