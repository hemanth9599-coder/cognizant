using System.Collections.Generic;

namespace PlayerManagerLib
{
    // Model
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }

    // Database Interface
    public interface IPlayerMapper
    {
        Player GetPlayerById(int id);
    }

    // Database Class
    public class PlayerMapper : IPlayerMapper
    {
        public Player GetPlayerById(int id)
        {
            return new Player
            {
                Id = id,
                Name = "Virat Kohli"
            };
        }
    }

    // Business Class
    public class PlayerManager
    {
        private readonly IPlayerMapper mapper;

        public PlayerManager(IPlayerMapper mapper)
        {
            this.mapper = mapper;
        }

        public Player GetPlayer(int id)
        {
            return mapper.GetPlayerById(id);
        }
    }
}