using API_Pichincha.Models;

namespace API_Pichincha.Services
{
    public class CuentaService : ICuenta
    {
        private List<Cuenta> _cuentas = new List<Cuenta>()
        {
            new Cuenta(){Id_Cuenta = 10000, Nro_Cuenta="xxx253", Tipo_Cuenta = "A", Saldo_Inicial=20, Saldo_Disponible=20, Estado=true, Id_Cliente= 5000},
        new Cuenta() { Id_Cuenta = 10001, Nro_Cuenta = "xxx555", Tipo_Cuenta = "C", Saldo_Inicial = 50, Saldo_Disponible = 50, Estado = true, Id_Cliente = 5001}
        };
        public List<Cuenta> Get() => _cuentas;

        public Cuenta ObtenerCuentasxId(int id) => _cuentas.FirstOrDefault(d => d.Id_Cuenta == id);
    }
}
