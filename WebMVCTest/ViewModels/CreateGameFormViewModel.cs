
namespace WebMVCTest.ViewModels
{
    public class CreateGameFormViewModel : GameFormViewModel
    {


        [AllowedExtensions(FileSetting.AllowedExtentions)]
        [MaxFile(FileSetting.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
    }
}
