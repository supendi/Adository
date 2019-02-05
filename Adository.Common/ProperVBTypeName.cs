using System.Data;

namespace Adository.Common
{
    public class ProperVBTypeName
    {
        public static string Get(DataColumn clm)
        {
            string typeName = clm.DataType.Name;
            string dataType = typeName;
            switch (typeName)
            {
                case "Int16":
                    dataType = "Short";
                    break;
                case "Int32":
                    dataType = "Integer";
                    break;
                case "Int64":
                    dataType = "Long";
                    break;
                case "Byte[]":
                    dataType = "Byte()";
                    break;
                default:
                    dataType = typeName;
                    break;
            }

            if (clm.AllowDBNull == true && dataType != "Byte()" && dataType != "String" && dataType != "Object")
            {
                dataType = $"Nullable(Of {dataType})";
            }

            return dataType;
        }
    }
}
