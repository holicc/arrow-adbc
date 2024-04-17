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

  public partial class TRenewDelegationTokenReq : TBase
  {

    public global::Apache.Hive.Service.Rpc.Thrift.TSessionHandle SessionHandle { get; set; }

    public string DelegationToken { get; set; }

    public TRenewDelegationTokenReq()
    {
    }

    public TRenewDelegationTokenReq(global::Apache.Hive.Service.Rpc.Thrift.TSessionHandle sessionHandle, string delegationToken) : this()
    {
      this.SessionHandle = sessionHandle;
      this.DelegationToken = delegationToken;
    }

    public TRenewDelegationTokenReq DeepCopy()
    {
      var tmp618 = new TRenewDelegationTokenReq();
      if ((SessionHandle != null))
      {
        tmp618.SessionHandle = (global::Apache.Hive.Service.Rpc.Thrift.TSessionHandle)this.SessionHandle.DeepCopy();
      }
      if ((DelegationToken != null))
      {
        tmp618.DelegationToken = this.DelegationToken;
      }
      return tmp618;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_sessionHandle = false;
        bool isset_delegationToken = false;
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
              if (field.Type == TType.String)
              {
                DelegationToken = await iprot.ReadStringAsync(cancellationToken);
                isset_delegationToken = true;
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
        if (!isset_delegationToken)
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
        var tmp619 = new TStruct("TRenewDelegationTokenReq");
        await oprot.WriteStructBeginAsync(tmp619, cancellationToken);
        var tmp620 = new TField();
        if ((SessionHandle != null))
        {
          tmp620.Name = "sessionHandle";
          tmp620.Type = TType.Struct;
          tmp620.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp620, cancellationToken);
          await SessionHandle.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((DelegationToken != null))
        {
          tmp620.Name = "delegationToken";
          tmp620.Type = TType.String;
          tmp620.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp620, cancellationToken);
          await oprot.WriteStringAsync(DelegationToken, cancellationToken);
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
      if (!(that is TRenewDelegationTokenReq other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(SessionHandle, other.SessionHandle)
        && global::System.Object.Equals(DelegationToken, other.DelegationToken);
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if ((SessionHandle != null))
        {
          hashcode = (hashcode * 397) + SessionHandle.GetHashCode();
        }
        if ((DelegationToken != null))
        {
          hashcode = (hashcode * 397) + DelegationToken.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp621 = new StringBuilder("TRenewDelegationTokenReq(");
      if ((SessionHandle != null))
      {
        tmp621.Append(", SessionHandle: ");
        SessionHandle.ToString(tmp621);
      }
      if ((DelegationToken != null))
      {
        tmp621.Append(", DelegationToken: ");
        DelegationToken.ToString(tmp621);
      }
      tmp621.Append(')');
      return tmp621.ToString();
    }
  }

}
