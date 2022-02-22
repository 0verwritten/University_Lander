using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Lander.Models
{
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CollectionName { get; set; } = null!;
    }
}