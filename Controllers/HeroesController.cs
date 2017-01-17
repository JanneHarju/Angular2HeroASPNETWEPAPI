using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HeroWebAPI2.Controllers
{
    public class Hero
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    
    [Produces("application/json")]
    [Route("api/heroes")]
    public class HeroController : Controller
    {
        Hero hero1 = new Hero() { id = 1, name = "plaa"};
        Hero hero2 = new Hero(){ id = 2, name = "pallo"};
        List<Hero> heroes = new List<Hero>();
        private string filePath = @"./heroes.json";
        public HeroController()
         : base()
        {
            heroes = GetHeroesFromFile();
        }



        // GET api/values
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return heroes;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Hero Get(int id)
        {
            return heroes.Find(x=>x.id == id);
        }

        //api/person/byName?name=a
        [HttpGet("byName")]
        public IEnumerable<Hero> Get([FromQueryAttribute] string name)
        {
            List<Hero> hs = heroes.FindAll(x=>x.name.Contains(name));
            return hs;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Hero value)
        {
            Hero lastHero = heroes.OrderByDescending(x => x.id).First();
            value.id = lastHero.id + 1;
            heroes.Add(value);
            SaveToFIle(heroes);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Hero value)
        {
            Hero updateHero = heroes.Find(item => item.id == id);
            updateHero.name = value.name;
            SaveToFIle(heroes);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            heroes.RemoveAll(x=>x.id==id);
            SaveToFIle(heroes);
        }

        private void SaveToFIle(IEnumerable<Hero> heroes)
        {
            string json = JsonConvert.SerializeObject(heroes.ToArray(), Formatting.Indented);

            //write string to file
            System.IO.File.WriteAllText(filePath, json);
        }
        private List<Hero> GetHeroesFromFile()
        {
            //List<Hero> heroesFromFile = new List<Hero>();
            string heroString = System.IO.File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Hero>>(heroString);
        }
    }
}
