﻿/*
プロジェクトの実行コード
Operate.cs
*/
using System;

/// <summary>
/// 計算用のクラス
/// </summary>
/// <param name="principal"   >元本</param>
/// <param name="Intrate"     >金利</param>
/// <param name="Payperyear"  >１年間の支払い回数</param>
/// <param name="Intrate"     >返済年数</param> 
public class Calc{
   public decimal Payment; 
     
      ///<summary>
      ///入力された値を用いて計算を行うメソッド
      ///</summary>
      ///<return>
      ///Payment(毎月の返済額)
      ///</return>
      public decimal Calcregpay(decimal principal,decimal Intrate,decimal Payperyear,decimal NumYears){
         
         decimal numer,denom;
         double b,e;
         //金額を計算するコード
         numer = Intrate * principal / Payperyear;
       
         e = (double) -(Payperyear * NumYears);
         b = (double) (Intrate/Payperyear) + 1;
         denom = 1-(decimal) Math.Pow(b,e);

         Payment = numer/denom;
         
         return Payment;
      }
   }
   



