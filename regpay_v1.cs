/*
金利計算と支払いのシュミレーションプログラム
class.cs

キタ先生からのコメント
コメントの開始列を縦に揃える

最後の計算部分を別メソッドにする

金額入力部分もメソッドにする
引数で最初に表示するメッセージと格納先の変数渡せば簡潔になりそう
InputStep(“〜の金額入れてください”,”num1”)
InputStep(“〜の金額入れてください”,”num2”)
こんな感じ
*/

using System;   

   public class Teigi{
      public decimal principal ;       //元金
      public decimal Intrate   ;       //decimal型の金利
      public decimal Payperyear;       //年間の支払い回数
      public decimal NumYears  ;       //返済期間の年数
      public decimal Payment   ;       //1回あたりの返済額
      public string principal_string;  //選択された元金
      public string Intrate_string;    //選択された金利
      public string NumYears_string;   //選択された
      decimal numer, denom;            //１時的な作業変数
       double  e,b  ;                  //POWメソッドの奇数と指数 Pow(基数.指数)

      //Tupleを使ってメソッドで複数の返り値を実現
      public (decimal principal,decimal Intrate,decimal Payperyear,decimal NumYears) scan(){   
         
         
         Console.WriteLine("借入金額を入力ください！！");
             principal_string= Console.ReadLine();               //文字列で数字の入力
                principal = Convert.ToDecimal(principal_string); //入力された元金をdecimal型に変換
       
          
         Console.WriteLine("借入の金利(%)を入力ください！！");
             Intrate_string= Console.ReadLine();                 //文字列で数字の入力
                Intrate = Convert.ToDecimal(Intrate_string);     //入力された元金をdecimal型に変換
                Intrate = Intrate/100m;                          //金利を100分率から変換

         Payperyear = 12.0m;                                     //年間は12回固定
       
         Console.WriteLine("何年で返済するか？を入力ください！！");
            NumYears_string= Console.ReadLine();                 //文字列で数字の入力
               NumYears = Convert.ToDecimal(NumYears_string);    //入力された元金をdecimal型に変換
      
         return (principal,Intrate,Payperyear,NumYears);
         
      }
      public decimal math_regpay(){

         //金額を計算するコード
         numer = Intrate * principal / Payperyear;
       
         e = (double) -(Payperyear * NumYears);
         b = (double) (Intrate/Payperyear) + 1;
         denom = 1-(decimal) Math.Pow(b,e);

         Payment = numer/denom;
         
         return Payment;
      }
   }
   

   class Regpayv2{
      public static void Main(){  
      Teigi joken = new Teigi();
      
      double payment_final;

      //Tupleの呼び出し
      (decimal principal,decimal Intrate,decimal Payperyear,decimal NumYears) = joken.scan();
      
      if(Intrate >=0.0m & Intrate <=0.18m){      

      payment_final =decimal.ToDouble(joken.math_regpay());

      Console.WriteLine("返済金額は{0:C}",payment_final);
      }
      else if(Intrate <0.0m){
         Console.WriteLine("マイナス金利で銀行が不利な融資条件です！融資できません");
      }
      else{
         Console.WriteLine("もぐたんは本当にそんな金利で借りようとしてるの闇金だよ！！");
      }
      }
   }
