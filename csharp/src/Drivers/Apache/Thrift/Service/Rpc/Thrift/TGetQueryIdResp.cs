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

  public partial class TGetQueryIdResp : TBase
  {

    public string QueryId { get; set; }

    public TGetQueryIdResp()
    {
    }

    public TGetQueryIdResp(string queryId) : this()
    {
      this.QueryId = queryId;
    }

    public TGetQueryIdResp DeepCopy()
    {
      var tmp650 = new TGetQueryIdResp();
      if ((QueryId != null))
      {
        tmp650.QueryId = this.QueryId;
      }
      return tmp650;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_queryId = false;
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
                QueryId = await iprot.ReadStringAsync(cancellationToken);
                isset_queryId = true;
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
        if (!isset_queryId)
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
        var tmp651 = new TStruct("TGetQueryIdResp");
        await oprot.WriteStructBeginAsync(tmp651, cancellationToken);
        var tmp652 = new TField();
        if ((QueryId != null))
        {
          tmp652.Name = "queryId";
          tmp652.Type = TType.String;
          tmp652.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp652, cancellationToken);
          await oprot.WriteStringAsync(QueryId, cancellationToken);
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
      if (!(that is TGetQueryIdResp other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(QueryId, other.QueryId);
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if ((QueryId != null))
        {
          hashcode = (hashcode * 397) + QueryId.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp653 = new StringBuilder("TGetQueryIdResp(");
      if ((QueryId != null))
      {
        tmp653.Append(", QueryId: ");
        QueryId.ToString(tmp653);
      }
      tmp653.Append(')');
      return tmp653.ToString();
    }
  }

}
