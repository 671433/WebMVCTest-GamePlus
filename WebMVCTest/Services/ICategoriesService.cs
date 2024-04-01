namespace WebMVCTest.Services
{
    public interface ICategoriesService
    {

        IEnumerable<SelectListItem> GetSelectedList();
    }
}
