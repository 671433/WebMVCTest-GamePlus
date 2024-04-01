
namespace WebMVCTest.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext? _context;
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;

        public GamesController(ApplicationDbContext? context, ICategoriesService categoriesService, 
            IDevicesService devicesService, IGamesService gamesService)
        {
            _context = context;
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }

        public IActionResult Index()
        {
            var games = _gamesService.GetAll();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _gamesService.GetById(id);
            if(game is null)
                return NotFound();

            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoriesService.GetSelectedList(),
                Devices =  _devicesService.GetSelectedDevices()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectedList();
                model.Devices = _devicesService.GetSelectedDevices();
                return View(model);
            }
            // Save Game to database
            // Save cover to server
            await _gamesService.create(model);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gamesService.GetById(id);
            if (game is null)
                return NotFound();

            EditGameFormViewModel viewModel = new()
            {
                Id =id,
                Name= game.Name,
                Description= game.Description,
                CategoryID= game.CategoryID,
                SelectedDevices = game.Devices.Select(d => d.DeviceID).ToList(),
                Categories = _categoriesService.GetSelectedList(),
                Devices = _devicesService.GetSelectedDevices(),
                CurrentCover = game.Cover,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectedList();
                model.Devices = _devicesService.GetSelectedDevices();
                return View(model);
            }
         
            var game = await _gamesService.Update(model);
            if (game is null) return BadRequest();
            

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _gamesService.Delete(id);

            return isDeleted? Ok() : BadRequest();
        }
    }
    
    
}
