/*
 * Hoa Luu
 * ITSE1430
 * December 8, 2018
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventPlanner.Mvc.App_Start;

namespace EventPlanner.Mvc.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult My()
        {
            List<ScheduledEvent> _events = DatabaseFactory.Database.GetAll(new EventCriteria()
            { IncludePrivate = true, IncludePublic = false}).Where(evnt => evnt.EndDate >= DateTime.Today).OrderBy(evnt => evnt.StartDate).ToList();

            List<ScheduledEventModel> _modelEvents = new List<ScheduledEventModel>();

            _events.ForEach(evt => _modelEvents.Add(new ScheduledEventModel(evt)));

            return View(_modelEvents);
        }

        [HttpGet]
        public ActionResult All()
        {
            List<ScheduledEvent> _events = DatabaseFactory.Database.GetAll(new EventCriteria()
            {
                IncludePrivate = false,
                IncludePublic = true
            }).Where(evnt => evnt.EndDate >= DateTime.Today).OrderBy(evnt => evnt.StartDate).ToList();

            List<ScheduledEventModel> _modelEvents = new List<ScheduledEventModel>();

            _events.ForEach(evt => _modelEvents.Add(new ScheduledEventModel(evt)));

            return View(_modelEvents);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            ScheduledEvent sEvent = (ScheduledEvent)DatabaseFactory.Database.GetAll(
                new EventCriteria()
                {
                    IncludePrivate = true,
                    IncludePublic = true
                }).FirstOrDefault(i => i.Id == id);

            if (sEvent == null)
                return new HttpNotFoundResult(id.ToString());

            ScheduledEventModel evtModel = new ScheduledEventModel(sEvent);

            return View(evtModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ScheduledEventModel evntModel = new ScheduledEventModel(new ScheduledEvent());

            evntModel.StartDate = DateTime.Today;
            evntModel.EndDate = DateTime.Today;

            return View(evntModel);
        }

        [HttpPost]
        public ActionResult Create(ScheduledEventModel evntModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Verify.ArgumentIsValidAndNotNull(evntModel.Name, evntModel);

                    ScheduledEvent evnt = evntModel.ToDomain();

                    DatabaseFactory.Database.Add(evnt);

                    return RedirectToAction((evnt.IsPublic) ? "All" : "My");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(evntModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ScheduledEvent evnt =(ScheduledEvent) DatabaseFactory.Database.GetAll(
                new EventCriteria() {
                    IncludePrivate = true,
                    IncludePublic = true
                }).FirstOrDefault(i => i.Id == id);

            if (evnt == null)
                return new HttpNotFoundResult();

            ScheduledEventModel evntModel = new ScheduledEventModel(evnt);

            return View(evntModel);
        }

        [HttpPost]
        public ActionResult Edit(ScheduledEventModel evntModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Verify.ArgumentIsValidAndNotNull(evntModel.Name, evntModel);

                    ScheduledEvent evnt = evntModel.ToDomain();

                    DatabaseFactory.Database.Update(evnt.Id, evnt);

                    return RedirectToAction((evnt.IsPublic) ? "All" : "My");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(evntModel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ScheduledEvent evnt = (ScheduledEvent)DatabaseFactory.Database.GetAll(
                new EventCriteria()
                {
                    IncludePrivate = true,
                    IncludePublic = true
                }).FirstOrDefault(i => i.Id == id);

            if (evnt == null)
                return new HttpNotFoundResult();

            ScheduledEventModel evntModel = new ScheduledEventModel(evnt);

            return View(evntModel);
        }

        [HttpPost]
        public ActionResult Delete(ScheduledEventModel evntModel)
        {
            
            try
            {
                ScheduledEvent evnt = evntModel.ToDomain();

                bool isPublic = evnt.IsPublic;

                DatabaseFactory.Database.Remove(evnt.Id);
                return RedirectToAction((isPublic) ? "All" : "My");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(evntModel);
            }

            
        }

    }
}