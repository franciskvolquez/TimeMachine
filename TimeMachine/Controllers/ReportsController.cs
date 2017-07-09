using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TimeMachine.Business;
using TimeMachine.Models;

namespace TimeMachine.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reports
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var interactions = await db.Interactions
                .Include(i => i.Type)
                .Where(i => i.UserId == userId)
                .ToListAsync();

            var reportsService = new ReportsService();
            var report = reportsService.GenerateWorkTimeReport(interactions);

            return View(report);
        }


    }
}

