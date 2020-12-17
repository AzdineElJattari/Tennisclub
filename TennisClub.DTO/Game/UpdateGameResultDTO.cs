﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TennisClub.DTO.Game
{
    public class UpdateGameResultDTO
    {
        public int Id { get; set; }
        public int SetNr { get; set; }
        public int ScoreTeamMember { get; set; }
        public int ScoreOpponent { get; set; }
    }
}
