using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessCoreLibrary.Common
{
    public static class MapHelper
    {
        /// <summary>
        /// Mapping object has the save property.
        /// </summary>
        /// <typeparam name="T">New object type</typeparam>
        /// <param name="fromObject">Object contain data</param>
        /// <param name="newObject">Object will be filled data</param>
        public static T MapTo<T>(this object fromObject)
        {
            var newObject = Activator.CreateInstance<T>();
            if (fromObject == null)
            {
                return newObject;
            }

            Type type = fromObject.GetType();
            Type typeT = newObject.GetType();

            foreach (var f in type.GetProperties())
            {
                object val = f.GetValue(fromObject, null);

                var pt = typeT.GetProperty(f.Name);
                if (pt != null)
                {
                    if (pt.PropertyType == f.PropertyType)
                    {
                        pt.SetValue(newObject, val, null);
                    }
                }
            }
            return newObject;
        }
    }
}
