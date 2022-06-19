using API_Pichincha.Models;

namespace API_Pichincha.Services
{
    public interface ICuenta
    {
        public List<Cuenta> Get();
        public Cuenta ObtenerCuentasxId(int id);
    }
}
