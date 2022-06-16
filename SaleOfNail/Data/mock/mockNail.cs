using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleOfNail.Data.Interfaces;
using SaleOfNail.Data.Models;
using System.Data.Odbc;

namespace Hospitals.Data.mock
{
    public class mockNail : iNail
    {

        public IEnumerable<Nail> ALLNail
        {
            get
            {
                string CommandText = "SELECT * FROM Nail";
                string Connect = "Dsn=Nail";
                List<Nail> nails = new List<Nail>();
                OdbcConnection myConnection = new OdbcConnection(Connect);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                myConnection.Open();
                OdbcCommand myCommand = new OdbcCommand(CommandText, myConnection);
                OdbcDataReader MyDataReader;
                MyDataReader = myCommand.ExecuteReader();
                while (MyDataReader.Read())
                {
                    string name = MyDataReader.GetString(0);
                    int number = MyDataReader.GetInt32(1);
                    int price1 = MyDataReader.GetInt32(2);
                    string foto = MyDataReader.GetString(3);
                    string description = MyDataReader.GetString(4);
                    nails.Add(new Nail(name, number, price1, foto, description));
                };
                myConnection.Close();
                return nails;
            }
            set
            {

            }
        }
        public IEnumerable<Nail> getNail(int price, string PartOfName)
        {
            string CommandText = "SELECT * FROM Nail WHERE price < " + price + "AND name LIKE '%"+PartOfName+"%'";
            string Connect = "Dsn=Nail";
            List<Nail> nails = new List<Nail>();
            OdbcConnection myConnection = new OdbcConnection(Connect);
            OdbcCommand myCommand = new OdbcCommand(CommandText, myConnection);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            myConnection.Open();
            OdbcDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();

            while (MyDataReader.Read())
            {
                string name = MyDataReader.GetString(0);
                int number = MyDataReader.GetInt32(1);
                int price1 = MyDataReader.GetInt32(2);
                string foto = MyDataReader.GetString(3);
                string description = MyDataReader.GetString(4);
                nails.Add(new Nail(name, number, price1, foto, description));
            };
            myConnection.Close();
            return nails;
        }
        public Nail getOneNail(int id)
        {
            string CommandText = "SELECT * FROM Nail WHERE number =" + id;
            string Connect = "Dsn=Nail";
            List<Nail> nails = new List<Nail>();
            OdbcConnection myConnection = new OdbcConnection(Connect);
            OdbcCommand myCommand = new OdbcCommand(CommandText, myConnection);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            myConnection.Open();
            OdbcDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            Nail ret = new Nail("1",0,0,"1","1");
            while (MyDataReader.Read())
            {
                string name = MyDataReader.GetString(0);
                int number = MyDataReader.GetInt32(1);
                int price1 = MyDataReader.GetInt32(2);
                string foto = MyDataReader.GetString(3);
                string description = MyDataReader.GetString(4);
                ret = new Nail(name, number, price1,foto,description);
            };
            myConnection.Close();
            return ret;
        }
        public bool getPass(string name, string pass) {
            string CommandText = "SELECT COUNT(*) as c FROM Client WHERE name = '" + name + "' and password = '" + pass +"'";
            string Connect = "Dsn=Nail";
            List<Nail> nails = new List<Nail>();
            OdbcConnection myConnection = new OdbcConnection(Connect);
            OdbcCommand myCommand = new OdbcCommand(CommandText, myConnection);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            myConnection.Open();
            OdbcDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            MyDataReader.Read();
            int count = MyDataReader.GetInt32(0);
            myConnection.Close();
            return count == 1;
        }

    }
}
