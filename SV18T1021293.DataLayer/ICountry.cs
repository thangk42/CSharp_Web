using SV18T1021293.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV18T1021293.DataLayer
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICountryDAL
    {
        IList<Country> List();
    }
}