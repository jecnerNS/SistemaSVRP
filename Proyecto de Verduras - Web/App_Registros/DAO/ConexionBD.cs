﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace App_Registros.DAO
{
    class ConexionBD
    {
        protected SqlConnection Conexion = new SqlConnection("Server=DESKTOP-JEF5BLT\\SQLSERVER;DataBase=Practica_Patrones;Integrated Security=true");
    }
}
