using System;

class Z3{
  static void Main(string[] args){

    if(args.Length!=2){
      Console.WriteLine("Invalid command line arguments!");
      Environment.Exit(-1);
    }
    string fileNameInput = args[0];
    string fileNameOutput = args[1];

    Sekwencer sek = new Sekwencer(fileNameInput,fileNameOutput);
    sek.DbOpen();
    sek.TruncateTable();
    sek.WriteFile("");
    String[] lines = sek.GetReadLines();
    int len = Convert.ToInt32(lines[1]);
    int result;
    int ID;
    for(int i=0;i<len;i++){
      ID = Convert.ToInt32(lines[i+2]);
      result = sek.GetValueById(ID);
      if(result==-1)
        sek.InsertValues(ID,1);
      else
        sek.IncrementValue(ID);
      sek.WriteLine(sek.GetValueById(ID).ToString());
    }
    sek.DbClose();
  }
}
