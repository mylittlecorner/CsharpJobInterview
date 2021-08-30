using System;
using System.IO;
using System.Xml;

class Z2{
  static int Main(string[] args){
    const int ERROR   = -1;
    const int SUCCESS =  0;

    if(args.Length<2){
      Console.WriteLine("Invalid command line arguments!");
      return ERROR;
    }

    string fileNameInput  = args[0];
    string fileNameOutput = args[1];
    int S=1;
    int sum=0;

    XmlDocument doc = new XmlDocument();

    if (File.Exists(fileNameInput)) {
        doc.Load(fileNameInput);
    }else{
      Console.WriteLine(fileNameInput + " doesn't exists!");
      File.WriteAllText(fileNameOutput,"-1");
      return ERROR;
    }

        XmlNodeList iterations = doc.GetElementsByTagName("iterations");
        int iter = Convert.ToInt32(iterations[0].InnerXml);

        XmlNodeList value = doc.GetElementsByTagName("value");
        if(value.Count>5 || (iter<1 || iter>8)){
          Console.WriteLine("Invalid file input");
          File.WriteAllText(fileNameOutput,"-1");
          return ERROR;
        }


        if(value!=null){
          int currentValue;
            foreach(XmlNode item in value){
              currentValue=Convert.ToInt32(item.InnerText);
              if((currentValue > 10) || (currentValue < -10)){
                Console.WriteLine("Invalid file input");
                File.WriteAllText(fileNameOutput,"-1");
                return ERROR;
              }
              sum+=Convert.ToInt32(item.InnerText);
            }
            for(int i=0;i<iter;i++){
              S*=sum;
            }
        }

        XmlNodeList confirmationdata = doc.GetElementsByTagName("confirmationdata");
        string confirmation = confirmationdata[0].InnerXml;

        string last = Convert.ToString(S % 10);
        if(last==confirmation){
          File.WriteAllText(fileNameOutput,"1");
        }else{
          File.WriteAllText(fileNameOutput,"0");
        }

    return SUCCESS;
  }
}

//22.08.2021 Karol Jezierzański
