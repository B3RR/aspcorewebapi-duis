using System;
using aspcorewebapi_duis.Enums;
using Microsoft.EntityFrameworkCore;

namespace aspcorewebapi_duis.Models
{
    public class Duis
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}