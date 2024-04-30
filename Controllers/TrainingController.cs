using Microsoft.AspNetCore.Mvc;

public class TrainingController : Controller
{
    // Action method to handle navigation to the training page
    public IActionResult Index()
    {
        return View(); // This assumes you have a corresponding view file named Index.cshtml
    }
}