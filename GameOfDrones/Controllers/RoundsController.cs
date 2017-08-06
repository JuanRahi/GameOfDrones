using GameOfDrones.Logic.Controllers;
using GameOfDrones.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameOfDrones.Controllers
{
    public class RoundsController : ApiController
    {
        private GameCtrl controller { get; set; }

        public RoundsController()
        {
            controller = new GameCtrl();
        }

        // POST: api/Rounds        
        [HttpPost]
        public IHttpActionResult PostRound(FullGameDTO game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = controller.AddRound(game);
            
            return Ok(result);
        }

    }
}
