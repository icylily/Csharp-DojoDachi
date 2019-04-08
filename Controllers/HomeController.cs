using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;


namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        DojoDachi myDachi = new DojoDachi();


        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            int?  fullness = HttpContext.Session.GetInt32("fullness");
            fullness = (fullness == null) ? myDachi.Fullness : fullness;
            ViewBag.fullness = fullness;
            HttpContext.Session.SetInt32("fullness", (int)fullness);

            int? happiness = HttpContext.Session.GetInt32("happiness");
            happiness = (happiness == null) ? myDachi.Happiness : happiness;
            ViewBag.happiness = happiness;
            HttpContext.Session.SetInt32("happiness", (int)happiness);

            int? meals = HttpContext.Session.GetInt32("meals");
            meals = (meals == null) ? myDachi.Meals : meals;
            ViewBag.meals = meals;
            HttpContext.Session.SetInt32("meals", (int)meals);

            int? energy = HttpContext.Session.GetInt32("energy");
            energy = (energy == null) ? myDachi.Energy : energy;
            ViewBag.energy = energy;
            HttpContext.Session.SetInt32("energy", (int)energy);

            string message = HttpContext.Session.GetString("message");
            message = (message == null) ?"My name is Cheese, Let's Play!":message;
            ViewBag.message = message;
            HttpContext.Session.SetString("message", message);

            return View();
        }

        [Route("/feed")]
        [HttpGet]
        public JsonResult Feed()
        {
            int? meals = HttpContext.Session.GetInt32("meals");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");
            string message = HttpContext.Session.GetString("message");
            string image = HttpContext.Session.GetString("image");
            string gameover = "false";
            if(meals == 0 )
            {
                message = "You do not have any meal. Can not feed your Dachi!";
                HttpContext.Session.SetString("message", message);
                
            }
            else
            {
                meals-=1;
                HttpContext.Session.SetInt32("meals", (int)meals);

                Random rand = new Random();
                int gainfullness = rand.Next(5,10);
                
                fullness += gainfullness;
                fullness = (fullness >100) ? 100 : fullness;
                HttpContext.Session.SetInt32("fullness", (int)fullness);
                if((fullness == 100) && (happiness == 100) & (energy == 100))
                {
                    message = "Congration! You win!";
                    HttpContext.Session.SetString("message", message);
                    gameover = "true";
                    image = "images/cat-1.jpg";
                    HttpContext.Session.SetString("image", image);
                }
                else 
                {
                    message = $"You feeded Cheese 1 meal, Cheese's fullness +" + gainfullness;
                    HttpContext.Session.SetString("message", message);
                    image = "images/cat-full.jpg";
                    HttpContext.Session.SetString("image", image); 
                }
            }
            var AnonObject = new
            {
                fullness = fullness,
                happiness = happiness,
                meals = meals,
                energy = energy,
                message = message,
                image = image,
                gameover = gameover
            };
            return Json(AnonObject);
        }

        [Route("/play")]
        [HttpGet]
        public JsonResult Play()
        {
            int? meals = HttpContext.Session.GetInt32("meals");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");
            string message = HttpContext.Session.GetString("message");
            string image = HttpContext.Session.GetString("image");
            string gameover = "false";
            if (energy < 5)
            {
                message = "Cheese haven't enough energe to play. At least cost 5!";
                HttpContext.Session.SetString("message", message);

            }
            else
            {
                energy -= 5;
                HttpContext.Session.SetInt32("meals", (int)meals);

                Random rand = new Random();
                int gainhappiness = rand.Next(5, 10);

                happiness += gainhappiness;
                happiness = (happiness > 100) ? 100 : happiness;
                HttpContext.Session.SetInt32("happiness", (int)happiness);
                if ((fullness == 100) && (happiness == 100) & (energy == 100))
                {
                    message = "Congration! You win!";
                    HttpContext.Session.SetString("message", message);
                    gameover = "true";
                    image = "images/cat-1.jpg";
                    HttpContext.Session.SetString("image", image);
                }
                else if ((fullness == 0) || (happiness == 0))
                {
                    message = "Oooooops. Soooo sad. Cheese was died";
                    HttpContext.Session.SetString("message", message);
                    gameover = "true";
                    image = "images/cat-died.jpg";
                    HttpContext.Session.SetString("image", image);
                }
                else
                {   
                    message = $"You plad with Cheese, Cheese's happiness +" + gainhappiness;
                    HttpContext.Session.SetString("message", message);
                    image = "images/cat-happy.jpg";
                    HttpContext.Session.SetString("image", image);
                }
            }
            var AnonObject = new
            {
                fullness = fullness,
                happiness = happiness,
                meals = meals,
                energy = energy,
                message = message,
                image = image,
                gameover = gameover
            };
            return Json(AnonObject);
        }

        [Route("/work")]
        [HttpGet]
        public JsonResult Work()
        {
            int? meals = HttpContext.Session.GetInt32("meals");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");
            string message = HttpContext.Session.GetString("message");
            string image = HttpContext.Session.GetString("image");
            string gameover = "false";
            if (energy < 5)
            {
                message = "Cheese haven't enough energe to work. At least cost 5!";
                HttpContext.Session.SetString("message", message);

            }
            else
            {
                energy -= 5;
                HttpContext.Session.SetInt32("meals", (int)meals);

                Random rand = new Random();
                int gainmeals = rand.Next(1, 3);

                meals += gainmeals;
                HttpContext.Session.SetInt32("meals", (int)meals);
                if ((fullness == 100) && (happiness == 100) & (energy == 100))
                {
                    message = "Congration! You win!";
                    HttpContext.Session.SetString("message", message);
                    gameover = "true";
                    image = "images/cat-1.jpg";
                    HttpContext.Session.SetString("image", image);
                }
                else if ((fullness <= 0) || (happiness <= 0))
                {
                    message = "Oooooops. Soooo sad. Cheese was died";
                    HttpContext.Session.SetString("message", message);
                    gameover = "true";
                    image = "images/cat-died.jpg";
                    HttpContext.Session.SetString("image", image);
                }
                else
                {
                    message = $"Cheese worked hard, meals +" + gainmeals;
                    HttpContext.Session.SetString("message", message);
                    image = "images/cat-work.jpg";
                    HttpContext.Session.SetString("image", image);
                }
            }
            var AnonObject = new
            {
                fullness = fullness,
                happiness = happiness,
                meals = meals,
                energy = energy,
                message = message,
                image = image,
                gameover = gameover
            };
            return Json(AnonObject);
        }

        [Route("/sleep")]
        [HttpGet]
        public JsonResult Sleep()
        {
            int? meals = HttpContext.Session.GetInt32("meals");
            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");
            string message = HttpContext.Session.GetString("message");
            string image = HttpContext.Session.GetString("image");
            string gameover = "false";
            energy += 15;
            energy = (energy > 100) ? 100 : energy;
            HttpContext.Session.SetInt32("energy", (int)energy);

            fullness -= 5;
            HttpContext.Session.SetInt32("fullness", (int)fullness);

            happiness -= 5;
            HttpContext.Session.SetInt32("happiness", (int)happiness);



            if ((fullness == 100) && (happiness == 100) & (energy == 100))
            {
                message = "Congration! You win!";
                HttpContext.Session.SetString("message", message);
                gameover = "true";
                image = "images/cat-1.jpg";
                HttpContext.Session.SetString("image", image);
            }
            else if ((fullness <= 0) || (happiness <= 0))
            {
                message = "Oooooops. Soooo sad. Cheese was died";
                HttpContext.Session.SetString("message", message);
                gameover = "true";
                image = "images/cat-died.jpg";
                HttpContext.Session.SetString("image", image);
            }
            else
            {
                message = $"Cheese slept well" ;
                HttpContext.Session.SetString("message", message);
                image = "images/cat-2.jpg";
                HttpContext.Session.SetString("image", image);
            }
        
            var AnonObject = new
            {
                fullness = fullness,
                happiness = happiness,
                meals = meals,
                energy = energy,
                message = message,
                image = image,
                gameover = gameover
            };
            return Json(AnonObject);
        }

        [Route("/restart")]
        [HttpGet]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

    }
}
