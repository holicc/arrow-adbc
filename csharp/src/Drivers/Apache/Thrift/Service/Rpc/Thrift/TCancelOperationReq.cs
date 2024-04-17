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

  public partial class TCancelOperationReq : TBase
  {

    public global::Apache.Hive.Service.Rpc.Thrift.TOperationHandle OperationHandle { get; set; }

    public TCancelOperationReq()
    {
    }

    public TCancelOperationReq(global::Apache.Hive.Service.Rpc.Thrift.TOperationHandle operationHandle) : this()
    {
      this.OperationHandle = operationHandle;
    }

    public TCancelOperationReq DeepCopy()
    {
      var tmp549 = new TCancelOperationReq();
      if ((OperationHandle != null))
      {
        tmp549.OperationHandle = (global::Apache.Hive.Service.Rpc.Thrift.TOperationHandle)this.OperationHandle.DeepCopy();
      }
      return tmp549;
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
        var tmp550 = new TStruct("TCancelOperationReq");
        await oprot.WriteStructBeginAsync(tmp550, cancellationToken);
        var tmp551 = new TField();
        if ((OperationHandle != null))
        {
          tmp551.Name = "operationHandle";
          tmp551.Type = TType.Struct;
          tmp551.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp551, cancellationToken);
          await OperationHandle.WriteAsync(oprot, cancellationToken);
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
      if (!(that is TCancelOperationReq other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(OperationHandle, other.OperationHandle);
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if ((OperationHandle != null))
        {
          hashcode = (hashcode * 397) + OperationHandle.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp552 = new StringBuilder("TCancelOperationReq(");
      if ((OperationHandle != null))
      {
        tmp552.Append(", OperationHandle: ");
        OperationHandle.ToString(tmp552);
      }
      tmp552.Append(')');
      return tmp552.ToString();
    }
  }

}
