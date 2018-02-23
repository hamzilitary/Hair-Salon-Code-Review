using System;

namespace HairSalon.Models
{
  public class HairSalonModel
  {
    private string _description;
    private int _id;
    private int _categoryId;

    public Item (string description, int Id = 0, int categoryId = 0)
    {
      _description = description;
      _categoryId = categoryId;
      _id = id;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public int GetId()
    {
      return _id;
    }
    public int GetCategoryId()
    {
      return _categoryId;
    }
    public void SetCategoryId(int id)
    {
      _categoryId = id;
    }

    public static List<Item> GetAll()
    {
      List<Item> allItems = new List<Item> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int ItemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        int categoryId = rdr.GetInt32(3);
        Item newItem = new Item(itemDescription, itemId, categoryId);
        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }
  }
}
