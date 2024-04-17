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

  public partial class TTypeQualifierValue : TBase
  {
    private int _i32Value;
    private string _stringValue;

    public int I32Value
    {
      get
      {
        return _i32Value;
      }
      set
      {
        __isset.i32Value = true;
        this._i32Value = value;
      }
    }

    public string StringValue
    {
      get
      {
        return _stringValue;
      }
      set
      {
        __isset.stringValue = true;
        this._stringValue = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool i32Value;
      public bool stringValue;
    }

    public TTypeQualifierValue()
    {
    }

    public TTypeQualifierValue DeepCopy()
    {
      var tmp0 = new TTypeQualifierValue();
      if (__isset.i32Value)
      {
        tmp0.I32Value = this.I32Value;
      }
      tmp0.__isset.i32Value = this.__isset.i32Value;
      if ((StringValue != null) && __isset.stringValue)
      {
        tmp0.StringValue = this.StringValue;
      }
      tmp0.__isset.stringValue = this.__isset.stringValue;
      return tmp0;
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
              if (field.Type == TType.I32)
              {
                I32Value = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                StringValue = await iprot.ReadStringAsync(cancellationToken);
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
        var tmp1 = new TStruct("TTypeQualifierValue");
        await oprot.WriteStructBeginAsync(tmp1, cancellationToken);
        var tmp2 = new TField();
        if (__isset.i32Value)
        {
          tmp2.Name = "i32Value";
          tmp2.Type = TType.I32;
          tmp2.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp2, cancellationToken);
          await oprot.WriteI32Async(I32Value, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((StringValue != null) && __isset.stringValue)
        {
          tmp2.Name = "stringValue";
          tmp2.Type = TType.String;
          tmp2.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp2, cancellationToken);
          await oprot.WriteStringAsync(StringValue, cancellationToken);
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
      if (!(that is TTypeQualifierValue other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.i32Value == other.__isset.i32Value) && ((!__isset.i32Value) || (global::System.Object.Equals(I32Value, other.I32Value))))
        && ((__isset.stringValue == other.__isset.stringValue) && ((!__isset.stringValue) || (global::System.Object.Equals(StringValue, other.StringValue))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if (__isset.i32Value)
        {
          hashcode = (hashcode * 397) + I32Value.GetHashCode();
        }
        if ((StringValue != null) && __isset.stringValue)
        {
          hashcode = (hashcode * 397) + StringValue.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp3 = new StringBuilder("TTypeQualifierValue(");
      int tmp4 = 0;
      if (__isset.i32Value)
      {
        if (0 < tmp4++) { tmp3.Append(", "); }
        tmp3.Append("I32Value: ");
        I32Value.ToString(tmp3);
      }
      if ((StringValue != null) && __isset.stringValue)
      {
        if (0 < tmp4++) { tmp3.Append(", "); }
        tmp3.Append("StringValue: ");
        StringValue.ToString(tmp3);
      }
      tmp3.Append(')');
      return tmp3.ToString();
    }
  }

}
