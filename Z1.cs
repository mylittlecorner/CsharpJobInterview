using System;
using System.IO;

class Z1{
  static int Main(string[] args){
    const int ERROR   = -1;
    const int SUCCESS =  0;

    if(args.Length!=2){
      Console.WriteLine("Invalid command line arguments!");
      return ERROR;
    }

    string fileNameInput  = args[0];
    string fileNameOutput = args[1];

    string textInput;

    int N,M,y;

    int countRect=0;

    if (File.Exists(fileNameInput)) {
      textInput = File.ReadAllText(fileNameInput);
      String[] tokens = textInput.Split(' ');
      if(tokens.Length!=2){
        Console.WriteLine("N and M are required.");
        return ERROR;
      }
      N = Convert.ToInt32(tokens[0]);
      M = Convert.ToInt32(tokens[1]);
    }else{
      Console.WriteLine(fileNameInput + " doesn't exists!");
      return ERROR;
    }

    for(int i=0; i<N;i=i+M){
      y=fx(i,N);
      for(int j=M;j<y;j=j+M){
        countRect++;
      }
    }

    File.WriteAllText(fileNameOutput,countRect.ToString());

    return SUCCESS;
  }
  static int fx(int x, int b){//y=mx+b
    return -1*x + b;
  }
}

//22.08.2021 Karol Jezierzański
