using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PluggableCoreLibrary.Attributes;
using PluggableCoreLibrary.Interfaces;

namespace PluggableCoreLibrary
{
    public static class ThongKeHostProvider
    {
        private static List<ThongKeHost> _thongKeHosts;

        /// <summary>
        /// Lay toan bo danh sach cac plug-in thuc hien thong ke
        /// du lieu ket qua.
        /// </summary>
        public static List<ThongKeHost> ThongKeList
        {
            get
            {
                if (null == _thongKeHosts)
                {
                    Reload();
                }

                return _thongKeHosts;
            }
        }

        public static void Reload()
        {
            if (_thongKeHosts == null)
            {
                _thongKeHosts = new List<ThongKeHost>();
            }
            else
            {
                _thongKeHosts.Clear();
            }
            // Load danh sach dll plug-in
            List<Assembly> plugInAssemblies = LoadPlugInAssemblies();
            List<IThongKe> plugIns = GetPlugIns(plugInAssemblies);

            foreach (IThongKe tk in plugIns)
            {
                _thongKeHosts.Add(new ThongKeHost(tk));
            }
        }
        /// <summary>
        /// Thuc hien load toan bo dll plug-in trong thu muc plugins
        /// </summary>
        /// <returns></returns>
        private static List<Assembly> LoadPlugInAssemblies()
        {
            DirectoryInfo dInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Plugins"));
            FileInfo[] files = dInfo.GetFiles("*.dll");

            List<Assembly> plugInAssemblyList = new List<Assembly>();

            if (null != files)
            {
                foreach (FileInfo file in files)
                {
                    plugInAssemblyList.Add(Assembly.LoadFile(file.FullName));
                }
            }
            return plugInAssemblyList;
        }
        static List<IThongKe> GetPlugIns(List<Assembly> assemblies)
        {
            List<Type> availableTypes = new List<Type>();

            foreach (Assembly currentAssembly in assemblies)
                availableTypes.AddRange(currentAssembly.GetTypes());

            // get a list of objects that implement the ICalculator interface AND 
            // have the CalculationPlugInAttribute
            List<Type> calculatorList = availableTypes.FindAll(delegate (Type t)
            {
                List<Type> interfaceTypes = new List<Type>(t.GetInterfaces());
                object[] arr = t.GetCustomAttributes(typeof(ThongKePlugInAttribute), true);
                return !(arr == null || arr.Length == 0) && interfaceTypes.Contains(typeof(IThongKe));
            });

            // conver the list of Objects to an instantiated list of ICalculators
            return calculatorList.ConvertAll<IThongKe>(delegate (Type t) { return Activator.CreateInstance(t) as IThongKe; });
        }
    }
}
