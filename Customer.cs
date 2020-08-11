/*
金利等お客さんの借入情報入力
class.cs
*/

using System;   

   /// <summary>
   /// お客様の借入情報に関するクラス
   /// </summary>


    public class Customer{ 
         
      
      /// <summary>
      /// お客さんに入力された数字の例外判定
      /// </summary>
      /// <param name="Inputbycustomer"     >お客様による入力</param>
      /// <param name="value"                 >メソッドから返す値</param>
      /// <return>
      /// Valueを返す
      /// </return>

      public decimal Nyuryokuhantei(){
        
        decimal value = 0m;
        string Inputbycustomer;
        


            Retry:
            Inputbycustomer = Console.ReadLine(); 
            
                    try{
                     //エラー検出したいコード
                        value = Convert.ToDecimal(Inputbycustomer);                      
                    }
                    catch(System.FormatException)
                    {
                       Console.WriteLine("数字ではありません再入力してください");
                       Inputbycustomer = null;
                       goto Retry;
                    }

                    catch(System.OverflowException)
                    {
                       Console.WriteLine("オーバーフローが発生しました");
                       Console.WriteLine("数字を再入力してください");
                       Inputbycustomer = null;
                       
                       goto Retry;
                    }

                    value = Convert.ToDecimal(Inputbycustomer); 
                    
                
                
        
        return value;

      }
      
      /// <summary>
      /// Tupleを使ってメソッドで複数の返り値を実現
      /// お客様による入力のメソッド
      /// </summary>
      /// <return>
      /// principal  元本
      /// Intrate    金利
      /// Payperyear 年間の返済回数
      /// Numyear    返済年数
      /// </return>
      public (decimal principal,decimal Intrate,decimal Payperyear,decimal NumYears) costomer_input(){   
         Calc input = new Calc();
         
         Console.WriteLine("借入金額を入力ください！！");
         input.principal = Nyuryokuhantei();
        
          
        Console.WriteLine("借入の金利(%)を入力ください！！");
        input.Intrate = Nyuryokuhantei();
        input.Intrate = input.Intrate/100m;

         //返済回数は12回固定
         input.Payperyear = 12.0m;                                     
       
        Console.WriteLine("何年で返済するか？を入力ください！！");
        input.NumYears = Nyuryokuhantei(); 
        
        return (input.principal,input.Intrate,input.Payperyear,input.NumYears);
         
      }
    }
