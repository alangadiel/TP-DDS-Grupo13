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
            
            var balance = new Balance
            {
                EmpresaId = view.Empresa.Id,
                Id = view.Id,
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
            Context.Session.Query<ComponenteOperando>()
                .Where(comp => comp.BalanceId == id).ToList()
                .ForEach(cuenta => Context.Delete(cuenta));
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

        public void CargarBalances(List<Balance> balances)
        {
            //Valido que no haya balances repetidos
            this.ValidarBalancesArchivo(balances);
            foreach (Balance balance in balances)
            {
                Context.Save(balance);
            }
        }

        private void ValidarBalancesArchivo(List<Balance> balancesArchivo)
        {
            List<Balance> balancesRepetidos = new List<Balance>();
            foreach (var item in balancesArchivo)
            {
                bool hayUnBalanceIgual = this.ExisteBalanceParaEmpresaEnPeriodo(item.Periodo, item.EmpresaId);
                if (hayUnBalanceIgual)
                {
                    balancesRepetidos.Add(item);
                }

            }
            if (balancesRepetidos.Count > 0)
            {
                throw new BalancesRepetidosException("Hay balances del archivo que ya fueron cargados previamente") { Balances = balancesRepetidos };
            }
        }

        public bool ExisteBalanceParaEmpresaEnPeriodo(int periodo, int empresaId)
        {
            return Context.Session.Query<Balance>().Any(x => x.Periodo == periodo && x.EmpresaId == empresaId);
        }
    }
}
