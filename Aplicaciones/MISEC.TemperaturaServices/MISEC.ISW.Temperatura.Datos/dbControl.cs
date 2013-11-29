using System;
using System.Collections.Generic;
using System.Data.Linq;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace MISEC.ISW.Temperatura.Datos
{
    public static class dbControl
    {
        [TableName("oprTemperatura")]
        public class Temperatura
        {
            [PrimaryKey, Identity]
            public int IdSensor;
            [NotNull]
            public double Sensor;
            public DateTime Fecha;
            public int? Estado;

            [Association(ThisKey = "Estado", OtherKey = "IdSetPoint", CanBeNull = false)]
            public SetPoint SetPoint;
        }

        [TableName("SetPoints")]
        public class SetPoint
        {
            [PrimaryKey, Identity]
            public int IdSetPoint;
            [NotNull]
            public int IdTipo;
            public double limiteMin;
            public double limiteMax;
            public string Estado;

            [Association(ThisKey = "IdSetPoint", OtherKey = "Estado")]
            public List<Temperatura> Temperaturas;
        }
    }
}
