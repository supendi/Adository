using System.Data;

namespace Adository.Common
{
    public class ProperCSTypeName
    {
        public static string Get(DataColumn clm)
        {
            string typeName = clm.DataType.Name;
            string dataType = string.Empty;
            switch (typeName)
            {
                case "Object":
                    dataType = "object";
                    break;
                case "String":
                    dataType = "string";
                    break;
                case "Byte":
                    dataType = "byte";
                    break;
                case "Byte[]":
                    dataType = "byte[]";
                    break;
                case "Decimal":
                    dataType = "decimal";
                    break;
                case "Int16":
                    dataType = "short";
                    break;
                case "Int32":
                    dataType = "int";
                    break;
                case "Int64":
                    dataType = "long";
                    break;
                case "Double":
                    dataType = "double";
                    break;
                case "Boolean":
                    dataType = "bool";
                    break;
                default:
                    dataType = typeName;
                    break;
            }

            if (clm.AllowDBNull == true && dataType != "byte[]" && dataType != "string" && dataType != "object")
            {
                dataType = $"Nullable<{dataType}>";
            }

            return dataType;
        }
    }
}
