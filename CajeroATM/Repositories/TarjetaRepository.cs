using CajeroATM.Data;
using CajeroATM.Models;
using CajeroATM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CajeroATM.Repositories
{
    public class TarjetaRepository : ITarjetaRepository
    {
        private readonly ApplicationDbContext _context;

        public TarjetaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tarjeta> ObtenerTarjetaPorNumeroAsync(string numeroTarjeta)
        {
            return await _context.Tarjetas.FirstOrDefaultAsync(t => t.NumeroTarjeta == numeroTarjeta);
        }

        public async Task<bool> ValidarPinAsync(int tarjetaId, string pin)
        {
            var tarjeta = await _context.Tarjetas.FindAsync(tarjetaId);
            return tarjeta != null && tarjeta.PIN == pin;
        }

        public async Task BloquearTarjetaAsync(int tarjetaId)
        {
            var tarjeta = await _context.Tarjetas.FindAsync(tarjetaId);
            if (tarjeta != null)
            {
                tarjeta.Bloqueado = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<decimal> ObtenerBalanceAsync(int tarjetaId)
        {
            var tarjeta = await _context.Tarjetas.FindAsync(tarjetaId);
            return tarjeta?.Balance ?? 0;
        }

        public async Task ActualizarBalanceAsync(int tarjetaId, decimal nuevoBalance)
        {
            var tarjeta = await _context.Tarjetas.FindAsync(tarjetaId);
            if (tarjeta != null)
            {
                tarjeta.Balance = nuevoBalance;
                await _context.SaveChangesAsync();
            }
        }

        public async Task RegistrarOperacionAsync(int tarjetaId, string codigoOperacion, decimal? monto = null)
        {
            var operacion = new Operacion
            {
                TarjetaId = tarjetaId,
                CodigoOperacion = codigoOperacion,
                Monto = monto,
                FechaHora = DateTime.UtcNow
            };
            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();
        }
    }
}
