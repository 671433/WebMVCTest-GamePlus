

namespace WebMVCTest.Services
{
    public class GamesService : IGamesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;

        public GamesService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSetting.ImagesPath}";
        }

        public IEnumerable<Game> GetAll()
        {
           return _context.Games.
                Include( g=> g.Category)
                .Include(g => g.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .ToList();
        }

        public Game? GetById(int id)
        {
            return _context.Games.
                 Include(g => g.Category)
                 .Include(g => g.Devices)
                 .ThenInclude(d => d.Device)
                 .AsNoTracking()
                 .SingleOrDefault(g => g.ID == id);
        }

        public async Task create(CreateGameFormViewModel model)
        {
            //create a unik path for image and save it in the server 
            var CoverName = await SaveCover(model.Cover);

            //save game
            Game game = new Game()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryID  = model.CategoryID,
                Cover = CoverName,
                Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceID = d }).ToList()
            };

            _context.Games.Add(game);
            _context.SaveChanges();
        
        }

        public async Task<Game?> Update(EditGameFormViewModel model)
        {
            var game = _context.Games
                .Include(g => g.Devices)
                .SingleOrDefault(g => g.ID == model.Id);

            if (game is null) return null;

            var hasNewCover = model.Cover is not null;
            var oldCover = game.Cover;

            game.Name = model.Name;
            game.Description = model.Description;
            game.CategoryID = model.CategoryID;
            game.Devices= model.SelectedDevices.Select(d => new GameDevice { DeviceID = d }).ToList();

            if (hasNewCover)
            {
                game.Cover = await SaveCover(model.Cover!);
            }

            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                if(hasNewCover)
                {
                    var cover = Path.Combine(_imagesPath, oldCover);
                    File.Delete(cover);
                }
                return game;
            }
            else
            {
                var cover = Path.Combine(_imagesPath, game.Cover);
                File.Delete(cover);

                return null;
            }

        }

        public bool Delete(int id)
        {
            var isDeleted = false;

            var game = _context.Games.Find(id);
            if (game is null) return isDeleted;

            _context.Games.Remove(game);
            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;
                var cover = Path.Combine(_imagesPath, game.Cover);
                File.Delete(cover);
            }


            return isDeleted;
        }

        private async Task<string> SaveCover(IFormFile cover)
        {
            //create a unik path for image and save it in the server 
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

            var path = Path.Combine(_imagesPath, CoverName);

            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);

            return CoverName;
        }


    }
}
