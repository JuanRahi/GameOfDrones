using GameOfDrones.Domain.DAL;
using GameOfDrones.Domain.Entities;
using GameOfDrones.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Logic.Controllers
{
    public class RoundCtrl
    {
        UnitOfWork uow { get; set; }
        IRepository<Round> repRounds { get; set; }

        public RoundCtrl()
        {
            uow = new UnitOfWork();
            repRounds = uow.Repository<Round>();
        }
        
    }
}
