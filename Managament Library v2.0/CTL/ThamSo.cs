using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managament_Library_v2._0.EF;
using Managament_Library_v2._0.DAO;

namespace Managament_Library_v2._0.CTL
{
    public class ThamSo
    {
        DAO.ThamSo data = new DAO.ThamSo();
        public List<THAMSO> loadThamSo()
        {
            return data.loadThamSo();
        }
    }
}
