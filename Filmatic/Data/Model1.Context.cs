namespace Filmatic.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FilmaticEntities : DbContext
    {
        public FilmaticEntities()
            : base("name=FilmaticEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<auth_app_privileges> auth_app_privileges { get; set; }
        public virtual DbSet<auth_permisions> auth_permisions { get; set; }
        public virtual DbSet<auth_roles> auth_roles { get; set; }
        public virtual DbSet<auth_user_roles> auth_user_roles { get; set; }
        public virtual DbSet<auth_users> auth_users { get; set; }
        public virtual DbSet<cat_genres_movies> cat_genres_movies { get; set; }
        public virtual DbSet<cat_movies> cat_movies { get; set; }
        public virtual DbSet<cinema_agencies> cinema_agencies { get; set; }
        public virtual DbSet<cinema_functions> cinema_functions { get; set; }
        public virtual DbSet<cinema_rooms> cinema_rooms { get; set; }
        public virtual DbSet<invoice> invoice { get; set; }
        public virtual DbSet<invoice_deta> invoice_deta { get; set; }
        public virtual DbSet<payment_cards> payment_cards { get; set; }
    
        public virtual ObjectResult<P_CreateHashedPassword_Result> P_CreateHashedPassword(string pv_password)
        {
            var pv_passwordParameter = pv_password != null ?
                new ObjectParameter("Pv_password", pv_password) :
                new ObjectParameter("Pv_password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<P_CreateHashedPassword_Result>("P_CreateHashedPassword", pv_passwordParameter);
        }
    
        public virtual int P_CreateUser(string lv_username, string lv_password, string lv_name, string lv_lastname, string lv_email, string lv_phone_number)
        {
            var lv_usernameParameter = lv_username != null ?
                new ObjectParameter("Lv_username", lv_username) :
                new ObjectParameter("Lv_username", typeof(string));
    
            var lv_passwordParameter = lv_password != null ?
                new ObjectParameter("Lv_password", lv_password) :
                new ObjectParameter("Lv_password", typeof(string));
    
            var lv_nameParameter = lv_name != null ?
                new ObjectParameter("Lv_name", lv_name) :
                new ObjectParameter("Lv_name", typeof(string));
    
            var lv_lastnameParameter = lv_lastname != null ?
                new ObjectParameter("Lv_lastname", lv_lastname) :
                new ObjectParameter("Lv_lastname", typeof(string));
    
            var lv_emailParameter = lv_email != null ?
                new ObjectParameter("Lv_email", lv_email) :
                new ObjectParameter("Lv_email", typeof(string));
    
            var lv_phone_numberParameter = lv_phone_number != null ?
                new ObjectParameter("Lv_phone_number", lv_phone_number) :
                new ObjectParameter("Lv_phone_number", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_CreateUser", lv_usernameParameter, lv_passwordParameter, lv_nameParameter, lv_lastnameParameter, lv_emailParameter, lv_phone_numberParameter);
        }
    }
}