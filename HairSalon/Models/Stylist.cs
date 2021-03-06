using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    private int _id;

    public Stylist(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }

  public static List<Stylist> GetAll()
   {
     List<Stylist> allStylists = new List<Stylist> {};
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT * FROM stylists;";
     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
     while (rdr.Read())
     {
       int stylistId = rdr.GetInt32(0);
       string stylistName = rdr.GetString(1);
       Stylist newStylist = new Stylist(stylistName, stylistId);
       allStylists.Add(newStylist);
     }

     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }
     return allStylists;
   }

   public override bool Equals(System.Object otherStylist)
   {
     if (!(otherStylist is Stylist))
     {
       return false;
     }
     else
     {
       Stylist newStylist = (Stylist) otherStylist;
       return this.GetId().Equals(newStylist.GetId());
     }
   }

   public void Save()
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();

     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"INSERT INTO `stylists` (`name`) VALUES (@StylistName);";

     MySqlParameter name = new MySqlParameter();
     name.ParameterName = "@StylistName";
     name.Value = this._name;


     cmd.Parameters.Add(name);
     ;

     cmd.ExecuteNonQuery();
     _id = (int) cmd.LastInsertedId;

     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }
   }

   public List<Client> GetClients()
   {
     List<Client> allStylistClients = new List<Client> {};
     MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT * FROM `clients` WHERE `stylist` = @stylist_id;";

     MySqlParameter stylistId = new MySqlParameter();
     stylistId.ParameterName = "@stylist_id";
     stylistId.Value = this._id;
     cmd.Parameters.Add(stylistId);

     var rdr = cmd.ExecuteReader() as MySqlDataReader;
     while(rdr.Read())
     {
       int clientId = rdr.GetInt32(0);
       string clientDescription = rdr.GetString(1);
       int clientStylistId = rdr.GetInt32(2);
       Client newClient = new Client(clientDescription, clientStylistId, clientId);

       allStylistClients.Add(newClient);
     }
     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }

     return allStylistClients;
   }

   public static void DeleteAll()
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();

     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"DELETE FROM stylists;";

     cmd.ExecuteNonQuery();

     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }
   }

   public void Delete()
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"DELETE FROM stylists WHERE id = @thisId;";

     var cmdClients = conn.CreateCommand() as MySqlCommand;
     cmdClients.CommandText = @"DELETE FROM clients WHERE stylist = @thisId;";

     MySqlParameter thisId = new MySqlParameter();
     thisId.ParameterName = "@thisId";
     thisId.Value = _id;
     cmd.Parameters.Add(thisId);
     cmdClients.Parameters.Add(thisId);

     cmdClients.ExecuteNonQuery();
     cmd.ExecuteNonQuery();

     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }
   }

   public static Stylist Find(int id)
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();

     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT * from `stylists` WHERE id = @thisId;";

     MySqlParameter thisId = new MySqlParameter();
     thisId.ParameterName = "@thisId";
     thisId.Value = id;
     cmd.Parameters.Add(thisId);

     var rdr = cmd.ExecuteReader() as MySqlDataReader;
     int stylistId = 0;
     string stylistName = "";

     while (rdr.Read())
     {
       stylistId = rdr.GetInt32(0);
       stylistName = rdr.GetString(1);
     }

     Stylist foundStylist = new Stylist(stylistName, stylistId);

     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }

     return foundStylist;
   }

   public List<Client> Sort(string direction)
   {
     List<Client> sortedList = new List<Client>{};
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"SELECT * FROM `clients` WHERE `stylist` = " + this.GetId();
     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
     while (rdr.Read())
     {
       int clientId = rdr.GetInt32(0);
       string clientDescription = rdr.GetString(1);

       int stylistId = rdr.GetInt32(2);

       Client newClient = new Client(clientDescription, stylistId, clientId);

       sortedList.Add(newClient);
     }
     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }
     return sortedList;
   }
   public override int GetHashCode() {
     return _id.GetHashCode() ^ _name.GetHashCode();
   }
 }
 }
