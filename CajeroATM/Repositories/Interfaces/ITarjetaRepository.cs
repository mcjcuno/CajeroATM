using CajeroATM.Models;
using System.Threading.Tasks;

namespace CajeroATM.Repositories.Interfaces
{
    public interface ITarjetaRepository
    {
        Task<Tarjeta> ObtenerTarjetaPorNumeroAsync(string numeroTarjeta);
        Task<bool> ValidarPinAsync(int tarjetaId, string pin);
        Task BloquearTarjetaAsync(int tarjetaId);
        Task<decimal> ObtenerBalanceAsync(int tarjetaId);
        Task ActualizarBalanceAsync(int tarjetaId, decimal nuevoBalance);
        Task RegistrarOperacionAsync(int tarjetaId, string codigoOperacion, decimal? monto = null);
    }
}
