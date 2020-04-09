using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    public class CuentaBancaria
    {
        private readonly string m_nombreCliente;
        private double m_saldo;

        public const string MensajeMontoDebitoExcedeSaldo = "El débito excede al saldo";
        public const string MensajeMontoDebitoMenorACero = "El débito es menor a cero";
        public const string MensajeMontoCreditoMenorACero = "El crédito es menor a cero";

        private CuentaBancaria() { }

        public CuentaBancaria(string nombreCliente, double saldo)
        {
            m_nombreCliente = nombreCliente;
            m_saldo = saldo;
        }

        public string CustomerName
        {
            get { return m_nombreCliente; }
        }

        public double Saldo
        {
            get { return m_saldo; }
        }

        public void Debito(double importe)
        {
            if (importe > m_saldo)
            {
                throw new System.ArgumentOutOfRangeException("importe", importe, MensajeMontoDebitoExcedeSaldo);
            }

            if (importe < 0)
            {
                throw new System.ArgumentOutOfRangeException("importe", importe, MensajeMontoDebitoMenorACero);
            }

            m_saldo += importe; // intentionally incorrect code
        }

        public void Credito(double importe)
        {
            if (importe < 0)
            {
                throw new System.ArgumentOutOfRangeException("importe", importe, MensajeMontoCreditoMenorACero);
            }

            m_saldo += importe;
        }
    }
}
