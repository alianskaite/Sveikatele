using Microsoft.AspNetCore.Mvc;
using tp_sveikatele.DTOS;

public class TrainingController : Controller
{
    private readonly AppDbContext _context;

    public TrainingController(AppDbContext context)
    {
        _context = context;
    }

    // Action method to navigate to the training page
    public IActionResult Index()
    {
        return View();
    }

    // Action method to render the create training form
    public IActionResult Create()
    {
        return View();
    }

    // Action method to handle form submission and save data
    [HttpPost]
    public IActionResult Create(AddTrainingDTO dTO)
    {
        if (ModelState.IsValid)
        {
            var training = new Training
            {
                Pratimas = dTO.Pratimas,
                Svoris = dTO.Svoris,
                Setai = dTO.Setai,
                Pakartojimai = dTO.Pakartojimai
            };

            _context.Trainings.Add(training);
            _context.SaveChanges();

            return RedirectToAction("Index"); // Redirect to a confirmation page or the index page
        }

        return View(dTO); // If the model state is invalid, re-display the form with validation errors
    }
}
