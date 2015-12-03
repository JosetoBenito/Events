﻿namespace BackgroundTask.ViewModels.Base
{
	using Microsoft.Practices.Unity;

	public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

			// ViewModels
            _container.RegisterType<MainViewModel>();
		}

        public MainViewModel MainViewModel => _container.Resolve<MainViewModel>();
    }
}
