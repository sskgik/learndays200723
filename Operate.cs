﻿/*
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

      Calculation.Calcregpay();
      
         if(Intrate >=0.0m & Intrate <=0.18m){      

            Console.WriteLine("お客様の毎月の返済額は{0:C}円です",Calculation.Payment);
         }
         else if(Intrate <0.0m){

            Console.WriteLine("マイナス金利で銀行が不利な融資条件です！融資できません");
         }
         else{

            Console.WriteLine("もぐたんは本当にそんな金利で借りようとしてるの闇金だよ！！");
         }
      }

}



