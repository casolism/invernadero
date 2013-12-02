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
        public Table<dbControl.Temperatura> Temperatura { get { return GetTable<dbControl.Temperatura>(); } }
        public Table<dbControl.SetPoint> SetPoint { get { return GetTable<dbControl.SetPoint>(); } }
    }
}
