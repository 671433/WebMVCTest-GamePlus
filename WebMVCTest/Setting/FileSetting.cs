using static System.Net.Mime.MediaTypeNames;

namespace WebMVCTest.Setting
{
    public static class FileSetting
    {
        public const string ImagesPath = "/assets/images/games";
        public const string AllowedExtentions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
}
