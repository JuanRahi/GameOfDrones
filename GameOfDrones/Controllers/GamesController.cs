using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GameOfDrones.Shared.DTO;
using GameOfDrones.Logic.Controllers;

namespace GameOfDrones.Controllers
{
    public class GamesController : ApiController
    {
        private GameCtrl controller { get; set; }

        public GamesController()
        {
            controller = new GameCtrl();
        }
        
        // GET: api/Games
        public IEnumerable<GameDTO> GetGames()
        {
            return controller.GetAll();
        }

        // GET: api/Games/5
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult GetGame(int id)
        {
            GameDTO game = controller.Get(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }


        // POST: api/Games
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult PostGame(GameDTO game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            controller.Add(game);     

            return CreatedAtRoute("DefaultApi", new { id = game.ID }, game);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        
    }
}