﻿using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using XUnit.Maui.Runners.VisualRunner.Pages;

namespace XUnit.Maui.Runners.VisualRunner
{
	class TestNavigator : ITestNavigation
	{
		readonly INavigation _navigation;

		public TestNavigator(INavigation navigation)
		{
			_navigation = navigation;
		}

		public Task NavigateTo(PageType page, object? dataContext = null)
		{
			ContentPage p = page switch
			{
				PageType.Home => new HomePage(),
				PageType.AssemblyTestList => new TestAssemblyPage(),
				PageType.TestResult => new TestResultPage(),
				PageType.Credits => new CreditsPage(),
				_ => throw new ArgumentOutOfRangeException(nameof(page)),
			};

			p.BindingContext = dataContext;

			return _navigation.PushAsync(p);
		}
	}
}