using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tp_sveikatele.Data;
using tp_sveikatele.DTOS;
using tp_sveikatele.Models;
using System.Threading.Tasks;

[Authorize]
public class TrainingController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public TrainingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Action method to navigate to the training page
    public IActionResult Index()
    {
        // Example data, you would retrieve this from your data source
        List<AddTrainingDTO> workouts = new List<AddTrainingDTO>
        {
            new AddTrainingDTO { Pratimas = "Squats", Svoris = 100, Setai = 3, Pakartojimai = 10 },
            new AddTrainingDTO { Pratimas = "Bench Press", Svoris = 80, Setai = 4, Pakartojimai = 8 }
        };

        return View(workouts);
    }

    // Action method to render the create training form
    public IActionResult Create()
    {
        return View();
    }

    // Action method to handle form submission and save data
    [HttpPost]
    public async Task<IActionResult> Create(AddTrainingDTO dto)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var training = new Training
                {
                    Pratimas = dto.Pratimas,
                    Svoris = dto.Svoris,
                    Setai = dto.Setai,
                    Pakartojimai = dto.Pakartojimai,
                    ApplicationUserId = user.Id // Set the ApplicationUserId with the current user's ID
                };

                _context.Trainings.Add(training);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index"); // Redirect to a confirmation page or the index page
            }
        }

        return View(dto); // If the model state is invalid, re-display the form with validation errors
    }
}
