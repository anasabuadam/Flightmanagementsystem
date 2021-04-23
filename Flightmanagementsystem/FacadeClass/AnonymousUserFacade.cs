using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Flightmanagementsystem.FacadeClass
{
    class ClassAnonymousUserFacade : IAnonymoussUserFacade
    {
        string conn_string = "";

        string IAnonymoussUserFacade.conn_string => throw new NotImplementedException();


    }

}
