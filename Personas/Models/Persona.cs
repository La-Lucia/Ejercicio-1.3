using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Personas.Models
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        [MaxLength(60)]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

    }
}
