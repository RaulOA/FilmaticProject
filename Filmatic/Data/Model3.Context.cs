﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Filmatic.Data
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class CineMaxTicketsDB11Entities3 : DbContext
{
    public CineMaxTicketsDB11Entities3()
        : base("name=CineMaxTicketsDB11Entities3")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }



    public virtual int P_CreateUser(string lv_username, string lv_password, string lv_name, string lv_lastname, string lv_email, string lv_phone_number, string lv_id_document, Nullable<System.DateTime> lv_birthday_date)
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


        var lv_id_documentParameter = lv_id_document != null ?
            new ObjectParameter("Lv_id_document", lv_id_document) :
            new ObjectParameter("Lv_id_document", typeof(string));


        var lv_birthday_dateParameter = lv_birthday_date.HasValue ?
            new ObjectParameter("Lv_birthday_date", lv_birthday_date) :
            new ObjectParameter("Lv_birthday_date", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_CreateUser", lv_usernameParameter, lv_passwordParameter, lv_nameParameter, lv_lastnameParameter, lv_emailParameter, lv_phone_numberParameter, lv_id_documentParameter, lv_birthday_dateParameter);
    }


    public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
    {

        var diagramnameParameter = diagramname != null ?
            new ObjectParameter("diagramname", diagramname) :
            new ObjectParameter("diagramname", typeof(string));


        var owner_idParameter = owner_id.HasValue ?
            new ObjectParameter("owner_id", owner_id) :
            new ObjectParameter("owner_id", typeof(int));


        var versionParameter = version.HasValue ?
            new ObjectParameter("version", version) :
            new ObjectParameter("version", typeof(int));


        var definitionParameter = definition != null ?
            new ObjectParameter("definition", definition) :
            new ObjectParameter("definition", typeof(byte[]));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
    }


    public virtual int sp_CreateCinemaFunctionTickets(string lv_id_user, string lv_id_cinema_function)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_id_cinema_functionParameter = lv_id_cinema_function != null ?
            new ObjectParameter("Lv_id_cinema_function", lv_id_cinema_function) :
            new ObjectParameter("Lv_id_cinema_function", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateCinemaFunctionTickets", lv_id_userParameter, lv_id_cinema_functionParameter);
    }


    public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
    {

        var diagramnameParameter = diagramname != null ?
            new ObjectParameter("diagramname", diagramname) :
            new ObjectParameter("diagramname", typeof(string));


        var owner_idParameter = owner_id.HasValue ?
            new ObjectParameter("owner_id", owner_id) :
            new ObjectParameter("owner_id", typeof(int));


        var versionParameter = version.HasValue ?
            new ObjectParameter("version", version) :
            new ObjectParameter("version", typeof(int));


        var definitionParameter = definition != null ?
            new ObjectParameter("definition", definition) :
            new ObjectParameter("definition", typeof(byte[]));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
    }


    public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
    {

        var diagramnameParameter = diagramname != null ?
            new ObjectParameter("diagramname", diagramname) :
            new ObjectParameter("diagramname", typeof(string));


        var owner_idParameter = owner_id.HasValue ?
            new ObjectParameter("owner_id", owner_id) :
            new ObjectParameter("owner_id", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
    }


    public virtual int sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
    {

        var diagramnameParameter = diagramname != null ?
            new ObjectParameter("diagramname", diagramname) :
            new ObjectParameter("diagramname", typeof(string));


        var owner_idParameter = owner_id.HasValue ?
            new ObjectParameter("owner_id", owner_id) :
            new ObjectParameter("owner_id", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
    }


    public virtual int sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
    {

        var diagramnameParameter = diagramname != null ?
            new ObjectParameter("diagramname", diagramname) :
            new ObjectParameter("diagramname", typeof(string));


        var owner_idParameter = owner_id.HasValue ?
            new ObjectParameter("owner_id", owner_id) :
            new ObjectParameter("owner_id", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
    }


    public virtual ObjectResult<sp_LoginUser_Result> sp_LoginUser(string lv_username, string lv_password)
    {

        var lv_usernameParameter = lv_username != null ?
            new ObjectParameter("Lv_username", lv_username) :
            new ObjectParameter("Lv_username", typeof(string));


        var lv_passwordParameter = lv_password != null ?
            new ObjectParameter("Lv_password", lv_password) :
            new ObjectParameter("Lv_password", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_LoginUser_Result>("sp_LoginUser", lv_usernameParameter, lv_passwordParameter);
    }


    public virtual ObjectResult<sp_ManageDMLCatPermission_Result> sp_ManageDMLCatPermission(string lv_id_user, string lv_dml_action, string lv_permission_id, string lv_permission_description)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_dml_actionParameter = lv_dml_action != null ?
            new ObjectParameter("Lv_dml_action", lv_dml_action) :
            new ObjectParameter("Lv_dml_action", typeof(string));


        var lv_permission_idParameter = lv_permission_id != null ?
            new ObjectParameter("Lv_permission_id", lv_permission_id) :
            new ObjectParameter("Lv_permission_id", typeof(string));


        var lv_permission_descriptionParameter = lv_permission_description != null ?
            new ObjectParameter("Lv_permission_description", lv_permission_description) :
            new ObjectParameter("Lv_permission_description", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ManageDMLCatPermission_Result>("sp_ManageDMLCatPermission", lv_id_userParameter, lv_dml_actionParameter, lv_permission_idParameter, lv_permission_descriptionParameter);
    }


    public virtual ObjectResult<sp_ManageDMLCatRoles_Result> sp_ManageDMLCatRoles(string lv_id_user, string lv_dml_action, string lv_role_id, string lv_role_description)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_dml_actionParameter = lv_dml_action != null ?
            new ObjectParameter("Lv_dml_action", lv_dml_action) :
            new ObjectParameter("Lv_dml_action", typeof(string));


        var lv_role_idParameter = lv_role_id != null ?
            new ObjectParameter("Lv_role_id", lv_role_id) :
            new ObjectParameter("Lv_role_id", typeof(string));


        var lv_role_descriptionParameter = lv_role_description != null ?
            new ObjectParameter("Lv_role_description", lv_role_description) :
            new ObjectParameter("Lv_role_description", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ManageDMLCatRoles_Result>("sp_ManageDMLCatRoles", lv_id_userParameter, lv_dml_actionParameter, lv_role_idParameter, lv_role_descriptionParameter);
    }


    public virtual ObjectResult<sp_ManageDMLCinemaAgencies_Result> sp_ManageDMLCinemaAgencies(string lv_id_user, string lv_dml_action, string lv_id, string lv_title, string lv_description, string lv_direction)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_dml_actionParameter = lv_dml_action != null ?
            new ObjectParameter("Lv_dml_action", lv_dml_action) :
            new ObjectParameter("Lv_dml_action", typeof(string));


        var lv_idParameter = lv_id != null ?
            new ObjectParameter("Lv_id", lv_id) :
            new ObjectParameter("Lv_id", typeof(string));


        var lv_titleParameter = lv_title != null ?
            new ObjectParameter("Lv_title", lv_title) :
            new ObjectParameter("Lv_title", typeof(string));


        var lv_descriptionParameter = lv_description != null ?
            new ObjectParameter("Lv_description", lv_description) :
            new ObjectParameter("Lv_description", typeof(string));


        var lv_directionParameter = lv_direction != null ?
            new ObjectParameter("Lv_direction", lv_direction) :
            new ObjectParameter("Lv_direction", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ManageDMLCinemaAgencies_Result>("sp_ManageDMLCinemaAgencies", lv_id_userParameter, lv_dml_actionParameter, lv_idParameter, lv_titleParameter, lv_descriptionParameter, lv_directionParameter);
    }


    public virtual ObjectResult<sp_ManageDMLCinemaAgencyRooms_Result> sp_ManageDMLCinemaAgencyRooms(string lv_id_user, string lv_dml_action, string lv_id, string lv_id_agency, Nullable<int> lv_number_room, string lv_title, string lv_ubication, string lv_description, string lv_model, string lv_status)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_dml_actionParameter = lv_dml_action != null ?
            new ObjectParameter("Lv_dml_action", lv_dml_action) :
            new ObjectParameter("Lv_dml_action", typeof(string));


        var lv_idParameter = lv_id != null ?
            new ObjectParameter("Lv_id", lv_id) :
            new ObjectParameter("Lv_id", typeof(string));


        var lv_id_agencyParameter = lv_id_agency != null ?
            new ObjectParameter("Lv_id_agency", lv_id_agency) :
            new ObjectParameter("Lv_id_agency", typeof(string));


        var lv_number_roomParameter = lv_number_room.HasValue ?
            new ObjectParameter("Lv_number_room", lv_number_room) :
            new ObjectParameter("Lv_number_room", typeof(int));


        var lv_titleParameter = lv_title != null ?
            new ObjectParameter("Lv_title", lv_title) :
            new ObjectParameter("Lv_title", typeof(string));


        var lv_ubicationParameter = lv_ubication != null ?
            new ObjectParameter("Lv_ubication", lv_ubication) :
            new ObjectParameter("Lv_ubication", typeof(string));


        var lv_descriptionParameter = lv_description != null ?
            new ObjectParameter("Lv_description", lv_description) :
            new ObjectParameter("Lv_description", typeof(string));


        var lv_modelParameter = lv_model != null ?
            new ObjectParameter("Lv_model", lv_model) :
            new ObjectParameter("Lv_model", typeof(string));


        var lv_statusParameter = lv_status != null ?
            new ObjectParameter("Lv_status", lv_status) :
            new ObjectParameter("Lv_status", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ManageDMLCinemaAgencyRooms_Result>("sp_ManageDMLCinemaAgencyRooms", lv_id_userParameter, lv_dml_actionParameter, lv_idParameter, lv_id_agencyParameter, lv_number_roomParameter, lv_titleParameter, lv_ubicationParameter, lv_descriptionParameter, lv_modelParameter, lv_statusParameter);
    }


    public virtual ObjectResult<sp_ManageDMLCinemaCatMovies_Result> sp_ManageDMLCinemaCatMovies(string lv_id_user, string lv_dml_action, string lv_id, string lv_title, string lv_synopsis, string lv_country, string lv_directors, string lv_actors, string lv_writers, Nullable<int> ln_year, Nullable<System.DateTime> ld_relased_date, string lv_url_poster, string lv_clasification, Nullable<decimal> ln_duration, string lv_language)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_dml_actionParameter = lv_dml_action != null ?
            new ObjectParameter("Lv_dml_action", lv_dml_action) :
            new ObjectParameter("Lv_dml_action", typeof(string));


        var lv_idParameter = lv_id != null ?
            new ObjectParameter("Lv_id", lv_id) :
            new ObjectParameter("Lv_id", typeof(string));


        var lv_titleParameter = lv_title != null ?
            new ObjectParameter("Lv_title", lv_title) :
            new ObjectParameter("Lv_title", typeof(string));


        var lv_synopsisParameter = lv_synopsis != null ?
            new ObjectParameter("Lv_synopsis", lv_synopsis) :
            new ObjectParameter("Lv_synopsis", typeof(string));


        var lv_countryParameter = lv_country != null ?
            new ObjectParameter("Lv_country", lv_country) :
            new ObjectParameter("Lv_country", typeof(string));


        var lv_directorsParameter = lv_directors != null ?
            new ObjectParameter("Lv_directors", lv_directors) :
            new ObjectParameter("Lv_directors", typeof(string));


        var lv_actorsParameter = lv_actors != null ?
            new ObjectParameter("Lv_actors", lv_actors) :
            new ObjectParameter("Lv_actors", typeof(string));


        var lv_writersParameter = lv_writers != null ?
            new ObjectParameter("Lv_writers", lv_writers) :
            new ObjectParameter("Lv_writers", typeof(string));


        var ln_yearParameter = ln_year.HasValue ?
            new ObjectParameter("Ln_year", ln_year) :
            new ObjectParameter("Ln_year", typeof(int));


        var ld_relased_dateParameter = ld_relased_date.HasValue ?
            new ObjectParameter("Ld_relased_date", ld_relased_date) :
            new ObjectParameter("Ld_relased_date", typeof(System.DateTime));


        var lv_url_posterParameter = lv_url_poster != null ?
            new ObjectParameter("Lv_url_poster", lv_url_poster) :
            new ObjectParameter("Lv_url_poster", typeof(string));


        var lv_clasificationParameter = lv_clasification != null ?
            new ObjectParameter("Lv_clasification", lv_clasification) :
            new ObjectParameter("Lv_clasification", typeof(string));


        var ln_durationParameter = ln_duration.HasValue ?
            new ObjectParameter("Ln_duration", ln_duration) :
            new ObjectParameter("Ln_duration", typeof(decimal));


        var lv_languageParameter = lv_language != null ?
            new ObjectParameter("Lv_language", lv_language) :
            new ObjectParameter("Lv_language", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ManageDMLCinemaCatMovies_Result>("sp_ManageDMLCinemaCatMovies", lv_id_userParameter, lv_dml_actionParameter, lv_idParameter, lv_titleParameter, lv_synopsisParameter, lv_countryParameter, lv_directorsParameter, lv_actorsParameter, lv_writersParameter, ln_yearParameter, ld_relased_dateParameter, lv_url_posterParameter, lv_clasificationParameter, ln_durationParameter, lv_languageParameter);
    }


    public virtual ObjectResult<sp_ManageDMLCinemaFunctions_Result> sp_ManageDMLCinemaFunctions(string lv_id_user, string lv_dml_action, string lv_id, string lv_id_room, Nullable<decimal> lv_duration, Nullable<System.DateTime> lv_start_date, string lv_id_movie, string lv_format_movie, Nullable<decimal> lv_ticket_price)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_dml_actionParameter = lv_dml_action != null ?
            new ObjectParameter("Lv_dml_action", lv_dml_action) :
            new ObjectParameter("Lv_dml_action", typeof(string));


        var lv_idParameter = lv_id != null ?
            new ObjectParameter("Lv_id", lv_id) :
            new ObjectParameter("Lv_id", typeof(string));


        var lv_id_roomParameter = lv_id_room != null ?
            new ObjectParameter("Lv_id_room", lv_id_room) :
            new ObjectParameter("Lv_id_room", typeof(string));


        var lv_durationParameter = lv_duration.HasValue ?
            new ObjectParameter("Lv_duration", lv_duration) :
            new ObjectParameter("Lv_duration", typeof(decimal));


        var lv_start_dateParameter = lv_start_date.HasValue ?
            new ObjectParameter("Lv_start_date", lv_start_date) :
            new ObjectParameter("Lv_start_date", typeof(System.DateTime));


        var lv_id_movieParameter = lv_id_movie != null ?
            new ObjectParameter("Lv_id_movie", lv_id_movie) :
            new ObjectParameter("Lv_id_movie", typeof(string));


        var lv_format_movieParameter = lv_format_movie != null ?
            new ObjectParameter("Lv_format_movie", lv_format_movie) :
            new ObjectParameter("Lv_format_movie", typeof(string));


        var lv_ticket_priceParameter = lv_ticket_price.HasValue ?
            new ObjectParameter("Lv_ticket_price", lv_ticket_price) :
            new ObjectParameter("Lv_ticket_price", typeof(decimal));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ManageDMLCinemaFunctions_Result>("sp_ManageDMLCinemaFunctions", lv_id_userParameter, lv_dml_actionParameter, lv_idParameter, lv_id_roomParameter, lv_durationParameter, lv_start_dateParameter, lv_id_movieParameter, lv_format_movieParameter, lv_ticket_priceParameter);
    }


    public virtual ObjectResult<sp_ManageDMLCinemaGenresMovie_Result> sp_ManageDMLCinemaGenresMovie(string lv_id_user, string lv_dml_action, string lv_code, string lv_title, string lv_description)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_dml_actionParameter = lv_dml_action != null ?
            new ObjectParameter("Lv_dml_action", lv_dml_action) :
            new ObjectParameter("Lv_dml_action", typeof(string));


        var lv_codeParameter = lv_code != null ?
            new ObjectParameter("Lv_code", lv_code) :
            new ObjectParameter("Lv_code", typeof(string));


        var lv_titleParameter = lv_title != null ?
            new ObjectParameter("Lv_title", lv_title) :
            new ObjectParameter("Lv_title", typeof(string));


        var lv_descriptionParameter = lv_description != null ?
            new ObjectParameter("Lv_description", lv_description) :
            new ObjectParameter("Lv_description", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ManageDMLCinemaGenresMovie_Result>("sp_ManageDMLCinemaGenresMovie", lv_id_userParameter, lv_dml_actionParameter, lv_codeParameter, lv_titleParameter, lv_descriptionParameter);
    }


    public virtual ObjectResult<sp_ManagePermissionsRole_Result> sp_ManagePermissionsRole(string lv_id_user, string lv_id_permission, string lv_id_role, string lv_action)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_id_permissionParameter = lv_id_permission != null ?
            new ObjectParameter("Lv_id_permission", lv_id_permission) :
            new ObjectParameter("Lv_id_permission", typeof(string));


        var lv_id_roleParameter = lv_id_role != null ?
            new ObjectParameter("Lv_id_role", lv_id_role) :
            new ObjectParameter("Lv_id_role", typeof(string));


        var lv_actionParameter = lv_action != null ?
            new ObjectParameter("Lv_action", lv_action) :
            new ObjectParameter("Lv_action", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ManagePermissionsRole_Result>("sp_ManagePermissionsRole", lv_id_userParameter, lv_id_permissionParameter, lv_id_roleParameter, lv_actionParameter);
    }


    public virtual ObjectResult<sp_ManageUserRoles_Result> sp_ManageUserRoles(string lv_id_user, string lv_id_user_role, string lv_role_id_user, string lv_status)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_id_user_roleParameter = lv_id_user_role != null ?
            new ObjectParameter("Lv_id_user_role", lv_id_user_role) :
            new ObjectParameter("Lv_id_user_role", typeof(string));


        var lv_role_id_userParameter = lv_role_id_user != null ?
            new ObjectParameter("Lv_role_id_user", lv_role_id_user) :
            new ObjectParameter("Lv_role_id_user", typeof(string));


        var lv_statusParameter = lv_status != null ?
            new ObjectParameter("Lv_status", lv_status) :
            new ObjectParameter("Lv_status", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ManageUserRoles_Result>("sp_ManageUserRoles", lv_id_userParameter, lv_id_user_roleParameter, lv_role_id_userParameter, lv_statusParameter);
    }


    public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
    {

        var diagramnameParameter = diagramname != null ?
            new ObjectParameter("diagramname", diagramname) :
            new ObjectParameter("diagramname", typeof(string));


        var owner_idParameter = owner_id.HasValue ?
            new ObjectParameter("owner_id", owner_id) :
            new ObjectParameter("owner_id", typeof(int));


        var new_diagramnameParameter = new_diagramname != null ?
            new ObjectParameter("new_diagramname", new_diagramname) :
            new ObjectParameter("new_diagramname", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
    }


    public virtual int sp_upgraddiagrams()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
    }


    public virtual ObjectResult<sp_GetCinemaFunctionDataByID_Result> sp_GetCinemaFunctionDataByID(string lv_id_function)
    {

        var lv_id_functionParameter = lv_id_function != null ?
            new ObjectParameter("Lv_id_function", lv_id_function) :
            new ObjectParameter("Lv_id_function", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetCinemaFunctionDataByID_Result>("sp_GetCinemaFunctionDataByID", lv_id_functionParameter);
    }


    public virtual ObjectResult<sp_GetCinemaMoviesForMainScreen_Result> sp_GetCinemaMoviesForMainScreen()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetCinemaMoviesForMainScreen_Result>("sp_GetCinemaMoviesForMainScreen");
    }


    public virtual ObjectResult<sp_GetCinemaFunctionsDataByIDMovie_Result> sp_GetCinemaFunctionsDataByIDMovie(string lv_id_movie)
    {

        var lv_id_movieParameter = lv_id_movie != null ?
            new ObjectParameter("Lv_id_movie", lv_id_movie) :
            new ObjectParameter("Lv_id_movie", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetCinemaFunctionsDataByIDMovie_Result>("sp_GetCinemaFunctionsDataByIDMovie", lv_id_movieParameter);
    }


    public virtual ObjectResult<sp_GetCinemaFunctionTicketsNotAvaible_Result> sp_GetCinemaFunctionTicketsNotAvaible(string lv_id_user, string lv_id_function)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_id_functionParameter = lv_id_function != null ?
            new ObjectParameter("Lv_id_function", lv_id_function) :
            new ObjectParameter("Lv_id_function", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetCinemaFunctionTicketsNotAvaible_Result>("sp_GetCinemaFunctionTicketsNotAvaible", lv_id_userParameter, lv_id_functionParameter);
    }


    public virtual ObjectResult<sp_GetCinemaFunctionTicketsSelectedByUser_Result> sp_GetCinemaFunctionTicketsSelectedByUser(string lv_id_user, string lv_id_function)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_id_functionParameter = lv_id_function != null ?
            new ObjectParameter("Lv_id_function", lv_id_function) :
            new ObjectParameter("Lv_id_function", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetCinemaFunctionTicketsSelectedByUser_Result>("sp_GetCinemaFunctionTicketsSelectedByUser", lv_id_userParameter, lv_id_functionParameter);
    }


    public virtual int sp_ManageCinemaTickets(string lv_id_user, string lv_action, string lv_id_function, string lv_row_num_seat, string lv_col_num_seat)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_actionParameter = lv_action != null ?
            new ObjectParameter("Lv_action", lv_action) :
            new ObjectParameter("Lv_action", typeof(string));


        var lv_id_functionParameter = lv_id_function != null ?
            new ObjectParameter("Lv_id_function", lv_id_function) :
            new ObjectParameter("Lv_id_function", typeof(string));


        var lv_row_num_seatParameter = lv_row_num_seat != null ?
            new ObjectParameter("Lv_row_num_seat", lv_row_num_seat) :
            new ObjectParameter("Lv_row_num_seat", typeof(string));


        var lv_col_num_seatParameter = lv_col_num_seat != null ?
            new ObjectParameter("Lv_col_num_seat", lv_col_num_seat) :
            new ObjectParameter("Lv_col_num_seat", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ManageCinemaTickets", lv_id_userParameter, lv_actionParameter, lv_id_functionParameter, lv_row_num_seatParameter, lv_col_num_seatParameter);
    }


    public virtual int sp_ManageCinemaTicketsByList(string lv_id_user, string lv_action, string lv_id_function, string lv_list_tickets)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_actionParameter = lv_action != null ?
            new ObjectParameter("Lv_action", lv_action) :
            new ObjectParameter("Lv_action", typeof(string));


        var lv_id_functionParameter = lv_id_function != null ?
            new ObjectParameter("Lv_id_function", lv_id_function) :
            new ObjectParameter("Lv_id_function", typeof(string));


        var lv_list_ticketsParameter = lv_list_tickets != null ?
            new ObjectParameter("Lv_list_tickets", lv_list_tickets) :
            new ObjectParameter("Lv_list_tickets", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ManageCinemaTicketsByList", lv_id_userParameter, lv_actionParameter, lv_id_functionParameter, lv_list_ticketsParameter);
    }


    public virtual ObjectResult<sp_ManageDMLPaymentCards_Result> sp_ManageDMLPaymentCards(string lv_id_user, string lv_dml_action, string lv_id_user_credit_card, string lv_id, string lv_represent_name, string lv_card_number, Nullable<int> ln_card_year, Nullable<int> ln_card_month, string lv_card_cv)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_dml_actionParameter = lv_dml_action != null ?
            new ObjectParameter("Lv_dml_action", lv_dml_action) :
            new ObjectParameter("Lv_dml_action", typeof(string));


        var lv_id_user_credit_cardParameter = lv_id_user_credit_card != null ?
            new ObjectParameter("Lv_id_user_credit_card", lv_id_user_credit_card) :
            new ObjectParameter("Lv_id_user_credit_card", typeof(string));


        var lv_idParameter = lv_id != null ?
            new ObjectParameter("Lv_id", lv_id) :
            new ObjectParameter("Lv_id", typeof(string));


        var lv_represent_nameParameter = lv_represent_name != null ?
            new ObjectParameter("Lv_represent_name", lv_represent_name) :
            new ObjectParameter("Lv_represent_name", typeof(string));


        var lv_card_numberParameter = lv_card_number != null ?
            new ObjectParameter("Lv_card_number", lv_card_number) :
            new ObjectParameter("Lv_card_number", typeof(string));


        var ln_card_yearParameter = ln_card_year.HasValue ?
            new ObjectParameter("Ln_card_year", ln_card_year) :
            new ObjectParameter("Ln_card_year", typeof(int));


        var ln_card_monthParameter = ln_card_month.HasValue ?
            new ObjectParameter("Ln_card_month", ln_card_month) :
            new ObjectParameter("Ln_card_month", typeof(int));


        var lv_card_cvParameter = lv_card_cv != null ?
            new ObjectParameter("Lv_card_cv", lv_card_cv) :
            new ObjectParameter("Lv_card_cv", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ManageDMLPaymentCards_Result>("sp_ManageDMLPaymentCards", lv_id_userParameter, lv_dml_actionParameter, lv_id_user_credit_cardParameter, lv_idParameter, lv_represent_nameParameter, lv_card_numberParameter, ln_card_yearParameter, ln_card_monthParameter, lv_card_cvParameter);
    }


    public virtual int sp_CreateInvoice(string lv_id_user, string lv_id_function, string lv_id_payment_card)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_id_functionParameter = lv_id_function != null ?
            new ObjectParameter("Lv_id_function", lv_id_function) :
            new ObjectParameter("Lv_id_function", typeof(string));


        var lv_id_payment_cardParameter = lv_id_payment_card != null ?
            new ObjectParameter("Lv_id_payment_card", lv_id_payment_card) :
            new ObjectParameter("Lv_id_payment_card", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateInvoice", lv_id_userParameter, lv_id_functionParameter, lv_id_payment_cardParameter);
    }


    public virtual ObjectResult<sp_GetInvoiceDetailsByInvoiceId_Result> sp_GetInvoiceDetailsByInvoiceId(string lv_id_user, Nullable<int> ln_id_invoice)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var ln_id_invoiceParameter = ln_id_invoice.HasValue ?
            new ObjectParameter("Ln_id_invoice", ln_id_invoice) :
            new ObjectParameter("Ln_id_invoice", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetInvoiceDetailsByInvoiceId_Result>("sp_GetInvoiceDetailsByInvoiceId", lv_id_userParameter, ln_id_invoiceParameter);
    }


    public virtual ObjectResult<sp_GetInvoicesByUser_Result> sp_GetInvoicesByUser(string lv_id_user)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetInvoicesByUser_Result>("sp_GetInvoicesByUser", lv_id_userParameter);
    }


    public virtual int P_UpdateUser(string lv_id_user, string lv_username, string lv_name, string lv_lastname, string lv_email, string lv_phone_number, string lv_password)
    {

        var lv_id_userParameter = lv_id_user != null ?
            new ObjectParameter("Lv_id_user", lv_id_user) :
            new ObjectParameter("Lv_id_user", typeof(string));


        var lv_usernameParameter = lv_username != null ?
            new ObjectParameter("Lv_username", lv_username) :
            new ObjectParameter("Lv_username", typeof(string));


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


        var lv_passwordParameter = lv_password != null ?
            new ObjectParameter("Lv_password", lv_password) :
            new ObjectParameter("Lv_password", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_UpdateUser", lv_id_userParameter, lv_usernameParameter, lv_nameParameter, lv_lastnameParameter, lv_emailParameter, lv_phone_numberParameter, lv_passwordParameter);
    }


    public virtual int P_CheckUserExists(string lv_username, string lv_password, ObjectParameter userExists)
    {

        var lv_usernameParameter = lv_username != null ?
            new ObjectParameter("Lv_username", lv_username) :
            new ObjectParameter("Lv_username", typeof(string));


        var lv_passwordParameter = lv_password != null ?
            new ObjectParameter("Lv_password", lv_password) :
            new ObjectParameter("Lv_password", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_CheckUserExists", lv_usernameParameter, lv_passwordParameter, userExists);
    }

}

}

