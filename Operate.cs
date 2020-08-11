/*
プロジェクトの実行コード
Operate.cs
*/
using System;
   

class Operation{  
          
      public static void Main(){
      

      Customer Input   = new Customer();
      Calc Calculation = new Calc();

      //Tupleの呼び出し
      (decimal principal,decimal Intrate,decimal Payperyear,decimal NumYears) = Input.costomer_input();
      
      Calculation.principal  = principal;
      Calculation.Intrate    = Intrate;
      Calculation.Payperyear = Payperyear;
      Calculation.NumYears   = NumYears;

      Calculation.calc_regpay();
      
      Console.WriteLine("お客様の毎月の返済額は{0:C}円です",Calculation.Payment);
      }
   }



