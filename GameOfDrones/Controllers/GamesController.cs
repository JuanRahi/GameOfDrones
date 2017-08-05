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
using GameOfDrones.Domain.DAL;
using GameOfDrones.Domain.Entities;
using GameOfDrones.Shared.DTO;

namespace GameOfDrones.Controllers
{
    public class GamesController : ApiController
    {
        private GameOfDronesContext db { get; set; }

        public GamesController()
        {
            db = new GameOfDronesContext();
        }
        
        // GET: api/Games
        public IQueryable<Game> GetGames()
        {
            return db.Games;
        }

        // GET: api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult GetGame(int id)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGame(int id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.ID)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Games
        [ResponseType(typeof(Game))]
        public IHttpActionResult PostGame(GameDTO game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newGame = db.Games.Add(new Game());

            var player1 = db.Players.Where(x => x.Nombre == game.Player1).FirstOrDefault();
            if (player1 == null)
                player1 = db.Players.Add(new Player { Nombre = game.Player1 });                

            var score1 = db.Scores.Add(new Score { Game = newGame, Player = player1 });

            var player2 = db.Players.Where(x => x.Nombre == game.Player2).FirstOrDefault();
            if (player2 == null)
                player2 = db.Players.Add(new Player { Nombre = game.Player2 });                
            
            var score2 = db.Scores.Add(new Score { Game = newGame, Player = player2 });

            //newGame.Scores.Add(score1);
            //newGame.Scores.Add(score2);

            db.Games.Add(newGame);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newGame.ID }, newGame);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult DeleteGame(int id)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            db.SaveChanges();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.ID == id) > 0;
        }
    }
}