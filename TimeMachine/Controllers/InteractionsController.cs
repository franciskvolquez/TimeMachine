using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TimeMachine.Models;
using TimeMachine.ViewModels;

namespace TimeMachine.Controllers
{

    [Authorize]
    public class InteractionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Interactions
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();

            var model = await db.Interactions
                              .Include(i => i.Type)
                              .Where(i => i.UserId == userId)
                              .OrderByDescending(i => i.Id)
                              .ToListAsync();

            return View(model);
        }

        // GET: Interactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();

            Interaction interaction = await db.Interactions
                                                .Where(i => i.Id == id && i.UserId == userId)
                                                .SingleOrDefaultAsync();
            if (interaction == null)
            {
                return HttpNotFound();
            }
            return View(interaction);
        }

        // GET: Interactions/Create
        public async Task<ActionResult> Create()
        {
            var model = new CreateInteractionVM
            {
                InteractionTypes = await db.InteractionTypes.ToListAsync()
            };

            return View(model);
        }

        // POST: Interactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TypeId")] Interaction interaction)
        {

            if (ModelState.IsValid)
            {
                interaction.DateTime = DateTime.Now.ToUniversalTime().AddHours(-4);
                interaction.UserId = User.Identity.GetUserId();

                db.Interactions.Add(interaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(interaction);
        }

        // GET: Interactions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();

            Interaction interaction = await db.Interactions
                                                .Where(i => i.Id == id && i.UserId == userId)
                                                .SingleOrDefaultAsync();
            if (interaction == null)
            {
                return HttpNotFound();
            }

            var model = new CreateInteractionVM()
            {
                Interaction = interaction,
                InteractionTypes = await db.InteractionTypes.ToListAsync()
            };

            return View(model);
        }

        // POST: Interactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TypeId,DateTime")] Interaction interaction)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var inter = await db.Interactions
                                               .Where(i => i.Id == interaction.Id)
                                               .SingleOrDefaultAsync();

                if (inter == null)
                    return HttpNotFound();

                if (inter.UserId != userId)
                    return new HttpUnauthorizedResult();

                inter.DateTime = interaction.DateTime;
                inter.TypeId = inter.TypeId;

                //db.Entry(interaction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(interaction);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
