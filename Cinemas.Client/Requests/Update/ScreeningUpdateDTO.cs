﻿using Cinemas.Client.Requests.Create;

namespace Cinemas.Client.Requests.Update
{
    public class ScreeningUpdateDTO : ScreeningCreateDTO
    {
        public int Id { get; set; }
    }
}