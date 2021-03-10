using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Sys
{
    public static class Function 
    {
        public static System.String Call(Sys.Funktion funktion) {
            //https://stackoverflow.com/questions/11986947/how-to-map-json-string-to-the-calling-of-c-sharp-method
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes()
                                .First(t => t.Name == (System.String)funktion.name.Substring(0, funktion.name.LastIndexOf(".")));
            System.Object controller = System.Activator.CreateInstance(type);
            //System.Reflection.PropertyInfo validation = type.GetProperty((System.String)function.validation);
            //int length2 = (int)propertyInfo.FastGetValue(s);
            System.Reflection.MethodInfo action = type.GetMethod((System.String)funktion.name.Substring(funktion.name.LastIndexOf(".") + 1, funktion.name.Length - funktion.name.LastIndexOf(".")));
            var form = action.GetParameters()
                    .Select(a => System.Convert.ChangeType((Sys.Funktion)funktion, a.ParameterType))
                    .ToArray();
            return (System.String)action.Invoke(controller, form);
            //bool success = (bool)action.FastInvoke(s, new object[] { "Hello" });
        }
        public static Sys.Funktion ConvertStringToFunction(System.String json) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Sys.Funktion>(json);
        }
        public static System.String ConvertFunctionToString(Sys.Funktion function) {
            return Newtonsoft.Json.JsonConvert.SerializeObject(function);
        }
    }
}
