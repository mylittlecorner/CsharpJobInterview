using System;
using System.Data.SqlClient;

class Sekwencer{
  private readonly FileManager _fileManager;
  private readonly SqlConnection _conn;
  private readonly string[] _readLines;
  public Sekwencer(string fileNameInput, string fileNameOutput){
    _fileManager= new FileManager(fileNameInput,fileNameOutput);
    _conn=new SqlConnection(_fileManager.ReadLines()[0]);
    _readLines=_fileManager.ReadLines();
  }

  public void DbOpen(){
    try{
        _conn.Open();
    }catch (Exception e){
        Console.WriteLine("Error: " + e.Message);
    }
  }

  public void DbClose(){
    _conn.Close();
  }

  public void InsertValues(int ID, int VAL){
    DateTime CurrentDate;
    CurrentDate = DateTime.Now;
    try{
       using (SqlCommand command = new SqlCommand(
       "INSERT INTO Counters (ID,Val,TS) VALUES (@myid,@myval,@myts)",
        _conn)){
              command.Parameters.AddWithValue("@myid", ID);
              command.Parameters.AddWithValue("@myval", VAL);
              command.Parameters.AddWithValue("@myts", CurrentDate);
              command.ExecuteNonQuery();
      }
    }catch{
      Console.WriteLine("Insertion failed.");
    }

  }

  public void IncrementValue(int ID){
    try{
       using (SqlCommand command = new SqlCommand(
       "UPDATE Counters SET Val = Val + 1 WHERE ID=@myid",
        _conn)){
              command.Parameters.AddWithValue("@myid", ID);
              command.ExecuteNonQuery();
      }
    }catch{
      Console.WriteLine("Incrementation failed.");
    }

  }

  public void TruncateTable(){
    try{
        using (SqlCommand command = new SqlCommand(
        "TRUNCATE TABLE Counters",
         _conn)){
          command.ExecuteNonQuery();
        }
     }catch{
       Console.WriteLine("Table not truncated.");
     }
  }

  public int GetValueById(int ID){
    SqlCommand command = new SqlCommand("SELECT Val FROM Counters WHERE ID=@myid", _conn);
    command.Parameters.AddWithValue("@myid", ID);
    using (SqlDataReader reader = command.ExecuteReader()){
      if (reader.Read()){
         return Convert.ToInt32(reader["Val"]);
       }
       return -1;
    }
  }

  public String[] GetReadLines(){
    return _readLines;
  }

  public void WriteLine(String str){
    _fileManager.WriteLine(str);
  }

  public void WriteFile(String str){
    _fileManager.WriteFile(str);
  }

}
