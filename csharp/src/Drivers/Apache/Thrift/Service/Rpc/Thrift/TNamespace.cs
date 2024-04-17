/**
 * <auto-generated>
 * Autogenerated by Thrift Compiler (0.17.0)
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 * </auto-generated>
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE0017  // object init can be simplified
#pragma warning disable IDE0028  // collection init can be simplified
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable CA1822   // empty DeepCopy() methods still non-static
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

namespace Apache.Hive.Service.Rpc.Thrift
{

  public partial class TNamespace : TBase
  {
    private string _catalogName;
    private string _schemaName;

    public string CatalogName
    {
      get
      {
        return _catalogName;
      }
      set
      {
        __isset.catalogName = true;
        this._catalogName = value;
      }
    }

    public string SchemaName
    {
      get
      {
        return _schemaName;
      }
      set
      {
        __isset.schemaName = true;
        this._schemaName = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool catalogName;
      public bool schemaName;
    }

    public TNamespace()
    {
    }

    public TNamespace DeepCopy()
    {
      var tmp298 = new TNamespace();
      if ((CatalogName != null) && __isset.catalogName)
      {
        tmp298.CatalogName = this.CatalogName;
      }
      tmp298.__isset.catalogName = this.__isset.catalogName;
      if ((SchemaName != null) && __isset.schemaName)
      {
        tmp298.SchemaName = this.SchemaName;
      }
      tmp298.__isset.schemaName = this.__isset.schemaName;
      return tmp298;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String)
              {
                CatalogName = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                SchemaName = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default:
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var tmp299 = new TStruct("TNamespace");
        await oprot.WriteStructBeginAsync(tmp299, cancellationToken);
        var tmp300 = new TField();
        if ((CatalogName != null) && __isset.catalogName)
        {
          tmp300.Name = "catalogName";
          tmp300.Type = TType.String;
          tmp300.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp300, cancellationToken);
          await oprot.WriteStringAsync(CatalogName, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((SchemaName != null) && __isset.schemaName)
        {
          tmp300.Name = "schemaName";
          tmp300.Type = TType.String;
          tmp300.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp300, cancellationToken);
          await oprot.WriteStringAsync(SchemaName, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override bool Equals(object that)
    {
      if (!(that is TNamespace other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.catalogName == other.__isset.catalogName) && ((!__isset.catalogName) || (global::System.Object.Equals(CatalogName, other.CatalogName))))
        && ((__isset.schemaName == other.__isset.schemaName) && ((!__isset.schemaName) || (global::System.Object.Equals(SchemaName, other.SchemaName))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if ((CatalogName != null) && __isset.catalogName)
        {
          hashcode = (hashcode * 397) + CatalogName.GetHashCode();
        }
        if ((SchemaName != null) && __isset.schemaName)
        {
          hashcode = (hashcode * 397) + SchemaName.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp301 = new StringBuilder("TNamespace(");
      int tmp302 = 0;
      if ((CatalogName != null) && __isset.catalogName)
      {
        if (0 < tmp302++) { tmp301.Append(", "); }
        tmp301.Append("CatalogName: ");
        CatalogName.ToString(tmp301);
      }
      if ((SchemaName != null) && __isset.schemaName)
      {
        if (0 < tmp302++) { tmp301.Append(", "); }
        tmp301.Append("SchemaName: ");
        SchemaName.ToString(tmp301);
      }
      tmp301.Append(')');
      return tmp301.ToString();
    }
  }

}
