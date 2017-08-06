using GameOfDrones.Logic.Controllers;
using GameOfDrones.Shared.DTO;
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

namespace GameOfDrones.Controllers
{
    public class PlayersController : ApiController
    {
        PlayerCtrl controller { get; set; }

        public PlayersController()
        {
            controller = new PlayerCtrl();
        }

        // GET: api/Players/5
        [ResponseType(typeof(FullPlayerDTO))]
        public IHttpActionResult GetPlayer(int id)
        {
            var wins = controller.GetWins(id);            
            return Ok(wins);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}