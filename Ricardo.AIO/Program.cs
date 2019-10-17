using System;
using System.Reflection;
using System.Security.Permissions;
using EnsoulSharp.SDK;
using Ricardo.AIO.Properties;

namespace Ricardo.AIO
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnGameLoad;
        }

        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        private static void OnGameLoad()
        {
            LoadDll(Resources.Ricardo_AIO, "Ricardo.AIO.Program");
        }

        private static void LoadDll(byte[] dll, string namespacePlusClass)
        {
            try
            {
                var a = Assembly.Load(dll);
                var myType = a.GetType(namespacePlusClass);
                var methon = myType.GetMethod("Main", BindingFlags.Public | BindingFlags.Static);

                if (methon != null) methon.Invoke(null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}