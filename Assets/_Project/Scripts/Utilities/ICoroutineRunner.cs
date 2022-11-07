using System.Collections;
using UnityEngine;

namespace _Project.Scripts
{
	public interface ICoroutineRunner
	{
		Coroutine StartCoroutine(IEnumerator coroutine);
	}
}
