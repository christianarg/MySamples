//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace UnitTestProject1
{
    public partial class Model1Container1 : ObjectContext
    {
        public const string ConnectionString = "name=Model1Container1";
        public const string ContainerName = "Model1Container1";
    
        #region Constructors
    
        public Model1Container1()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public Model1Container1(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public Model1Container1(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Entity1> Entity1Set
        {
            get { return _entity1Set  ?? (_entity1Set = CreateObjectSet<Entity1>("Entity1Set")); }
        }
        private ObjectSet<Entity1> _entity1Set;

        #endregion

    }
}
