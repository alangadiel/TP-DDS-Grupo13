using DONDE_INVIERTO.DataStorage;
using DONDE_INVIERTO.Model.Views;
using DONDE_INVIERTO.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DONDE_INVIERTO.Service
{
    public class BalanceService
    {
        public List<BalanceView> List(string username)
        {
            var user = UserService.GetUserId(username);

            var cuentas = Context.Session.Query<ComponenteOperando>().Where(comp => comp.Formula == null).ToList();
            var empresas = Context.Session.Query<Empresa>().ToList();
            return Context.Session.Query<Balance>().OrderBy(bal => bal.EmpresaId).ToList()
                .ConvertAll(balance => new BalanceView(balance,
                cuentas.FindAll(comp => comp.BalanceId == balance.Id),
                empresas.Find(emp => balance.EmpresaId == emp.Id)))
                .Where(bal => bal.Cuentas.All(c => c.UsuarioCreador_Id == user)).ToList();

            /*return Context.Session.Query<Balance>()
                .OrderBy(bal => bal.EmpresaId).ToList()
                .ConvertAll(balance => CreateView(balance));*/
        }

        public void Save(BalanceView view, string username)
        {
            if (view.Empresa.Id == 0)
            {
                view.Empresa = Context.Session.Query<Empresa>().First(emp => emp.Cuit == view.Empresa.Cuit);
            }
            int id;

            try
            {
                id = Context.Session.Query<Balance>().Max(bal => bal.Id);
            }
            catch
            {
                id = 0;
            }

            var balance = new Balance
            {
                EmpresaId = view.Empresa.Id,
                Id = id++,
                Periodo = view.Periodo,
                Valor = view.Valor,
            };
            Context.Save(balance);

            var user = UserService.GetUserId(username);
            view.Cuentas.ForEach(cuenta =>
            {
                cuenta.UsuarioCreador_Id = user;
                cuenta.BalanceId = balance.Id;
                Context.Save(cuenta);
            });
        }

        public void Delete(int id)
        {
            var balance = Get(id);
            Context.Delete(balance);
        }

        public Balance Get(int id)
        {
            return Context.Session.Query<Balance>().
                Where(x => x.Id == id).First();
        }

        public BalanceView GetView(int id)
        {
            return CreateView(Get(id));
        }

        public BalanceView CreateView(Balance balance)
        {
            var cuentas = Context.Session.Query<ComponenteOperando>()
                .Where(comp => comp.Formula == null && comp.BalanceId == balance.Id).ToList();
            var empresa = Context.Session.Query<Empresa>()
                .FirstOrDefault(emp => balance.EmpresaId == emp.Id);
            return new BalanceView(balance, cuentas, empresa);
        }

        public bool Exist(int periodo, string cuit)
        {
            var empresa = Context.Session.Query<Empresa>().Where(emp => emp.Cuit == cuit).First();
            return Context.Session.Query<Balance>()
                .Any(bal => bal.Periodo == periodo && bal.EmpresaId == empresa.Id);
        }
    }
}
