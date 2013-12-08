using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.Data.Linq;

namespace MISEC.ISW.Temperatura.Datos
{
    public class dbControlManager : DbManager
    {
        public dbControlManager() : base("dbControl") {
		}
        public Table<dbControl.Usuario> Usuario { get { return GetTable<dbControl.Usuario>(); } }
        public Table<dbControl.Bitacora> Bitacora { get { return GetTable<dbControl.Bitacora>(); } }
        public Table<dbControl.Sensor> Sensor { get { return GetTable<dbControl.Sensor>(); } }
        public Table<dbControl.SetPoint> SetPoint { get { return GetTable<dbControl.SetPoint>(); } }
        public Table<dbControl.Horario> Horario { get { return GetTable<dbControl.Horario>(); } }
        public Table<dbControl.Temporada> Temporada { get { return GetTable<dbControl.Temporada>(); } }
    }
}
