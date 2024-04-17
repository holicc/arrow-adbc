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

  public partial class TGetInfoReq : TBase
  {

    public global::Apache.Hive.Service.Rpc.Thrift.TSessionHandle SessionHandle { get; set; }

    /// <summary>
    ///
    /// <seealso cref="global::Apache.Hive.Service.Rpc.Thrift.TGetInfoType"/>
    /// </summary>
    public global::Apache.Hive.Service.Rpc.Thrift.TGetInfoType InfoType { get; set; }

    public TGetInfoReq()
    {
    }

    public TGetInfoReq(global::Apache.Hive.Service.Rpc.Thrift.TSessionHandle sessionHandle, global::Apache.Hive.Service.Rpc.Thrift.TGetInfoType infoType) : this()
    {
      this.SessionHandle = sessionHandle;
      this.InfoType = infoType;
    }

    public TGetInfoReq DeepCopy()
    {
      var tmp347 = new TGetInfoReq();
      if ((SessionHandle != null))
      {
        tmp347.SessionHandle = (global::Apache.Hive.Service.Rpc.Thrift.TSessionHandle)this.SessionHandle.DeepCopy();
      }
      tmp347.InfoType = this.InfoType;
      return tmp347;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_sessionHandle = false;
        bool isset_infoType = false;
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
                SessionHandle = new global::Apache.Hive.Service.Rpc.Thrift.TSessionHandle();
                await SessionHandle.ReadAsync(iprot, cancellationToken);
                isset_sessionHandle = true;
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.I32)
              {
                InfoType = (global::Apache.Hive.Service.Rpc.Thrift.TGetInfoType)await iprot.ReadI32Async(cancellationToken);
                isset_infoType = true;
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
        if (!isset_sessionHandle)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
        if (!isset_infoType)
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
        var tmp348 = new TStruct("TGetInfoReq");
        await oprot.WriteStructBeginAsync(tmp348, cancellationToken);
        var tmp349 = new TField();
        if ((SessionHandle != null))
        {
          tmp349.Name = "sessionHandle";
          tmp349.Type = TType.Struct;
          tmp349.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp349, cancellationToken);
          await SessionHandle.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        tmp349.Name = "infoType";
        tmp349.Type = TType.I32;
        tmp349.ID = 2;
        await oprot.WriteFieldBeginAsync(tmp349, cancellationToken);
        await oprot.WriteI32Async((int)InfoType, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
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
      if (!(that is TGetInfoReq other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(SessionHandle, other.SessionHandle)
        && global::System.Object.Equals(InfoType, other.InfoType);
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if ((SessionHandle != null))
        {
          hashcode = (hashcode * 397) + SessionHandle.GetHashCode();
        }
        hashcode = (hashcode * 397) + InfoType.GetHashCode();
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp350 = new StringBuilder("TGetInfoReq(");
      if ((SessionHandle != null))
      {
        tmp350.Append(", SessionHandle: ");
        SessionHandle.ToString(tmp350);
      }
      tmp350.Append(", InfoType: ");
      InfoType.ToString(tmp350);
      tmp350.Append(')');
      return tmp350.ToString();
    }
  }

}
