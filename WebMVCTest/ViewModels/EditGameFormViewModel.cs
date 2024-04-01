namespace WebMVCTest.ViewModels
{
    public class EditGameFormViewModel: GameFormViewModel
    {
        public int Id { get; set; }

        public string? CurrentCover { get; set; }

        [AllowedExtensions(FileSetting.AllowedExtentions)]
        [MaxFile(FileSetting.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
