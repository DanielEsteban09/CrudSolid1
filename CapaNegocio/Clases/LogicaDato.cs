using CapaDatos;
using CapaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Clases
{
    public class LogicaDato : IDato
    {
        private DbSolid1Context db;
        public LogicaDato(DbSolid1Context db)
        {
            this.db = db;
        }

        public List<Dato> GetDatos()
        {
            return db.Datos.ToList();
        }

        public Dato GetDatoByID(int id)
        {
            // Utiliza LINQ para buscar un registro con el Id especificado.
            // Si el registro no existe, devuelve null.
            return db.Datos.FirstOrDefault(d => d.Id == id);
        }

        public void CreateDato(Dato dato)
        {
            db.Datos.Add(dato);
            db.SaveChanges();
        }

        public void UpdateDato(int id, Dato nuevoDato)
        {
            var datoExistente = db.Datos.Find(id);

            // Actualiza las propiedades del dato existente con las del nuevoDato.
            datoExistente.Nombre = nuevoDato.Nombre;
            datoExistente.Apellidos = nuevoDato.Apellidos;
            datoExistente.Telefono = nuevoDato.Telefono;
            datoExistente.Profesion = nuevoDato.Profesion;
            datoExistente.Edad = nuevoDato.Edad;

            db.SaveChanges();
        }

        public void DeleteDato(int id)
        {
            var dato = db.Datos.Find(id);

            if (dato != null)
            {
                db.Datos.Remove(dato);
                db.SaveChanges();
            }
        }

    }
}
