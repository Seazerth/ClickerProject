using ClickerWebProject.UseCases.AddPoints;
using ClickerWebProject.UseCases.GetBoosts;
using ClickerWebProject.UseCases.GetCurrentUser;
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

		var user = await mediator.Send(new GetCurrentUserQuery());

		var ViewModel = new IndexViewModel()
		{
			Boosts = boosts,
			User = user,
		};

        return View(ViewModel);
    }

	[HttpPost("click")]
	public async Task<IActionResult> Click()
	{

		await mediator.Send(new AddPointsCommand(Times: 1));

		return RedirectToAction(nameof(Index));
	}
}
