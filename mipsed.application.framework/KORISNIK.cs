using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[Table(Name="dbo.KORISNIK")]
public class KORISNIK : INotifyPropertyChanging, INotifyPropertyChanged
{
    private string _EMAIL;
    private int _IDKORISNIK;
    private string _JMBGKORISNIK;
    private string _KONTAKTFAX;
    private string _KONTAKTOSOBA;
    private string _KONTAKTTELEFON;
    private string _KORISNIK1ADRESA;
    private string _KORISNIK1MJESTO;
    private string _KORISNIK1NAZIV;
    private string _MBKORISNIK;
    private string _MBKORISNIKJEDINICA;
    private string _NADLEZNAPU;
    private Binary _PROFILECATALOG;
    private int? _RKP;
    private bool _STAZUKOEFICIJENTU;
    private EntitySet<USER> _USERs;
    private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

    public event PropertyChangedEventHandler PropertyChanged;
    public event PropertyChangingEventHandler PropertyChanging;

    //public event PropertyChangedEventHandler System.ComponentModel.INotifyPropertyChanged.PropertyChanged;
    //public event PropertyChangingEventHandler System.ComponentModel.INotifyPropertyChanging.PropertyChanging;

    public KORISNIK()
    {
        this._USERs = new EntitySet<USER>(new Action<USER>(this.attach_USERs), new Action<USER>(this.detach_USERs));
    }

    private void attach_USERs(USER entity)
    {
        this.SendPropertyChanging();
        entity.KORISNIK = this;
    }

    private void detach_USERs(USER entity)
    {
        this.SendPropertyChanging();
        entity.KORISNIK = null;
    }

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

    [Column(Storage="_EMAIL", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
    public string EMAIL
    {
        get
        {
            return this._EMAIL;
        }
        set
        {
            if (!string.Equals(this._EMAIL, value))
            {
                this.SendPropertyChanging();
                this._EMAIL = value;
                this.SendPropertyChanged("EMAIL");
            }
        }
    }

    [Column(Storage="_IDKORISNIK", DbType="Int NOT NULL", IsPrimaryKey=true)]
    public int IDKORISNIK
    {
        get
        {
            return this._IDKORISNIK;
        }
        set
        {
            if (this._IDKORISNIK != value)
            {
                this.SendPropertyChanging();
                this._IDKORISNIK = value;
                this.SendPropertyChanged("IDKORISNIK");
            }
        }
    }

    [Column(Storage="_JMBGKORISNIK", DbType="NVarChar(13)")]
    public string JMBGKORISNIK
    {
        get
        {
            return this._JMBGKORISNIK;
        }
        set
        {
            if (!string.Equals(this._JMBGKORISNIK, value))
            {
                this.SendPropertyChanging();
                this._JMBGKORISNIK = value;
                this.SendPropertyChanged("JMBGKORISNIK");
            }
        }
    }

    [Column(Storage="_KONTAKTFAX", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
    public string KONTAKTFAX
    {
        get
        {
            return this._KONTAKTFAX;
        }
        set
        {
            if (!string.Equals(this._KONTAKTFAX, value))
            {
                this.SendPropertyChanging();
                this._KONTAKTFAX = value;
                this.SendPropertyChanged("KONTAKTFAX");
            }
        }
    }

    [Column(Storage="_KONTAKTOSOBA", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
    public string KONTAKTOSOBA
    {
        get
        {
            return this._KONTAKTOSOBA;
        }
        set
        {
            if (!string.Equals(this._KONTAKTOSOBA, value))
            {
                this.SendPropertyChanging();
                this._KONTAKTOSOBA = value;
                this.SendPropertyChanged("KONTAKTOSOBA");
            }
        }
    }

    [Column(Storage="_KONTAKTTELEFON", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
    public string KONTAKTTELEFON
    {
        get
        {
            return this._KONTAKTTELEFON;
        }
        set
        {
            if (!string.Equals(this._KONTAKTTELEFON, value))
            {
                this.SendPropertyChanging();
                this._KONTAKTTELEFON = value;
                this.SendPropertyChanged("KONTAKTTELEFON");
            }
        }
    }

    [Column(Storage="_KORISNIK1ADRESA", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
    public string KORISNIK1ADRESA
    {
        get
        {
            return this._KORISNIK1ADRESA;
        }
        set
        {
            if (!string.Equals(this._KORISNIK1ADRESA, value))
            {
                this.SendPropertyChanging();
                this._KORISNIK1ADRESA = value;
                this.SendPropertyChanged("KORISNIK1ADRESA");
            }
        }
    }

    [Column(Storage="_KORISNIK1MJESTO", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
    public string KORISNIK1MJESTO
    {
        get
        {
            return this._KORISNIK1MJESTO;
        }
        set
        {
            if (!string.Equals(this._KORISNIK1MJESTO, value))
            {
                this.SendPropertyChanging();
                this._KORISNIK1MJESTO = value;
                this.SendPropertyChanged("KORISNIK1MJESTO");
            }
        }
    }

    [Column(Storage="_KORISNIK1NAZIV", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
    public string KORISNIK1NAZIV
    {
        get
        {
            return this._KORISNIK1NAZIV;
        }
        set
        {
            if (!string.Equals(this._KORISNIK1NAZIV, value))
            {
                this.SendPropertyChanging();
                this._KORISNIK1NAZIV = value;
                this.SendPropertyChanged("KORISNIK1NAZIV");
            }
        }
    }

    [Column(Storage="_MBKORISNIK", DbType="NVarChar(8)")]
    public string MBKORISNIK
    {
        get
        {
            return this._MBKORISNIK;
        }
        set
        {
            if (!string.Equals(this._MBKORISNIK, value))
            {
                this.SendPropertyChanging();
                this._MBKORISNIK = value;
                this.SendPropertyChanged("MBKORISNIK");
            }
        }
    }

    [Column(Storage="_MBKORISNIKJEDINICA", DbType="NVarChar(4)")]
    public string MBKORISNIKJEDINICA
    {
        get
        {
            return this._MBKORISNIKJEDINICA;
        }
        set
        {
            if (!string.Equals(this._MBKORISNIKJEDINICA, value))
            {
                this.SendPropertyChanging();
                this._MBKORISNIKJEDINICA = value;
                this.SendPropertyChanged("MBKORISNIKJEDINICA");
            }
        }
    }

    [Column(Storage="_NADLEZNAPU", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
    public string NADLEZNAPU
    {
        get
        {
            return this._NADLEZNAPU;
        }
        set
        {
            if (!string.Equals(this._NADLEZNAPU, value))
            {
                this.SendPropertyChanging();
                this._NADLEZNAPU = value;
                this.SendPropertyChanged("NADLEZNAPU");
            }
        }
    }

    [Column(Storage="_PROFILECATALOG", DbType="VarBinary(MAX) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
    public Binary PROFILECATALOG
    {
        get
        {
            return this._PROFILECATALOG;
        }
        set
        {
            if (!object.Equals(this._PROFILECATALOG, value))
            {
                this.SendPropertyChanging();
                this._PROFILECATALOG = value;
                this.SendPropertyChanged("PROFILECATALOG");
            }
        }
    }

    [Column(Storage="_RKP", DbType="Int")]
    public int? RKP
    {
        get
        {
            return this._RKP;
        }
        set
        {
            if (!this._RKP.Equals(value))
            {
                this.SendPropertyChanging();
                this._RKP = value;
                this.SendPropertyChanged("RKP");
            }
        }
    }

    [Column(Storage="_STAZUKOEFICIJENTU", DbType="Bit NOT NULL")]
    public bool STAZUKOEFICIJENTU
    {
        get
        {
            return this._STAZUKOEFICIJENTU;
        }
        set
        {
            if (this._STAZUKOEFICIJENTU != value)
            {
                this.SendPropertyChanging();
                this._STAZUKOEFICIJENTU = value;
                this.SendPropertyChanged("STAZUKOEFICIJENTU");
            }
        }
    }

    [Association(Name="KORISNIK_USER", Storage="_USERs", ThisKey="IDKORISNIK", OtherKey="KORISNIKUSERIDKORISNIK")]
    public EntitySet<USER> USERs
    {
        get
        {
            return this._USERs;
        }
        set
        {
            this._USERs.Assign(value);
        }
    }
}

