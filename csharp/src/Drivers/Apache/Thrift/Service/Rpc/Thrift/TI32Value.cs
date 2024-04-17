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

  public partial class TI32Value : TBase
  {
    private int _value;

    public int Value
    {
      get
      {
        return _value;
      }
      set
      {
        __isset.@value = true;
        this._value = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool @value;
    }

    public TI32Value()
    {
    }

    public TI32Value DeepCopy()
    {
      var tmp98 = new TI32Value();
      if (__isset.@value)
      {
        tmp98.Value = this.Value;
      }
      tmp98.__isset.@value = this.__isset.@value;
      return tmp98;
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
                Value = await iprot.ReadI32Async(cancellationToken);
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
        var tmp99 = new TStruct("TI32Value");
        await oprot.WriteStructBeginAsync(tmp99, cancellationToken);
        var tmp100 = new TField();
        if (__isset.@value)
        {
          tmp100.Name = "value";
          tmp100.Type = TType.I32;
          tmp100.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp100, cancellationToken);
          await oprot.WriteI32Async(Value, cancellationToken);
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
      if (!(that is TI32Value other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.@value == other.__isset.@value) && ((!__isset.@value) || (global::System.Object.Equals(Value, other.Value))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if (__isset.@value)
        {
          hashcode = (hashcode * 397) + Value.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp101 = new StringBuilder("TI32Value(");
      int tmp102 = 0;
      if (__isset.@value)
      {
        if (0 < tmp102++) { tmp101.Append(", "); }
        tmp101.Append("Value: ");
        Value.ToString(tmp101);
      }
      tmp101.Append(')');
      return tmp101.ToString();
    }
  }

}
