using Adository.Common;
using Adository.CSharp.SqlServer.Models;
using System.Collections.Generic;
using System.Data;

namespace Adository.CSharp.SqlServer.ModelBuilder
{
    public class ModelClass : CSClass
    {
        public ModelClass(DataTable dataTable) : base(dataTable.TableName, CSClassModifier.PublicPartial)
        {
            CreateProperties(dataTable);
            CreateConstructor();
        }

        private void CreateProperties(DataTable dataTable)
        {
            CSProperty property;
            List<CSProperty> properties = new List<CSProperty>();

            foreach (DataColumn clm in dataTable.Columns)
            {
                string typeName = ProperCSTypeName.Get(clm);
                string name = ProperVarName.Get(clm.ColumnName);

                property = new CSProperty(typeName, name, CSMemberModifier.PublicVirtual);
                properties.Add(property);
            }
            this.Properties = properties;
        }

        private void CreateConstructor()
        {
            var constructor = new CSClassConstructor();
            this.Constructors.Add(constructor);
        }
    }
}
