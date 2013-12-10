using System;
using System.Collections.Generic;
using System.Data.Linq;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace MISEC.ISW.Temperatura.Datos
{
    public static class dbControl
    {
        [TableName("Usuario")]
        public class Usuario
        {
            [PrimaryKey]
            public string IdUsuario;
            [NotNull]
            public string Password;
            public int Nivel;
        }
        
        [TableName("Bitacora")]
        public class Bitacora
        {
            [PrimaryKey, Identity]
            public int idBitacora;
            [NotNull]
            public string Descripcion;
            public DateTime Fecha;
            public string Tipo;
            public int? IdUsuario;
            [Association(ThisKey = "IdUsuario", OtherKey = "IdUsuario", CanBeNull = false)]
            public Usuario Usuario;        
        }        
        
        [TableName("Sensor")]
        public class Sensor
        {
            [PrimaryKey, Identity]
            public int IdSensor;
            [NotNull]
            public double Valor;
            public DateTime Fecha;
            public int? IdSetPoint;

            [Association(ThisKey = "IdSetPoint", OtherKey = "IdSetPoint", CanBeNull = false)]
            public SetPoint SetPoint;
        }

        [TableName("SetPoint")]
        public class SetPoint
        {
            [PrimaryKey, Identity]
            public int IdSetPoint;
            [NotNull]
            public string Variable;
            public double limiteMin;
            public double limiteMax;
            public string Estado;
            public string Activo;

            [Association(ThisKey = "IdSetPoint", OtherKey = "IdSetPoint")]
            public List<Sensor> Valores;
            public int? IdHorario;
            [Association(ThisKey = "IdHorario", OtherKey = "IdHorario", CanBeNull = true)]
            public Horario Horario;
        }

        [TableName("Horario")]
        public class Horario
        {
            [PrimaryKey, Identity]
            public int IdHorario;
            [NotNull]
            public string Descripcion;
            public DateTime HoraInicio;
            public DateTime HoraFin;
            public int? IdTemporada;

            [Association(ThisKey = "IdTemporada", OtherKey = "IdTemporada", CanBeNull = true)]
            public Temporada Temporada;
            [Association(ThisKey = "IdHorario", OtherKey = "IdHorario")]
            public List<SetPoint> ListaSetPoints;
        }

        [TableName("Temporada")]
        public class Temporada { 
            [PrimaryKey, Identity]
            public int IdTemporada;
            [NotNull]
            public string Descripcion;
            [Association(ThisKey = "IdTemporada", OtherKey = "IdTemporada")]
            public List<Horario> ListaHorarios;
        }
    }
}
