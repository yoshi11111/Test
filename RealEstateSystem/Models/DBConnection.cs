using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateSystem.Models
{
    public sealed class DBConnection
    {
        [ThreadStatic]
        private static DinamicWebFormEntities5 _singleInstance;

        public static DinamicWebFormEntities5 GetInstance()
        {
            if (_singleInstance == null)
            {
                _singleInstance = new DinamicWebFormEntities5();
            }
            return _singleInstance;
        }

        private DBConnection()
        {
        }

    }
}