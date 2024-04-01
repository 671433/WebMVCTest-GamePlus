namespace WebMVCTest.Services
{
    public interface IGamesService
    {
        IEnumerable<Game> GetAll();

        Game? GetById(int id);

        Task create(CreateGameFormViewModel model);
        Task<Game?> Update(EditGameFormViewModel model);

        bool Delete(int id);
    }
}
