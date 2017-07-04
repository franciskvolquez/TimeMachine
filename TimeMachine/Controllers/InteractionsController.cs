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
    public class InteractionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Interactions
        public async Task<ActionResult> Index()
        {
            var model = await db.Interactions
                              .Include(i => i.Type)
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
            Interaction interaction = await db.Interactions.FindAsync(id);
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
            Interaction interaction = await db.Interactions.FindAsync(id);
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
                db.Entry(interaction).State = EntityState.Modified;
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
