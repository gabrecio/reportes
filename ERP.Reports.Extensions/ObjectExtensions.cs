using System;
using System.Threading.Tasks;

namespace ERP.Reports.Extensions
{
    public static class ObjectExtensions
    {

        public async static Task<bool> TryExecuteAsync(this object o, Func<Task> action)
        {
            try
            {
                await action();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async static Task<T> TryExecuteAsync<T>(this object o, Func<Task<T>> action)
        {
            try
            {
                return await action();
            }
            catch
            {
                return default(T);
            }
        }

        public static bool TryExecute(this object o, Action action)
        {
            try
            {
                action();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T TryExecute<T>(this object o, Func<T> action)
        {
            try
            {
                return action();
            }
            catch
            {
                return default(T);
            }
        }

        public static bool TryExecute(Action action)
        {
            var o = new object();
            return o.TryExecute(action);
        }



    }
}
