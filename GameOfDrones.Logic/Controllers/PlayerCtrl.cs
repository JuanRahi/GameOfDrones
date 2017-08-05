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
    public class PlayerCtrl
    {
        private UnitOfWork uow { get; set; }
        private IRepository<Player> repPlayers { get; set; }

        public PlayerCtrl()
        {
            uow = new UnitOfWork();
            repPlayers = uow.Repository<Player>();
        }

        public PlayerCtrl(UnitOfWork uow)
        {
            this.uow = uow;
            repPlayers = uow.Repository<Player>();
        }
        
        public IEnumerable<PlayerDTO> GetAll()
        {
            var result = new List<PlayerDTO>();
            var players = repPlayers.GetAll();
            foreach (var player in players)
                result.Add(new PlayerDTO { ID = player.ID, Name = player.Name });

            return result;
        }

        public PlayerDTO Get(int id)
        {
            var player = repPlayers.Get(x => x.ID == id);
            PlayerDTO dto = new PlayerDTO
            {                
                ID = player.ID,
                Name = player.Name
            };
            return dto;
        }

        public int Add(PlayerDTO dto)
        {
            return Add(dto.Name);
        }

        public int Add(string name)
        {
            var player = repPlayers.Get(x => x.Name == name);
            if (player == null)
            {
                player = new Player { Name = name };
                repPlayers.Add(player);
                uow.SaveChanges();
            }
            return player.ID;
        }
    }
}
