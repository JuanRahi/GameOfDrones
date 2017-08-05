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
        [ResponseType(typeof(FullGameDTO))]
        public IHttpActionResult GetGame(int id)
        {
            FullGameDTO game = controller.GetFull(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(new { game = game });
        }


        // POST: api/Games        
        public IHttpActionResult PostGame(GameDTO game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = controller.Add(game);

            return Ok(new
            {
                game = id
            });
        }
      
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        
    }
}