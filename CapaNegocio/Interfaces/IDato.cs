using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface IDato
    {
        List<Dato> GetDatos();
        Dato GetDatoByID(int id);
        void CreateDato(Dato dato);
        void UpdateDato(int id, Dato dato);
        void DeleteDato(int id);
    }
}
