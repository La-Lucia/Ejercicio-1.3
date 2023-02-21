using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Personas.Models;
using SQLite;

namespace Personas.Controllers
{

    public class DB
    {
        readonly SQLiteAsyncConnection conexion;

        // Constructor Vacio
        public DB()
        { }

        public DB(String dbpath)
        {
            conexion = new SQLiteAsyncConnection(dbpath);

            // Creacion de Objetos de Base de dartos
            conexion.CreateTableAsync<Models.Persona>().Wait();
        }

        // CRUD - Create / Read / Update/ Delete

        public Task<int> GuardarPersona(Models.Persona persona)
        {
            if (persona.Id == 0)
            {
                return conexion.InsertAsync(persona);
            }
            else
            {
                return conexion.UpdateAsync(persona);
            }
        }

        // Read - List

        public Task<List<Models.Persona>> ListaPersona()
        {
            return conexion.Table<Models.Persona>().ToListAsync();
        }

        // Get 
        public Task<Models.Persona> GetPersona(int pid)
        {
            return conexion.Table<Models.Persona>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        // Delete
        public Task<int> BorrarPersona(Models.Persona persona)
        {
            return conexion.DeleteAsync(persona);
        }

        public Task<int> ActualizarPersona(Models.Persona persona) 
        {
            if (persona.Id != 0)
            {
                return conexion.UpdateAsync(persona);
            }
            else
            {
                return conexion.InsertAsync(persona);
            }
        }


    }
}
