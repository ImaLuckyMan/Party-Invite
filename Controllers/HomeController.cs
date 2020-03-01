using System;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models; // Allows me to refer to the guest response model without needing to qualify the name.
using System.Linq;

namespace PartyInvites.Controllers 
{ 

    public class HomeController : Controller 
    { 
       public ViewResult Index()
       {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View ("MyView");
       }

        /* This tells MVC that this method should be used only for GET requests.*/
        [HttpGet]
        public ViewResult RsvpForm() /* Action method calls the View method without an argument. Tells MVC to render the default 
            view associated with the action method which is a view wih the same name as the action method in this case RSVP.cshtml */
        {
            return View();
        }
        /* This tells MVC that the new method will deal with POST requests. */
        [HttpPost]
        public ViewResult RsvpForm(Guest_Response guestResponse) 
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                //there is a validation error
                return View();
            }
        }

        // Calls the view method Repository using Repository.Responses as an argument.
        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }


    }
}
