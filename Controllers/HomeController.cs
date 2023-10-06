using Microsoft.AspNetCore.Mvc;
using System;

namespace DotNetWebApi.Controllers
{
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public delegate bool FilterDelegate(Person p);

    [ApiController]
    public class HomeController : ControllerBase
    {
        public struct Game
        {
            public string gameName;
            public string developer;
            public double rating;
            public string releaseDate;

            public Game(string gameName, string developer, double rating, string releaseDate)
            {
                this.gameName = gameName;
                this.developer = developer;
                this.rating = rating;
                this.releaseDate = releaseDate;
            }
        }

        public enum Genre
        {
            Action,
            Adventure,
            Fighting,
            Platformer,
            Puzzle,
            Racing,
            RolePlaying,
            Shooter,
            Simulation,
            Sports,
            Strategy
        }

        // list of names
        readonly List<Person> people = new() {
                new Person { Name = "Aiden", Age = 20 },
                new Person { Name = "Tronny", Age = 21 },
                new Person { Name = "Walter", Age = 22 },
                new Person { Name = "Anatoli", Age = 23 },
                new Person { Name = "DudaDuda", Age = 24 }
            };



        [HttpGet]
        [Route("/")]
        public ActionResult Get()
        {
            // create an object with the message
            var message = new { message = "API Health Check - Sept, 17th" };
            return Ok(message);
        }

        [HttpGet]
        [Route("/games")]
        public ActionResult GetGames()
        {
            // Create an array of Game objects
            var games = new Game[3];
            games[0].gameName = "The Legend of Zelda: Breath of the Wild";
            games[0].developer = "Nintendo";
            games[0].rating = 3.5;
            games[0].releaseDate = "March 3, 2017";

            games[1].gameName = "Super Mario Odyssey";
            games[1].developer = "Nintendo";
            games[1].rating = 3.6;
            games[1].releaseDate = "October 27, 2017";

            games[2].gameName = "Super Smash Bros. Ultimate";
            games[2].developer = "Nintendo";
            games[2].rating = 4;
            games[2].releaseDate = "December 7, 2018";

            string[] message = new string[3];

            for (int i = 0; i < games.Length; i++)
            {
                message[i] = games[i].gameName + " was developed by " + games[i].developer + " and released on " + games[i].releaseDate + ". It has a rating of " + games[i].rating + ".";
            }

            return Ok(message);
        }

        [HttpGet]
        [Route("/enums")]
        public ActionResult GetEnums()
        {
            Genre actionGame = Genre.Action;
            var message = new { message = "Enums", genre = actionGame.ToString() };
            return Ok(message);
        }

        [HttpGet]
        [Route("/math")]
        public ActionResult GetMath()
        {
            int a = 5;
            double d = 15.3;
            int b = 10;
            int c = a + b;
            float toFloor = 15.3f;
            double toThePower = Math.Pow(d, 2);

            var message = new
            {
                message = "Math",
                sum = c,
                ceiling = Math.Ceiling(d),
                floor = Math.Floor(toFloor),
                lower = Math.Min(a, b),
                power = toThePower,
                squareRoot = Math.Sqrt(d),
                random = new Random().Next(1, 100),
                pi = Math.PI
            };
            return Ok(message);
        }

        [HttpGet]
        [Route("/delegates")]
        public ActionResult GetDelegates()
        {
            // list of names
            List<string> names = new() { "Aiden", "Tronny", "Walter", "Anatoli", "DudaDuda" };
            names.RemoveAll(name => name.Contains('r'));
            names.RemoveAll(name => name.Length < 6);

            // Call the delegate
            var message = new { message = "Delegates", names = names.Count };

            return Ok(message);
        }

        [HttpGet]
        [Route("/delegate-person")]
        public ActionResult GetDelegatePerson()
        {


            FilterDelegate filterPerAge = delegate (Person p) { return p.Age > 21; };

            foreach (var p in people)
            {
                if (filterPerAge(p))
                {
                    Console.WriteLine(p.Name + " is older than 21");
                }
            }

            people.RemoveAll(new Predicate<Person>(filterPerAge));

            // Call the delegate
            var message = new { message = "Delegates", people = people.Count };

            return Ok(message);
        }

        [HttpGet]
        [Route("/lambda")]
        public ActionResult GetLambda()
        {

            people.RemoveAll(person => person.Name.Contains('r'));
            people.RemoveAll(person =>
            {
                if (person.Age < 21)
                {
                    return true;
                }
                return false;
            });

            // Call the delegate
            var message = new { message = "Lambda", names = people.Count };

            return Ok(message);
        }



    }
}
