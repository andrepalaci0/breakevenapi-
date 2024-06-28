using breakevenApi.Domain.Entities.Medic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakevenApi.tests
{
    public class MedicTest
    {
        [Fact]
        public void MedicConstructor_SetsPropertiesCorrectly()
        {
            // Arrange
            long crm = 123456;
            double percentual = 0.5;
            string telefone = "123456789";
            string nomeMedico = "Dr. John";

            // Act
            var medic = new Medic(crm, percentual, telefone, nomeMedico);

            // Assert
            //moq -> mock de bd
            Assert.Equal(crm, medic.Crm);
            Assert.Equal(percentual, medic.Percentual);
            Assert.Equal(telefone, medic.Telefone);
            Assert.Equal(nomeMedico, medic.NomeMedico);
        }
    }
}
