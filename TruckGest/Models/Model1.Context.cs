﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TruckGest.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class gesTruckEntities2 : DbContext
    {
        public gesTruckEntities2()
            : base("name=gesTruckEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<Nullable<int>> getNReportsOfDay()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getNReportsOfDay");
        }
    
        public virtual ObjectResult<Nullable<double>> getSpendOfReportToDay()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("getSpendOfReportToDay");
        }
    
        public virtual ObjectResult<Nullable<int>> getCarroOperativos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getCarroOperativos");
        }
    
        public virtual ObjectResult<Nullable<int>> getCarroInoperativos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getCarroInoperativos");
        }
    
        public virtual ObjectResult<Nullable<double>> getSpendConductor(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("getSpendConductor", idParameter);
        }
    
        public virtual ObjectResult<Nullable<double>> getSpendConductorToDay(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("getSpendConductorToDay", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> nReportsConductor(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("nReportsConductor", idParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> nReportToDay(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("nReportToDay", idParameter);
        }
    
        public virtual ObjectResult<getLisNreportsForMonth_Result> getLisNreportsForMonth()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getLisNreportsForMonth_Result>("getLisNreportsForMonth");
        }
    
        public virtual ObjectResult<getLisSpendForMonth_Result> getLisSpendForMonth()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getLisSpendForMonth_Result>("getLisSpendForMonth");
        }
    }
}
