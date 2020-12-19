﻿using TennisClub.DAL.Context;
using TennisClub.Data.Model;

namespace TennisClub.DAL.Repository
{
    public class GameRepository : GenericRepository<Game>
    {
        public GameRepository(TennisContext context) : base(context) { }
    }
}
