using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

public class Class1
{

    public Class1()
    {
    
    }

    public SqlConnection dataBaseConnect()
        {
            SqlConnection conn = new SqlConnection("user id=LanceI;" +
                          "password=mayafit1;server=Lance\\sqlexpress;" +
                          "Trusted_Connection=yes;" +
                          "database=People; " +
                          "connection timeout=30");
            return conn;
        }
	}

