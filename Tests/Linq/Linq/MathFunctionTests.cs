﻿using System;
using System.Linq;

using LinqToDB;
using LinqToDB.DataProvider.DB2iSeries;
using NUnit.Framework;

namespace Tests.Linq
{
    [TestFixture]
    public class MathFunctionTests : TestBase
    {
        [Test, DataContextSource]
        public void Abs(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Abs(p.MoneyValue) where t > 0 select t,
                    from t in from p in db.Types select Math.Abs(p.MoneyValue) where t > 0 select t);
        }

        [Test, DataContextSource(ProviderName.Access, ProviderName.SQLiteMS)]
        public void Acos(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Acos((double)p.MoneyValue / 15) * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Acos((double)p.MoneyValue / 15) * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.Access, ProviderName.SQLiteMS)]
        public void Asin(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Asin((double)p.MoneyValue / 15) * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Asin((double)p.MoneyValue / 15) * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Atan(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Atan((double)p.MoneyValue / 15) * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Atan((double)p.MoneyValue / 15) * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.Access, ProviderName.SQLiteMS)]
        public void Atan2(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Atan2((double)p.MoneyValue / 15, 0) * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Atan2((double)p.MoneyValue / 15, 0) * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Ceiling1(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Ceiling(-(p.MoneyValue + 1)) where t != 0 select t,
                    from t in from p in db.Types select Math.Ceiling(-(p.MoneyValue + 1)) where t != 0 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Ceiling2(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Ceiling(p.MoneyValue) where t != 0 select t,
                    from t in from p in db.Types select Math.Ceiling(p.MoneyValue) where t != 0 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Cos(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Cos((double)p.MoneyValue / 15) * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Cos((double)p.MoneyValue / 15) * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Cosh(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Cosh((double)p.MoneyValue / 15) * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Cosh((double)p.MoneyValue / 15) * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Cot(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Sql.Cot((double)p.MoneyValue / 15).Value * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Sql.Cot((double)p.MoneyValue / 15).Value * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Degrees1(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Sql.Degrees(p.MoneyValue).Value) where t != 0.1m select t,
                    from t in from p in db.Types select Math.Floor(Sql.Degrees(p.MoneyValue).Value) where t != 0.1m select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Degrees2(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Sql.Degrees((double)p.MoneyValue).Value where t != 0.1 select Math.Floor(t),
                    from t in from p in db.Types select Sql.Degrees((double)p.MoneyValue).Value where t != 0.1 select Math.Floor(t));
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Degrees3(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Sql.Degrees((int)p.MoneyValue).Value where t != 0.1 select t,
                    from t in from p in db.Types select Sql.Degrees((int)p.MoneyValue).Value where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Exp(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Exp((double)p.MoneyValue)) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Exp((double)p.MoneyValue)) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Floor(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(-(p.MoneyValue + 1)) where t != 0 select t,
                    from t in from p in db.Types select Math.Floor(-(p.MoneyValue + 1)) where t != 0 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Log(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Log((double)p.MoneyValue)) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Log((double)p.MoneyValue)) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Log2(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Log((double)p.MoneyValue, 2)) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Log((double)p.MoneyValue, 2)) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Log10(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Log10((double)p.MoneyValue)) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Log10((double)p.MoneyValue)) where t != 0.1 select t);
        }

        [Test, DataContextSource]
        public void Max(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Max(p.MoneyValue, 5.1m) where t != 0 select t,
                    from t in from p in db.Types select Math.Max(p.MoneyValue, 5.1m) where t != 0 select t);
        }

        [Test, DataContextSource]
        public void Min(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Min(p.MoneyValue, 5) where t != 0 select t,
                    from t in from p in db.Types select Math.Min(p.MoneyValue, 5) where t != 0 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Pow(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Pow((double)p.MoneyValue, 3)) where t != 0 select t,
                    from t in from p in db.Types select Math.Floor(Math.Pow((double)p.MoneyValue, 3)) where t != 0 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Round1(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Round(p.MoneyValue) where t != 0 select t,
                    from t in from p in db.Types select Math.Round(p.MoneyValue) where t != 0 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Round2(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Round((double)p.MoneyValue) where t != 0 select t,
                    from t in from p in db.Types select Math.Round((double)p.MoneyValue) where t != 0 select t);
        }

        [Test, DataContextSource]
        public void Round3(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Round(p.MoneyValue, 1) where t != 0 && t != 7 select t,
                    from t in from p in db.Types select Math.Round(p.MoneyValue, 1) where t != 0 && t != 7 select t);
        }

        [Test, DataContextSource]
        public void Round4(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Round((double)p.MoneyValue, 1) where t != 0 select Math.Round(t, 5),
                    from t in from p in db.Types select Math.Round((double)p.MoneyValue, 1) where t != 0 select Math.Round(t, 5));
        }

        [Test, DataContextSource]
        public void Round5(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Round(p.MoneyValue, MidpointRounding.AwayFromZero) where t != 0 select t,
                    from t in from p in db.Types select Math.Round(p.MoneyValue, MidpointRounding.AwayFromZero) where t != 0 select t);
        }

        // rounding of 4.5000 rounds down on 7.1 but up (correct for this test) on 7.3 - needs further investigation
        [Test, DataContextSource(DB2iSeriesProviderName.DB2, DB2iSeriesProviderName.DB2_GAS)]
        public void Round6(string context)
        {
            using (var db = GetDataContext(context))
            {
                var expected = from t in from p in Types select Math.Round((double)p.MoneyValue, MidpointRounding.AwayFromZero) where t != 0 select t;
                var actual = from t in from p in db.Types select Math.Round((double)p.MoneyValue, MidpointRounding.AwayFromZero) where t != 0 select t;
                AreEqual(expected, actual);
            }
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Round7(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Round(p.MoneyValue, MidpointRounding.ToEven) where t != 0 select t,
                    from t in from p in db.Types select Math.Round(p.MoneyValue, MidpointRounding.ToEven) where t != 0 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Round8(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Round((double)p.MoneyValue, MidpointRounding.ToEven) where t != 0 select t,
                    from t in from p in db.Types select Math.Round((double)p.MoneyValue, MidpointRounding.ToEven) where t != 0 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteClassic, ProviderName.SQLiteMS)]
        public void Round9(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Round(p.MoneyValue, 1, MidpointRounding.AwayFromZero) where t != 0 select t,
                    from t in from p in db.Types select Math.Round(p.MoneyValue, 1, MidpointRounding.AwayFromZero) where t != 0 select t);
        }

        [Test, DataContextSource]
        public void Round10(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Round(p.MoneyValue, 1, MidpointRounding.ToEven) where t != 0 && t != 7 select t,
                    from t in from p in db.Types select Math.Round(p.MoneyValue, 1, MidpointRounding.ToEven) where t != 0 && t != 7 select t);
        }

        [Test, DataContextSource]
        public void Round11(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Round((double)p.MoneyValue, 1, MidpointRounding.ToEven) where t != 0 select Math.Round(t, 5),
                    from t in from p in db.Types select Math.Round((double)p.MoneyValue, 1, MidpointRounding.ToEven) where t != 0 select Math.Round(t, 5));
        }

        [Test, DataContextSource(ProviderName.SQLiteClassic, ProviderName.SQLiteMS)]
        public void Round12(string context)
        {
            var mp = MidpointRounding.AwayFromZero;

            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Round(p.MoneyValue, 1, mp) where t != 0 && t != 7 select t,
                    from t in from p in db.Types select Math.Round(p.MoneyValue, 1, mp) where t != 0 && t != 7 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Sign(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Sign(p.MoneyValue) where t != 0 select t,
                    from t in from p in db.Types select Math.Sign(p.MoneyValue) where t != 0 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Sin(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Sin((double)p.MoneyValue / 15) * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Sin((double)p.MoneyValue / 15) * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Sinh(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Sinh((double)p.MoneyValue / 15) * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Sinh((double)p.MoneyValue / 15) * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Sqrt(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Sqrt((double)p.MoneyValue / 15) * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Sqrt((double)p.MoneyValue / 15) * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Tan(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Tan((double)p.MoneyValue / 15) * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Tan((double)p.MoneyValue / 15) * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Tanh(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Floor(Math.Tanh((double)p.MoneyValue / 15) * 15) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Floor(Math.Tanh((double)p.MoneyValue / 15) * 15) where t != 0.1 select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Truncate1(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Truncate(p.MoneyValue) where t != 0.1m select t,
                    from t in from p in db.Types select Math.Truncate(p.MoneyValue) where t != 0.1m select t);
        }

        [Test, DataContextSource(ProviderName.SQLiteMS)]
        public void Truncate2(string context)
        {
            using (var db = GetDataContext(context))
                AreEqual(
                    from t in from p in Types select Math.Truncate((double)-p.MoneyValue) where t != 0.1 select t,
                    from t in from p in db.Types select Math.Truncate((double)-p.MoneyValue) where t != 0.1 select t);
        }
    }
}
