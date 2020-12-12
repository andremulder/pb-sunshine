﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DB_9B89D4_sunshine")]
public partial class SunshineDatabaseDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void Insertbandleden(bandleden instance);
  partial void Updatebandleden(bandleden instance);
  partial void Deletebandleden(bandleden instance);
  partial void Insertcontact(contact instance);
  partial void Updatecontact(contact instance);
  partial void Deletecontact(contact instance);
  partial void Insertgastenboek(gastenboek instance);
  partial void Updategastenboek(gastenboek instance);
  partial void Deletegastenboek(gastenboek instance);
  partial void Insertfoto(foto instance);
  partial void Updatefoto(foto instance);
  partial void Deletefoto(foto instance);
  partial void Insertfotoalbum(fotoalbum instance);
  partial void Updatefotoalbum(fotoalbum instance);
  partial void Deletefotoalbum(fotoalbum instance);
  partial void Insertagenda(agenda instance);
  partial void Updateagenda(agenda instance);
  partial void Deleteagenda(agenda instance);
  #endregion
	
	public SunshineDatabaseDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DB_9B89D4_sunshineConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public SunshineDatabaseDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public SunshineDatabaseDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public SunshineDatabaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public SunshineDatabaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<bandleden> bandledens
	{
		get
		{
			return this.GetTable<bandleden>();
		}
	}
	
	public System.Data.Linq.Table<contact> contacts
	{
		get
		{
			return this.GetTable<contact>();
		}
	}
	
	public System.Data.Linq.Table<gastenboek> gastenboeks
	{
		get
		{
			return this.GetTable<gastenboek>();
		}
	}
	
	public System.Data.Linq.Table<foto> fotos
	{
		get
		{
			return this.GetTable<foto>();
		}
	}
	
	public System.Data.Linq.Table<fotoalbum> fotoalbums
	{
		get
		{
			return this.GetTable<fotoalbum>();
		}
	}
	
	public System.Data.Linq.Table<agenda> agendas
	{
		get
		{
			return this.GetTable<agenda>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.bandleden")]
public partial class bandleden : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private string _biografie;
	
	private string _foto;
	
	private int _id;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnbiografieChanging(string value);
    partial void OnbiografieChanged();
    partial void OnfotoChanging(string value);
    partial void OnfotoChanged();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    #endregion
	
	public bandleden()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_biografie", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
	public string biografie
	{
		get
		{
			return this._biografie;
		}
		set
		{
			if ((this._biografie != value))
			{
				this.OnbiografieChanging(value);
				this.SendPropertyChanging();
				this._biografie = value;
				this.SendPropertyChanged("biografie");
				this.OnbiografieChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_foto", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string foto
	{
		get
		{
			return this._foto;
		}
		set
		{
			if ((this._foto != value))
			{
				this.OnfotoChanging(value);
				this.SendPropertyChanging();
				this._foto = value;
				this.SendPropertyChanged("foto");
				this.OnfotoChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((this._id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.contact")]
public partial class contact : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private string _naam;
	
	private string _email;
	
	private string _telefoon;
	
	private string _onderwerp;
	
	private string _bericht;
	
	private string _ip;
	
	private string _host;
	
	private int _ID;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnnaamChanging(string value);
    partial void OnnaamChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OntelefoonChanging(string value);
    partial void OntelefoonChanged();
    partial void OnonderwerpChanging(string value);
    partial void OnonderwerpChanged();
    partial void OnberichtChanging(string value);
    partial void OnberichtChanged();
    partial void OnipChanging(string value);
    partial void OnipChanged();
    partial void OnhostChanging(string value);
    partial void OnhostChanged();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    #endregion
	
	public contact()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_naam", DbType="VarChar(255)")]
	public string naam
	{
		get
		{
			return this._naam;
		}
		set
		{
			if ((this._naam != value))
			{
				this.OnnaamChanging(value);
				this.SendPropertyChanging();
				this._naam = value;
				this.SendPropertyChanged("naam");
				this.OnnaamChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(255)")]
	public string email
	{
		get
		{
			return this._email;
		}
		set
		{
			if ((this._email != value))
			{
				this.OnemailChanging(value);
				this.SendPropertyChanging();
				this._email = value;
				this.SendPropertyChanged("email");
				this.OnemailChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_telefoon", DbType="VarChar(50)")]
	public string telefoon
	{
		get
		{
			return this._telefoon;
		}
		set
		{
			if ((this._telefoon != value))
			{
				this.OntelefoonChanging(value);
				this.SendPropertyChanging();
				this._telefoon = value;
				this.SendPropertyChanged("telefoon");
				this.OntelefoonChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_onderwerp", DbType="VarChar(255)")]
	public string onderwerp
	{
		get
		{
			return this._onderwerp;
		}
		set
		{
			if ((this._onderwerp != value))
			{
				this.OnonderwerpChanging(value);
				this.SendPropertyChanging();
				this._onderwerp = value;
				this.SendPropertyChanged("onderwerp");
				this.OnonderwerpChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bericht", DbType="Text", UpdateCheck=UpdateCheck.Never)]
	public string bericht
	{
		get
		{
			return this._bericht;
		}
		set
		{
			if ((this._bericht != value))
			{
				this.OnberichtChanging(value);
				this.SendPropertyChanging();
				this._bericht = value;
				this.SendPropertyChanged("bericht");
				this.OnberichtChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ip", DbType="VarChar(50)")]
	public string ip
	{
		get
		{
			return this._ip;
		}
		set
		{
			if ((this._ip != value))
			{
				this.OnipChanging(value);
				this.SendPropertyChanging();
				this._ip = value;
				this.SendPropertyChanged("ip");
				this.OnipChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_host", DbType="VarChar(50)")]
	public string host
	{
		get
		{
			return this._host;
		}
		set
		{
			if ((this._host != value))
			{
				this.OnhostChanging(value);
				this.SendPropertyChanging();
				this._host = value;
				this.SendPropertyChanged("host");
				this.OnhostChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int ID
	{
		get
		{
			return this._ID;
		}
		set
		{
			if ((this._ID != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._ID = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.gastenboek")]
public partial class gastenboek : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private string _naam;
	
	private string _email;
	
	private string _woonplaats;
	
	private string _website;
	
	private string _bericht;
	
	private System.Nullable<System.DateTime> _datum;
	
	private string _ip;
	
	private string _host;
	
	private string _browser;
	
	private int _id;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnnaamChanging(string value);
    partial void OnnaamChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnwoonplaatsChanging(string value);
    partial void OnwoonplaatsChanged();
    partial void OnwebsiteChanging(string value);
    partial void OnwebsiteChanged();
    partial void OnberichtChanging(string value);
    partial void OnberichtChanged();
    partial void OndatumChanging(System.Nullable<System.DateTime> value);
    partial void OndatumChanged();
    partial void OnipChanging(string value);
    partial void OnipChanged();
    partial void OnhostChanging(string value);
    partial void OnhostChanged();
    partial void OnbrowserChanging(string value);
    partial void OnbrowserChanged();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    #endregion
	
	public gastenboek()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_naam", DbType="VarChar(100)")]
	public string naam
	{
		get
		{
			return this._naam;
		}
		set
		{
			if ((this._naam != value))
			{
				this.OnnaamChanging(value);
				this.SendPropertyChanging();
				this._naam = value;
				this.SendPropertyChanged("naam");
				this.OnnaamChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(100)")]
	public string email
	{
		get
		{
			return this._email;
		}
		set
		{
			if ((this._email != value))
			{
				this.OnemailChanging(value);
				this.SendPropertyChanging();
				this._email = value;
				this.SendPropertyChanged("email");
				this.OnemailChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_woonplaats", DbType="VarChar(255)")]
	public string woonplaats
	{
		get
		{
			return this._woonplaats;
		}
		set
		{
			if ((this._woonplaats != value))
			{
				this.OnwoonplaatsChanging(value);
				this.SendPropertyChanging();
				this._woonplaats = value;
				this.SendPropertyChanged("woonplaats");
				this.OnwoonplaatsChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_website", DbType="VarChar(255)")]
	public string website
	{
		get
		{
			return this._website;
		}
		set
		{
			if ((this._website != value))
			{
				this.OnwebsiteChanging(value);
				this.SendPropertyChanging();
				this._website = value;
				this.SendPropertyChanged("website");
				this.OnwebsiteChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bericht", DbType="Text", UpdateCheck=UpdateCheck.Never)]
	public string bericht
	{
		get
		{
			return this._bericht;
		}
		set
		{
			if ((this._bericht != value))
			{
				this.OnberichtChanging(value);
				this.SendPropertyChanging();
				this._bericht = value;
				this.SendPropertyChanged("bericht");
				this.OnberichtChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_datum", DbType="DateTime")]
	public System.Nullable<System.DateTime> datum
	{
		get
		{
			return this._datum;
		}
		set
		{
			if ((this._datum != value))
			{
				this.OndatumChanging(value);
				this.SendPropertyChanging();
				this._datum = value;
				this.SendPropertyChanged("datum");
				this.OndatumChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ip", DbType="VarChar(255)")]
	public string ip
	{
		get
		{
			return this._ip;
		}
		set
		{
			if ((this._ip != value))
			{
				this.OnipChanging(value);
				this.SendPropertyChanging();
				this._ip = value;
				this.SendPropertyChanged("ip");
				this.OnipChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_host", DbType="VarChar(255)")]
	public string host
	{
		get
		{
			return this._host;
		}
		set
		{
			if ((this._host != value))
			{
				this.OnhostChanging(value);
				this.SendPropertyChanging();
				this._host = value;
				this.SendPropertyChanged("host");
				this.OnhostChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_browser", DbType="VarChar(255)")]
	public string browser
	{
		get
		{
			return this._browser;
		}
		set
		{
			if ((this._browser != value))
			{
				this.OnbrowserChanging(value);
				this.SendPropertyChanging();
				this._browser = value;
				this.SendPropertyChanged("browser");
				this.OnbrowserChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((this._id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.fotos")]
public partial class foto : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _album_id;
	
	private string _bestandsnaam;
	
	private int _id;
	
	private System.Nullable<int> _bekeken;
	
	private string _host;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onalbum_idChanging(int value);
    partial void Onalbum_idChanged();
    partial void OnbestandsnaamChanging(string value);
    partial void OnbestandsnaamChanged();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnbekekenChanging(System.Nullable<int> value);
    partial void OnbekekenChanged();
    partial void OnhostChanging(string value);
    partial void OnhostChanged();
    #endregion
	
	public foto()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_album_id", DbType="Int NOT NULL")]
	public int album_id
	{
		get
		{
			return this._album_id;
		}
		set
		{
			if ((this._album_id != value))
			{
				this.Onalbum_idChanging(value);
				this.SendPropertyChanging();
				this._album_id = value;
				this.SendPropertyChanged("album_id");
				this.Onalbum_idChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bestandsnaam", DbType="VarChar(255)")]
	public string bestandsnaam
	{
		get
		{
			return this._bestandsnaam;
		}
		set
		{
			if ((this._bestandsnaam != value))
			{
				this.OnbestandsnaamChanging(value);
				this.SendPropertyChanging();
				this._bestandsnaam = value;
				this.SendPropertyChanged("bestandsnaam");
				this.OnbestandsnaamChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((this._id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bekeken", DbType="Int")]
	public System.Nullable<int> bekeken
	{
		get
		{
			return this._bekeken;
		}
		set
		{
			if ((this._bekeken != value))
			{
				this.OnbekekenChanging(value);
				this.SendPropertyChanging();
				this._bekeken = value;
				this.SendPropertyChanged("bekeken");
				this.OnbekekenChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_host", DbType="VarChar(100)")]
	public string host
	{
		get
		{
			return this._host;
		}
		set
		{
			if ((this._host != value))
			{
				this.OnhostChanging(value);
				this.SendPropertyChanging();
				this._host = value;
				this.SendPropertyChanged("host");
				this.OnhostChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.fotoalbum")]
public partial class fotoalbum : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private string _naam;
	
	private System.Nullable<System.DateTime> _datum;
	
	private string _fotomap;
	
	private int _album_id;
	
	private string _soort;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnnaamChanging(string value);
    partial void OnnaamChanged();
    partial void OndatumChanging(System.Nullable<System.DateTime> value);
    partial void OndatumChanged();
    partial void OnfotomapChanging(string value);
    partial void OnfotomapChanged();
    partial void Onalbum_idChanging(int value);
    partial void Onalbum_idChanged();
    partial void OnsoortChanging(string value);
    partial void OnsoortChanged();
    #endregion
	
	public fotoalbum()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_naam", DbType="VarChar(255)")]
	public string naam
	{
		get
		{
			return this._naam;
		}
		set
		{
			if ((this._naam != value))
			{
				this.OnnaamChanging(value);
				this.SendPropertyChanging();
				this._naam = value;
				this.SendPropertyChanged("naam");
				this.OnnaamChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_datum", DbType="Date")]
	public System.Nullable<System.DateTime> datum
	{
		get
		{
			return this._datum;
		}
		set
		{
			if ((this._datum != value))
			{
				this.OndatumChanging(value);
				this.SendPropertyChanging();
				this._datum = value;
				this.SendPropertyChanged("datum");
				this.OndatumChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fotomap", DbType="VarChar(255)")]
	public string fotomap
	{
		get
		{
			return this._fotomap;
		}
		set
		{
			if ((this._fotomap != value))
			{
				this.OnfotomapChanging(value);
				this.SendPropertyChanging();
				this._fotomap = value;
				this.SendPropertyChanged("fotomap");
				this.OnfotomapChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_album_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int album_id
	{
		get
		{
			return this._album_id;
		}
		set
		{
			if ((this._album_id != value))
			{
				this.Onalbum_idChanging(value);
				this.SendPropertyChanging();
				this._album_id = value;
				this.SendPropertyChanged("album_id");
				this.Onalbum_idChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_soort", DbType="VarChar(10)")]
	public string soort
	{
		get
		{
			return this._soort;
		}
		set
		{
			if ((this._soort != value))
			{
				this.OnsoortChanging(value);
				this.SendPropertyChanging();
				this._soort = value;
				this.SendPropertyChanged("soort");
				this.OnsoortChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.agenda")]
public partial class agenda : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private System.DateTime _datum;
	
	private string _adres;
	
	private string _omschrijving;
	
	private System.Nullable<bool> _openbaar;
	
	private System.Nullable<System.TimeSpan> _van;
	
	private System.Nullable<System.TimeSpan> _tot;
	
	private string _googleAgendaSynchId;
	
	private int _id;
	
	private int _agendatype;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OndatumChanging(System.DateTime value);
    partial void OndatumChanged();
    partial void OnadresChanging(string value);
    partial void OnadresChanged();
    partial void OnomschrijvingChanging(string value);
    partial void OnomschrijvingChanged();
    partial void OnopenbaarChanging(System.Nullable<bool> value);
    partial void OnopenbaarChanged();
    partial void OnvanChanging(System.Nullable<System.TimeSpan> value);
    partial void OnvanChanged();
    partial void OntotChanging(System.Nullable<System.TimeSpan> value);
    partial void OntotChanged();
    partial void OngoogleAgendaSynchIdChanging(string value);
    partial void OngoogleAgendaSynchIdChanged();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnagendatypeChanging(int value);
    partial void OnagendatypeChanged();
    #endregion
	
	public agenda()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_datum", DbType="Date NOT NULL")]
	public System.DateTime datum
	{
		get
		{
			return this._datum;
		}
		set
		{
			if ((this._datum != value))
			{
				this.OndatumChanging(value);
				this.SendPropertyChanging();
				this._datum = value;
				this.SendPropertyChanged("datum");
				this.OndatumChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_adres", DbType="VarChar(255)")]
	public string adres
	{
		get
		{
			return this._adres;
		}
		set
		{
			if ((this._adres != value))
			{
				this.OnadresChanging(value);
				this.SendPropertyChanging();
				this._adres = value;
				this.SendPropertyChanged("adres");
				this.OnadresChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_omschrijving", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
	public string omschrijving
	{
		get
		{
			return this._omschrijving;
		}
		set
		{
			if ((this._omschrijving != value))
			{
				this.OnomschrijvingChanging(value);
				this.SendPropertyChanging();
				this._omschrijving = value;
				this.SendPropertyChanged("omschrijving");
				this.OnomschrijvingChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_openbaar", DbType="Bit")]
	public System.Nullable<bool> openbaar
	{
		get
		{
			return this._openbaar;
		}
		set
		{
			if ((this._openbaar != value))
			{
				this.OnopenbaarChanging(value);
				this.SendPropertyChanging();
				this._openbaar = value;
				this.SendPropertyChanged("openbaar");
				this.OnopenbaarChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_van", DbType="Time")]
	public System.Nullable<System.TimeSpan> van
	{
		get
		{
			return this._van;
		}
		set
		{
			if ((this._van != value))
			{
				this.OnvanChanging(value);
				this.SendPropertyChanging();
				this._van = value;
				this.SendPropertyChanged("van");
				this.OnvanChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tot", DbType="Time")]
	public System.Nullable<System.TimeSpan> tot
	{
		get
		{
			return this._tot;
		}
		set
		{
			if ((this._tot != value))
			{
				this.OntotChanging(value);
				this.SendPropertyChanging();
				this._tot = value;
				this.SendPropertyChanged("tot");
				this.OntotChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_googleAgendaSynchId", DbType="VarChar(255)")]
	public string googleAgendaSynchId
	{
		get
		{
			return this._googleAgendaSynchId;
		}
		set
		{
			if ((this._googleAgendaSynchId != value))
			{
				this.OngoogleAgendaSynchIdChanging(value);
				this.SendPropertyChanging();
				this._googleAgendaSynchId = value;
				this.SendPropertyChanged("googleAgendaSynchId");
				this.OngoogleAgendaSynchIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((this._id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_agendatype", DbType="Int NOT NULL")]
	public int agendatype
	{
		get
		{
			return this._agendatype;
		}
		set
		{
			if ((this._agendatype != value))
			{
				this.OnagendatypeChanging(value);
				this.SendPropertyChanging();
				this._agendatype = value;
				this.SendPropertyChanged("agendatype");
				this.OnagendatypeChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591