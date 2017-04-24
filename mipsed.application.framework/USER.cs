using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[Table(Name="dbo.USERS")]
public class USER : INotifyPropertyChanging, INotifyPropertyChanged
{
    private string _IDUSER;
    private EntityRef<KORISNIK> _KORISNIK = new EntityRef<KORISNIK>();
    private int _KORISNIKUSERIDKORISNIK;
    private string _NAZIVUSER;
    private string _PWDUSER;
    private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

    public event PropertyChangedEventHandler PropertyChanged;

    public event PropertyChangingEventHandler PropertyChanging;

    //public event PropertyChangedEventHandler System.ComponentModel.INotifyPropertyChanged.PropertyChanged;

    //public event PropertyChangingEventHandler System.ComponentModel.INotifyPropertyChanging.PropertyChanging;

    protected virtual void SendPropertyChanged(string propertyName)
    {
        if (this.PropertyChanged != null)
        {
            PropertyChangedEventHandler propertyChangedEvent = this.PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    protected virtual void SendPropertyChanging()
    {
        if (this.PropertyChanging != null)
        {
            PropertyChangingEventHandler propertyChangingEvent = this.PropertyChanging;
            if (propertyChangingEvent != null)
            {
                propertyChangingEvent(this, emptyChangingEventArgs);
            }
        }
    }

    [Column(Storage="_IDUSER", DbType="NVarChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
    public string IDUSER
    {
        get
        {
            return this._IDUSER;
        }
        set
        {
            if (!string.Equals(this._IDUSER, value))
            {
                this.SendPropertyChanging();
                this._IDUSER = value;
                this.SendPropertyChanged("IDUSER");
            }
        }
    }

    [Association(Name="KORISNIK_USER", Storage="_KORISNIK", ThisKey="KORISNIKUSERIDKORISNIK", OtherKey="IDKORISNIK", IsForeignKey=true)]
    public KORISNIK KORISNIK
    {
        get
        {
            return this._KORISNIK.Entity;
        }
        set
        {
            KORISNIK entity = this._KORISNIK.Entity;
            if (!object.Equals(entity, value) || !this._KORISNIK.HasLoadedOrAssignedValue)
            {
                this.SendPropertyChanging();
                if (entity != null)
                {
                    this._KORISNIK.Entity = null;
                    entity.USERs.Remove(this);
                }
                this._KORISNIK.Entity = value;
                if (value != null)
                {
                    value.USERs.Add(this);
                    this._KORISNIKUSERIDKORISNIK = value.IDKORISNIK;
                }
                else
                {
                    this._KORISNIKUSERIDKORISNIK = 0;
                }
                this.SendPropertyChanged("KORISNIK");
            }
        }
    }

    [Column(Storage="_KORISNIKUSERIDKORISNIK", DbType="Int NOT NULL", IsPrimaryKey=true)]
    public int KORISNIKUSERIDKORISNIK
    {
        get
        {
            return this._KORISNIKUSERIDKORISNIK;
        }
        set
        {
            if (this._KORISNIKUSERIDKORISNIK != value)
            {
                if (this._KORISNIK.HasLoadedOrAssignedValue)
                {
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                }
                this.SendPropertyChanging();
                this._KORISNIKUSERIDKORISNIK = value;
                this.SendPropertyChanged("KORISNIKUSERIDKORISNIK");
            }
        }
    }

    [Column(Storage="_NAZIVUSER", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
    public string NAZIVUSER
    {
        get
        {
            return this._NAZIVUSER;
        }
        set
        {
            if (!string.Equals(this._NAZIVUSER, value))
            {
                this.SendPropertyChanging();
                this._NAZIVUSER = value;
                this.SendPropertyChanged("NAZIVUSER");
            }
        }
    }

    [Column(Storage="_PWDUSER", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
    public string PWDUSER
    {
        get
        {
            return this._PWDUSER;
        }
        set
        {
            if (!string.Equals(this._PWDUSER, value))
            {
                this.SendPropertyChanging();
                this._PWDUSER = value;
                this.SendPropertyChanged("PWDUSER");
            }
        }
    }
}

