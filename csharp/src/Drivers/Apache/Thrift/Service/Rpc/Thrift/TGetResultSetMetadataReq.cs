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

  public partial class TGetResultSetMetadataReq : TBase
  {
    private bool _includeCloudResultFiles;

    public global::Apache.Hive.Service.Rpc.Thrift.TOperationHandle OperationHandle { get; set; }

    public bool IncludeCloudResultFiles
    {
      get
      {
        return _includeCloudResultFiles;
      }
      set
      {
        __isset.includeCloudResultFiles = true;
        this._includeCloudResultFiles = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool includeCloudResultFiles;
    }

    public TGetResultSetMetadataReq()
    {
    }

    public TGetResultSetMetadataReq(global::Apache.Hive.Service.Rpc.Thrift.TOperationHandle operationHandle) : this()
    {
      this.OperationHandle = operationHandle;
    }

    public TGetResultSetMetadataReq DeepCopy()
    {
      var tmp569 = new TGetResultSetMetadataReq();
      if ((OperationHandle != null))
      {
        tmp569.OperationHandle = (global::Apache.Hive.Service.Rpc.Thrift.TOperationHandle)this.OperationHandle.DeepCopy();
      }
      if (__isset.includeCloudResultFiles)
      {
        tmp569.IncludeCloudResultFiles = this.IncludeCloudResultFiles;
      }
      tmp569.__isset.includeCloudResultFiles = this.__isset.includeCloudResultFiles;
      return tmp569;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_operationHandle = false;
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
              if (field.Type == TType.Struct)
              {
                OperationHandle = new global::Apache.Hive.Service.Rpc.Thrift.TOperationHandle();
                await OperationHandle.ReadAsync(iprot, cancellationToken);
                isset_operationHandle = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3329:
              if (field.Type == TType.Bool)
              {
                IncludeCloudResultFiles = await iprot.ReadBoolAsync(cancellationToken);
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
        if (!isset_operationHandle)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
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
        var tmp570 = new TStruct("TGetResultSetMetadataReq");
        await oprot.WriteStructBeginAsync(tmp570, cancellationToken);
        var tmp571 = new TField();
        if ((OperationHandle != null))
        {
          tmp571.Name = "operationHandle";
          tmp571.Type = TType.Struct;
          tmp571.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp571, cancellationToken);
          await OperationHandle.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (__isset.includeCloudResultFiles)
        {
          tmp571.Name = "includeCloudResultFiles";
          tmp571.Type = TType.Bool;
          tmp571.ID = 3329;
          await oprot.WriteFieldBeginAsync(tmp571, cancellationToken);
          await oprot.WriteBoolAsync(IncludeCloudResultFiles, cancellationToken);
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
      if (!(that is TGetResultSetMetadataReq other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(OperationHandle, other.OperationHandle)
        && ((__isset.includeCloudResultFiles == other.__isset.includeCloudResultFiles) && ((!__isset.includeCloudResultFiles) || (global::System.Object.Equals(IncludeCloudResultFiles, other.IncludeCloudResultFiles))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if ((OperationHandle != null))
        {
          hashcode = (hashcode * 397) + OperationHandle.GetHashCode();
        }
        if (__isset.includeCloudResultFiles)
        {
          hashcode = (hashcode * 397) + IncludeCloudResultFiles.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp572 = new StringBuilder("TGetResultSetMetadataReq(");
      if ((OperationHandle != null))
      {
        tmp572.Append(", OperationHandle: ");
        OperationHandle.ToString(tmp572);
      }
      if (__isset.includeCloudResultFiles)
      {
        tmp572.Append(", IncludeCloudResultFiles: ");
        IncludeCloudResultFiles.ToString(tmp572);
      }
      tmp572.Append(')');
      return tmp572.ToString();
    }
  }

}
