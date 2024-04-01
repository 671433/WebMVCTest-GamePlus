
using Microsoft.EntityFrameworkCore;

namespace WebMVCTest.Services
{
   
    public class DevicesService : IDevicesService
    {
        private readonly ApplicationDbContext _context;

        public DevicesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectedDevices()
        {
            return _context.Devices
                .Select(d => new SelectListItem { Value = d.ID.ToString(), Text = d.Name })
                .OrderBy(d => d.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
