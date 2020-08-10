﻿/*
金利計算と支払いのシュミレーションプログラム
class.cs
*/

using System;   

   /// <summary>
   /// お客様の借入情報に関するクラス
   /// </summary>
   /// <param name="principal"   >元本</param>
   /// <param name="Intrate"     >金利</param>
   /// <param name="Payperyear"  >１年間の支払い回数</param>
   /// <param name="Intrate"     >返済年数</param>

    public class Customer{ 
      public decimal principal ;       
      public decimal Intrate   ;       
      public decimal Payperyear;       
      public decimal NumYears  ;       
      
      /// <summary>
      /// お客さんに入力された数字の例外判定
      /// </summary>
      /// <param name="Input_by_customer"     >お客様による入力</param>
      /// <param name="value"                 >メソッドから返す値</param>
      public decimal nyuryoku_hantei(){
        
        decimal value = 0m;
        string Input_by_customer;
        


            Retry:
            Input_by_customer = Console.ReadLine(); 
            
                    try{
                     //エラー検出したいコード
                        value = Convert.ToDecimal(Input_by_customer);                      
                    }
                    catch(System.FormatException)
                    {
                       Console.WriteLine("数字ではありません再入力してください");
                       Input_by_customer = null;
                       goto Retry;
                    }

                    catch(System.OverflowException)
                    {
                       Console.WriteLine("数字ではありません再入力してください");
                       Input_by_customer = null;
                       
                       goto Retry;
                    }

                    catch(System.ArgumentNullException)
                    {
                       Console.WriteLine("数字ではありません再入力してください");
                       Input_by_customer = null;
                       goto Retry;
                    }

                    value = Convert.ToDecimal(Input_by_customer); 
                    
                
                
        
        return value;

      }
      
      /// <summary>
      /// Tupleを使ってメソッドで複数の返り値を実現
      /// お客様による入力のメソッド
      /// </summary>
      /// <param name="principal_by_customer"     >お客様による元本の入力</param>
      /// <param name="Intrate_by_customer"       >お客様による金利の入力</param>
      /// <param name="NumYear_by_customer"       >お客様による元本の入力</param>
      public (decimal principal,decimal Intrate,decimal Payperyear,decimal NumYears) costomer_input(){   
         
         
         Console.WriteLine("借入金額を入力ください！！");
         principal = nyuryoku_hantei();
        
          
        Console.WriteLine("借入の金利(%)を入力ください！！");
        Intrate = nyuryoku_hantei();

         //返済回数は12回固定
         Payperyear = 12.0m;                                     
       
        Console.WriteLine("何年で返済するか？を入力ください！！");
        NumYears = nyuryoku_hantei(); 
        
        return (principal,Intrate,Payperyear,NumYears);
         
      }
    }
