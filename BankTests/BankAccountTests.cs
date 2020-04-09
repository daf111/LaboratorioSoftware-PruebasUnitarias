using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebasUnitarias;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        //Siempre devuelve void
        //No puede tener parámetros
        public void Debito_ConImporteValido_ActualizaSaldo()
        {

            // Arrange
            double saldoInicial = 11.99;
            double montoDebitado = 4.55;
            double esperado = 7.44;
            CuentaBancaria cuenta = new CuentaBancaria("Mr. Bryan Walton", saldoInicial);

            // Act
            cuenta.Debito(montoDebitado);

            // Assert
            double actual = cuenta.Saldo;
            Assert.AreEqual(esperado, actual, 0.001, "Account not debited correctly");

        }

        [TestMethod]
        public void Debito_CuandoImporteEsMenorACero_DeberiaArrojarExcepcionArgumentOutOfRange()
        {
            // Arrange
            double saldoInicial = 11.99;
            double montoDebitado = -100.00;
            CuentaBancaria cuenta = new CuentaBancaria("Mr. Bryan Walton", saldoInicial);

            // Act and assert
            try
            {
                cuenta.Debito(montoDebitado);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, CuentaBancaria.MensajeMontoDebitoMenorACero);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");

        }

    }
}
