namespace WebMVCTest.Services
{
    public interface IDevicesService
    {
        IEnumerable<SelectListItem> GetSelectedDevices();
    }
}
