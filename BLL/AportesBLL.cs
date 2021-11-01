using GestionPersonas.DAL;
using GestionPersonas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.BLL
{
    public class AportesBLL
    {
        public static bool Guardar(Aportes aporte)
        {
            if (!Existe(aporte.AporteId))
            {
                return Insertar(aporte);
            }
            else
            {
                return Modificar(aporte);
            }
        }
        private static bool Insertar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Aportes.Add(aporte);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(aporte).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Aportes = contexto.Aportes.Find(id);

                if (Aportes != null)
                {
                    contexto.Aportes.Remove(Aportes);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Aportes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Aportes Aporte;

            try
            {
                Aporte = contexto.Aportes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Aporte;
        }
        public static List<Aportes> GetList(Expression<Func<Aportes, bool>> criterio)
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Aportes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Aportes.Any(r => r.AporteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static bool ExisteConcepton(string concepto)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Aportes.Any(r => r.Concepto == concepto);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static List<Aportes> GetRoles()
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Aportes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static List<TipoAportes> GetTiposAportes(Expression<Func<TipoAportes, bool>> criterio)
        {
            List<TipoAportes> lista = new List<TipoAportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.tipoAportes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
