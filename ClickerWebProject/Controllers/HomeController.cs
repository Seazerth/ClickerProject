using ClickerWebProject.UseCases.GetBoosts;
using ClickerWebProject.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClickerWebProject.Controllers;

public class HomeController : Controller
{
    private readonly IMediator mediator;

	public HomeController(IMediator mediator)
	{
		this.mediator = mediator;
	}

	public async Task<IActionResult> Index()
    {
		var boosts = await mediator.Send(new GetBoostsQuery());

		var ViewModel = new IndexViewModel()
		{
			Boosts = boosts,
		};

        return View(ViewModel);
    }
}
