using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleOfNail.Data.Interfaces;
using SaleOfNail.Data.Models;
using System.Data.Odbc;

namespace SaleOfNail.Data.mock
{
    public class mockClient : iClient
    {
        public void writeSale(int numberOfNail, string clientName) {
            string CommandText1 = "SELECT max(numberOfSale) from Sale";
            string Connect = "Dsn=Nail";
            List<Nail> inProcess = new List<Nail>();
            OdbcConnection myConnection = new OdbcConnection(Connect);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            myConnection.Open();
            OdbcCommand myCommand = new OdbcCommand(CommandText1, myConnection);
            OdbcDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            MyDataReader.Read();
            int numberOfSail = MyDataReader.GetInt32(0) + 1;
            string CommandText2 = "INSERT INTO [dbo].[Sale]([numberOfSale], [numberOfNale], [nameOfCient], [typeOf]) VALUES (" + numberOfSail + ","+numberOfNail+", '" + clientName + "', 1)";
            myCommand = new OdbcCommand(CommandText2, myConnection);
            MyDataReader = myCommand.ExecuteReader();
            myConnection.Close();
        }
        public IEnumerable<Nail> inProcess(string nameOfClient)
        {

            string CommandText = "SELECT Nail.name, Nail.price, Nail.number, Nail.foto from Nail inner join Sale on Nail.number = Sale.numberOfNale WHERE typeOf = 1 and nameOfCient ='" + nameOfClient+"'";
            string Connect = "Dsn=Nail";
                List<Nail> inProcess = new List<Nail>();
                OdbcConnection myConnection = new OdbcConnection(Connect);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                myConnection.Open();
                OdbcCommand myCommand = new OdbcCommand(CommandText, myConnection);
                OdbcDataReader MyDataReader;
                MyDataReader = myCommand.ExecuteReader();
                while (MyDataReader.Read())
                {
                    string name = MyDataReader.GetString(0);
                    int price = MyDataReader.GetInt32(1);
                    int id = MyDataReader.GetInt32(2);
                   string photo = MyDataReader.GetString(3);
                    inProcess.Add(new Nail(name, price, id, photo,""));
                };
                myConnection.Close();
                return inProcess;
           
        }
        public IEnumerable<Nail> notDone(string nameOfClient)
        {

            string CommandText = "SELECT Nail.name, Nail.price, Nail.number, Nail.foto from Nail inner join Sale on Nail.number = Sale.numberOfNale WHERE typeOf = 3 and nameOfCient ='" + nameOfClient + "'";
            List<Nail> notDone = new List<Nail>();
            string Connect = "Dsn=Nail";
            OdbcConnection myConnection = new OdbcConnection(Connect);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            myConnection.Open();
            OdbcCommand myCommand = new OdbcCommand(CommandText, myConnection);
            OdbcDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            while (MyDataReader.Read())
            {
                string name = MyDataReader.GetString(0);
                int price = MyDataReader.GetInt32(1);
                int id = MyDataReader.GetInt32(2);
                string photo = MyDataReader.GetString(3);
                notDone.Add(new Nail(name, price, id, photo, ""));
            };
            myConnection.Close();
            return notDone;

        }
        public IEnumerable<Nail> Done(string nameOfClient)
        {

            string CommandText = "SELECT Nail.name, Nail.price, Nail.number, Nail.foto from Nail inner join Sale on Nail.number = Sale.numberOfNale WHERE typeOf = 2 and nameOfCient ='" + nameOfClient + "'";
            string Connect = "Dsn=Nail";
            List<Nail> done = new List<Nail>();
            OdbcConnection myConnection = new OdbcConnection(Connect);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            myConnection.Open();
            OdbcCommand myCommand = new OdbcCommand(CommandText, myConnection);
            OdbcDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            while (MyDataReader.Read())
            {
                string name = MyDataReader.GetString(0);
                int price = MyDataReader.GetInt32(1);
                int id = MyDataReader.GetInt32(2);
                string photo = MyDataReader.GetString(3);
                done.Add(new Nail(name, price, id, photo, ""));
            };
            myConnection.Close();
            return done;

        }
        public bool setClient(string name, string pass, string telephone)
        {
            string CommandText = "INSERT INTO Client(name, telephone, password) VALUES('" + name + "', '" + telephone +"', '"+ pass +"');";
            string Connect = "Dsn=Nail";
            try
            {
                OdbcConnection myConnection = new OdbcConnection(Connect);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                myConnection.Open();
                OdbcCommand myCommand = new OdbcCommand(CommandText, myConnection);
                myCommand.ExecuteReader();
                myConnection.Close();
                return true;
            }
            catch (Exception e) {
                return true;
            }
        }
        public bool getClient(string name)
        {
            string CommandText = "SELECT COUNT(*) as c FROM Client WHERE name = '" + name+"'";
            string Connect = "Dsn=Nail";
            OdbcConnection myConnection = new OdbcConnection(Connect);
            OdbcCommand myCommand = new OdbcCommand(CommandText, myConnection);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            myConnection.Open();
            OdbcDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
            MyDataReader.Read();
            int count = MyDataReader.GetInt32(0);
            myConnection.Close();
            return count > 0;
        }
    }
}
