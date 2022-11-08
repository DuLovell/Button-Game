using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.MainButton
{
	public class MainButtonAnimator : MonoBehaviour
	{
		private const float PUSH_END_Z_VALUE = -0.00758f;
		private const float PUSH_DURATION = 0.3f;
		private const float UNPUSH_END_Z_VALUE = -0.005275526f;
		private const float UNPUSH_DURATION = 0.1f;

		[SerializeField] private Transform _pushTransform = null!;

		public void PlayPush()
		{
			DOTween.Kill(_pushTransform);
			_pushTransform.DOLocalMoveZ(PUSH_END_Z_VALUE, PUSH_DURATION);
		}

		public void PlayUnpush()
		{
			DOTween.Kill(_pushTransform);
			_pushTransform.DOLocalMoveZ(UNPUSH_END_Z_VALUE, UNPUSH_DURATION);
		}
	}
}
