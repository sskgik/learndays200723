/*
プロジェクトの実行コード
Operate.cs
*/
using System;

/// <summary>
/// 計算用のクラス
/// </summary>

public class Calc
{
    public decimal Payment;

    ///<summary>
    ///毎月の返済額を計算するメソッド
    ///</summary>
    ///<return>
    ///Payment(毎月の返済額)
    ///</return>
    public decimal Calcregpay(decimal principal, decimal Intrate, decimal Payperyear, decimal NumYears)
    {

        decimal numer, denom;
        double b, e;
        //金額を計算するコード
        numer = Intrate * principal / Payperyear;

        e = (double)-(Payperyear * NumYears);
        b = (double)(Intrate / Payperyear) + 1;
        denom = 1 - (decimal)Math.Pow(b, e);

        Payment = numer / denom;

        return Payment;
    }

    ///<summary>
    ///返済シュミレーションの表を出力
    ///</summary>
    public void Table(decimal principal, decimal Intrate, decimal Payperyear, decimal NumYears, decimal Payment)
    {
        int t, i;
        NumYears = Convert.ToInt32(NumYears);
        Payperyear = Convert.ToInt32(Payperyear);
        decimal[,] table = new decimal[15, 15];

        for (t = 0; t < NumYears; t++)
        {
            Console.Write("{0}年目\t", (t + 1));

            for (i = 0; i < Payperyear; i++)
            {
                if ((t == 0) & (i == 0))
                {
                    table[t, i] = principal;
                    Console.Write("{0}\t", Convert.ToInt32(table[t, i]));
                }
                else if ((t >= 1) & (i == 0))
                {
                    table[t, i] = Calcprincipalremain(table[t - 1, 11], Intrate) - Payment;
                    Console.Write("{0}\t", Convert.ToInt32(table[t, i]));
                }
                else if ((i >= 1) & (i < Payperyear - 1))
                {
                    table[t, i] = Calcprincipalremain(table[t, i - 1], Intrate) - Payment;
                    Console.Write("{0}\t", Convert.ToInt32(table[t, i]));
                }
                else
                {
                    table[t, i] = Calcprincipalremain(table[t, i - 1], Intrate) - Payment;
                    Console.WriteLine("{0}", Convert.ToInt32(table[t, i]));
                }
            }

        }

    }
    ///<summary>
    ///元本の残債計算
    ///</summary>
    /// <param name="principalremain"   >残債元本</param>
    public decimal Calcprincipalremain(decimal principal, decimal Intrate)
    {
        decimal principalremain;
        //1月３０日 1年365日で計算
        principalremain = principal + (principal * Intrate * 30m / 365m);
        return principalremain;
    }

}