using Adository.Common;
using Adository.VB.SqlServer.Models;
using System.Collections.Generic;
using System.Data;

namespace Adository.VB.SqlServer.ModelBuilder
{
    public class ModelClass : VBClass
    {
        public ModelClass(DataTable dataTable) : base(dataTable.TableName, VBClassModifier.PublicPartial)
        {
            CreateProperties(dataTable);
            CreateConstructor();
        }

        private void CreateProperties(DataTable dataTable)
        {
            VBProperty property;
            List<VBProperty> properties = new List<VBProperty>();

            foreach (DataColumn clm in dataTable.Columns)
            {
                string typeName = ProperVBTypeName.Get(clm);
                string name = ProperVarName.Get(clm.ColumnName);

                property = new VBProperty(typeName, name, VBMemberModifier.PublicOverridable);
                properties.Add(property);
            }
            this.Properties = properties;
        }

        private void CreateConstructor()
        {
            var constructor = new VBClassConstructor();
            this.Constructors.Add(constructor);
        }
    }
}
