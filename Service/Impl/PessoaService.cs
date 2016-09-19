using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Service.Impl
{
    public class PessoaService
    {
        public void Salvar(Pessoa pessoa)
        {
            using(var db = new MyContext())
            {
                if(pessoa.Codigo > 0)
                {
                    db.Pessoa.Attach(pessoa);
                    db.Entry(pessoa).State = System.Data.Entity.EntityState.Modified;
                }
                else
                    db.Pessoa.Add(pessoa);

                db.SaveChanges();
            }
        }

        public Pessoa Obter(int codigo)
        {
            using(var db = new MyContext())
            {
                return db.Pessoa.Find(codigo);
            }
        }

        public List<Pessoa> Listar()
        {
            using(var db = new MyContext())
            {
                return db.Pessoa.ToList();
            }
        }

        public void Deletar(int codigo)
        {
            using (var db = new MyContext())
            {
                var p = new Pessoa() { Codigo = codigo };
                db.Pessoa.Attach(p);
                db.Pessoa.Remove(p);
                db.SaveChanges();
            }
        }
    }
}
