using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInflation.Shared.Data
{
    public class DAL<T> where T : class
    {
        private readonly ProductInflationContext context;
        public DAL(ProductInflationContext context)
        {
            this.context = context;
        }
        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }
        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }
        public void Borrar(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }
        public void Actualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }
        public T? RecuperarPor(Func<T, bool> condicion)
        {
            return context.Set<T>().FirstOrDefault(condicion);
        }
        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().Where(condicao);
        }
    }
}
