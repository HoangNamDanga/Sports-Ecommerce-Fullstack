using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection;
using System.Text;
using WebSport24hNews.HoangNam.Core.Enum;
using System.Security.Cryptography;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using Newtonsoft.Json;

namespace WebSport24hNews.HoangNam.Core.Extensions
{
    public static class Extension
    {
        public static string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Development;

        public static string Base64(this string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(bytes);
        }

        public static List<T> GetAllPublicConstantValues<T>(this Type type)
        {
            return (from fi in type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)
                    where fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(T)
                    select fi into x
                    select (T)x.GetRawConstantValue()).ToList();
        }

        public static string GetGenericTypeName(this Type type)
        {
            string empty = string.Empty;
            if (type.IsGenericType)
            {
                string text = string.Join(",", (from t in type.GetGenericArguments()
                                                select t.Name).ToArray());
                return type.Name.Remove(type.Name.IndexOf('`')) + "<" + text + ">";
            }

            return type.Name;
        }

        public static bool IsBase64String(this string base64)
        {
            if (string.IsNullOrEmpty(base64))
            {
                return false;
            }

            base64 = base64.Trim();
            int num = base64.Length % 4;
            if (num != 0)
            {
                base64 += new string('=', 4 - num);
            }

            try
            {
                Convert.FromBase64String(base64);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string GetGenericTypeName(this object @object)
        {
            return @object.GetType().GetGenericTypeName();
        }

        public static bool IsNullOrEmpty(this string v)
        {
            return string.IsNullOrEmpty(v);
        }

        public static string GetDateToSqlRaw(DateTime? date)
        {
            return date.Value.Year + "-" + date.Value.Month + "-" + date.Value.Day + "  00:00:00  ";
        }

        public static string GetDateToSqlRaw(int Year, int Mouth, int Day)
        {
            return Year + "-" + Mouth + "-" + Day;
        }

        public static string GetVoucherCode(this string name)
        {
            DateTime now = DateTime.Now;
            return name + now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + now.Millisecond;
        }

        public static async Task<Infrastructure.IPagedList<T>> PagedList<T>(this IQueryable<T> values, int take, int skip, bool isAll = false, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            if (isAll)
            {
                int _count = await values.CountAsync(cancellationToken);
                if (_count > 30000)
                {
                    throw new BaseException($"Số lượng dữ liệu tìm kiếm hoặc export quá lớn ({_count}),giới hạn <=60000, vui lòng lọc dữ liệu !");
                }

                Infrastructure.PagedList<T> pagedList = new Infrastructure.PagedList<T>();
                Infrastructure.PagedList<T> pagedList2 = pagedList;
                pagedList2.Lists = await values.ToListAsync(cancellationToken);
                Infrastructure.PagedList<T> resAll = pagedList;
                resAll.Count = resAll.Lists.Count;
                return resAll;
            }

            Infrastructure.PagedList<T> pagedList3 = new Infrastructure.PagedList<T>();
            Infrastructure.PagedList<T> pagedList4 = pagedList3;
            pagedList4.Lists = await values.Skip(skip).Take(take).ToListAsync(cancellationToken);
            Infrastructure.PagedList<T> pagedList5 = pagedList3;
            pagedList5.Count = await values.CountAsync(cancellationToken);
            return pagedList3;
        }

        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            char[] array = new char[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".Length)];
            }

            return new string(array);
        }




        /*
        public static string KeyEnv()
        {
            string text = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Development;
            string text2 = "";
            if (text == Environments.Production)
            {
                return VaribleGlobal.Production.MasterKey;
            }

            if (text == Environments.Staging)
            {
                return VaribleGlobal.Std.MasterKey;
            }

            if (text == Environments.Development)
            {
                return VaribleGlobal.Development.MasterKey;
            }

            return VaribleGlobal.Local.MasterKey;
        }

        public static VaribleBase GetVaribleGlobal()
        {
            string text = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Development;
            VaribleBase varibleBase = new VaribleBase();
            if (text == Environments.Production)
            {
                varibleBase.MasterKey = VaribleGlobal.Production.MasterKey;
                varibleBase.MasterUrl = VaribleGlobal.Production.DomainMaster;
                varibleBase.Image = VaribleGlobal.Production.Image;
                varibleBase.LoggingUrl = VaribleGlobal.Production.DomainLogging;
                varibleBase.PosUrl = VaribleGlobal.Production.DomainPos;
                varibleBase.SocketUrl = VaribleGlobal.Production.Socket;
            }
            else if (text == Environments.Staging)
            {
                varibleBase.MasterKey = VaribleGlobal.Std.MasterKey;
                varibleBase.MasterUrl = VaribleGlobal.Std.DomainMaster;
                varibleBase.Image = VaribleGlobal.Std.Image;
                varibleBase.LoggingUrl = VaribleGlobal.Std.DomainLogging;
                varibleBase.PosUrl = VaribleGlobal.Std.DomainPos;
            }
            else if (text == Environments.Development)
            {
                varibleBase.MasterKey = VaribleGlobal.Development.MasterKey;
                varibleBase.MasterUrl = VaribleGlobal.Development.DomainMaster;
                varibleBase.Image = VaribleGlobal.Development.Image;
                varibleBase.LoggingUrl = VaribleGlobal.Development.DomainLogging;
                varibleBase.PosUrl = VaribleGlobal.Development.DomainPos;
            }
            else
            {
                varibleBase.MasterKey = VaribleGlobal.Local.MasterKey;
                varibleBase.MasterUrl = VaribleGlobal.Local.DomainMaster;
                varibleBase.Image = VaribleGlobal.Local.Image;
                varibleBase.LoggingUrl = VaribleGlobal.Local.DomainLogging;
                varibleBase.PosUrl = VaribleGlobal.Local.DomainPos;
            }

            return varibleBase;
        }
        */

        public static int GetValue(this BaseStatus status)
        {
            return (int)status;
        }

        public static DateTime Now()
        {
            return DateTime.Now;
        }

        public static T ToObject<T>(this object k)
        {
            if (k == null)
            {
                throw new ArgumentNullException("k");
            }

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(k));
        }

        public static string ToStringBase(this object k)
        {
            if (k == null)
            {
                throw new ArgumentNullException("k");
            }

            return JsonConvert.SerializeObject(k);
        }

        public static T StringToObject<T>(this string k)
        {
            if (k == null)
            {
                throw new ArgumentNullException("k");
            }

            return JsonConvert.DeserializeObject<T>(k);
        }

        public static decimal ToNumberOrDefault(this string input)
        {
            if (decimal.TryParse(input, out var result))
            {
                return result;
            }

            return 0m;
        }

        public static bool ToBoolOrDefault(this string input)
        {
            if (bool.TryParse(input, out var result))
            {
                return result;
            }

            return false;
        }

        public static List<T> ToListOrDefault<T>(this string input, string split = ",")
        {
            List<T> list = new List<T>();
            if (input.IsNullOrEmpty() || split.IsNullOrEmpty())
            {
                return list;
            }

            string[] array = input.Split(new string[1] { split }, StringSplitOptions.None);
            string[] array2 = array;
            foreach (string text in array2)
            {
                try
                {
                    T val = (T)((!(typeof(T) == typeof(string)) && !typeof(T).IsPrimitive) ? ((object)JsonConvert.DeserializeObject<T>(text)) : ((object)(T)Convert.ChangeType(text, typeof(T))));
                    if (val != null)
                    {
                        list.Add(val);
                    }
                }
                catch (Exception ex)
                {
                    LogExtension.Information("Item for error : " + text);
                    LogExtension.Error("Convert is error : " + ex.Message);
                }
            }

            return list;
        }

        public static bool HasValueNumber(this object number)
        {
            if (number != null && decimal.TryParse(number.ToString(), out var result))
            {
                return result > 0m;
            }

            return false;
        }

        public static bool HasValueNumberZero(this object number)
        {
            if (number != null && decimal.TryParse(number.ToString(), out var result))
            {
                return result >= 0m;
            }

            return false;
        }

        public static uint Hash(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException("'s' cannot be null or empty.", "s");
            }

            byte[] value = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(s));
            return BitConverter.ToUInt32(value, 0);
        }

        public static string HashToHex(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException("'s' cannot be null or empty.", "s");
            }

            byte[] value = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(s));
            return BitConverter.ToUInt32(value, 0).ToString("x2");
        }
    }
}
