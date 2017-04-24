using System;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Database(Name="NovaPlaca")]
public class UserKorisnikDataContext : DataContext
{
    private static MappingSource mappingSource = new AttributeMappingSource();

    public UserKorisnikDataContext() : base(My.MySettings.Default.NovaPlacaConnectionString, mappingSource)
    {
    }

    public UserKorisnikDataContext(IDbConnection connection) : base(connection, mappingSource)
    {
    }

    public UserKorisnikDataContext(string connection) : base(connection, mappingSource)
    {
    }

    public UserKorisnikDataContext(IDbConnection connection, MappingSource mappingSource) : base(connection, mappingSource)
    {
    }

    public UserKorisnikDataContext(string connection, MappingSource mappingSource) : base(connection, mappingSource)
    {
    }

    public Table<KORISNIK> KORISNIKs
    {
        get
        {
            return this.GetTable<KORISNIK>();
        }
    }

    public Table<USER> USERs
    {
        get
        {
            return this.GetTable<USER>();
        }
    }
}

