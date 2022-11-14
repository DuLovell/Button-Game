using _Project.Scripts.MainButton.Data;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class ModelInstaller : MonoInstaller
	{
		[SerializeField]
		private MainButtonModel _mainButtonModel = null!;
		
		public override void InstallBindings()
		{
			Container.Bind<MainButtonModel>().FromInstance(_mainButtonModel);
		}
	}
}
