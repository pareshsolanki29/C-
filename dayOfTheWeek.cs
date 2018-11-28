using System;
class MainClass {
  public static void Main (string[] args) {




   		Console.WriteLine("Enter The Day!");
   		string a_day=Convert.ToLower(Console.ReadLine());
   		string today = a_day.Trim();
   		string a={"monday","tuesday","wednesday","thursday","friday"};
   		string b={"saturday", "sunday"};
   		bool weekday=false;
   		bool weekend=false;

   		
   		if (today=="monday"||today=="tuesday"||today=="wednesday"||today=="thursday"||today=="friday"){
   			Console.WriteLine("its a weekday")
   			today==weekday 
   			weekday=true;
   			weekend==false;
   		}
   		else{
   			today==weekend
   			weekday=false;
   			weekend=true;
   			Console.WriteLine("its a weekend we sleep")
   		}
   	}
  

    Console.ReadLine();
    
  }
}
      