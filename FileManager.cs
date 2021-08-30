using System;
using System.IO;

class FileManager{
  private readonly string _fileNameInput;
  private readonly string _fileNameOutput;
  public FileManager(string fileNameInput,string fileNameOutput){
    this._fileNameInput=fileNameInput;
    this._fileNameOutput=fileNameOutput;
  }

  public String ReadFile(){
    if (File.Exists(_fileNameInput)) {
      return File.ReadAllText(_fileNameInput);
    }
      Console.WriteLine(_fileNameInput + " doesn't exists!");
      Environment.Exit(-1);
      return "";
  }

  public String[] ReadLines(){
    if (File.Exists(_fileNameInput)) {
      return File.ReadAllLines(_fileNameInput);
    }
    Environment.Exit(-1);
    return null;
  }

  public void WriteFile(String str){
    File.WriteAllText(_fileNameOutput,str);
  }

  public void WriteLine(String str){
    str=str+'\n';
    File.AppendAllText(_fileNameOutput,str);
  }


}
