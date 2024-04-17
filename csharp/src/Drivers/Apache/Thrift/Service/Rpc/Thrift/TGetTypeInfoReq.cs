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

  public partial class TGetTypeInfoReq : TBase
  {
    private global::Apache.Hive.Service.Rpc.Thrift.TSparkGetDirectResults _getDirectResults;
    private bool _runAsync;
    private global::Apache.Hive.Service.Rpc.Thrift.THandleIdentifier _operationId;
    private global::Apache.Hive.Service.Rpc.Thrift.TDBSqlSessionConf _sessionConf;

    public global::Apache.Hive.Service.Rpc.Thrift.TSessionHandle SessionHandle { get; set; }

    public global::Apache.Hive.Service.Rpc.Thrift.TSparkGetDirectResults GetDirectResults
    {
      get
      {
        return _getDirectResults;
      }
      set
      {
        __isset.getDirectResults = true;
        this._getDirectResults = value;
      }
    }

    public bool RunAsync
    {
      get
      {
        return _runAsync;
      }
      set
      {
        __isset.runAsync = true;
        this._runAsync = value;
      }
    }

    public global::Apache.Hive.Service.Rpc.Thrift.THandleIdentifier OperationId
    {
      get
      {
        return _operationId;
      }
      set
      {
        __isset.operationId = true;
        this._operationId = value;
      }
    }

    public global::Apache.Hive.Service.Rpc.Thrift.TDBSqlSessionConf SessionConf
    {
      get
      {
        return _sessionConf;
      }
      set
      {
        __isset.sessionConf = true;
        this._sessionConf = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool getDirectResults;
      public bool runAsync;
      public bool operationId;
      public bool sessionConf;
    }

    public TGetTypeInfoReq()
    {
    }

    public TGetTypeInfoReq(global::Apache.Hive.Service.Rpc.Thrift.TSessionHandle sessionHandle) : this()
    {
      this.SessionHandle = sessionHandle;
    }

    public TGetTypeInfoReq DeepCopy()
    {
      var tmp420 = new TGetTypeInfoReq();
      if ((SessionHandle != null))
      {
        tmp420.SessionHandle = (global::Apache.Hive.Service.Rpc.Thrift.TSessionHandle)this.SessionHandle.DeepCopy();
      }
      if ((GetDirectResults != null) && __isset.getDirectResults)
      {
        tmp420.GetDirectResults = (global::Apache.Hive.Service.Rpc.Thrift.TSparkGetDirectResults)this.GetDirectResults.DeepCopy();
      }
      tmp420.__isset.getDirectResults = this.__isset.getDirectResults;
      if (__isset.runAsync)
      {
        tmp420.RunAsync = this.RunAsync;
      }
      tmp420.__isset.runAsync = this.__isset.runAsync;
      if ((OperationId != null) && __isset.operationId)
      {
        tmp420.OperationId = (global::Apache.Hive.Service.Rpc.Thrift.THandleIdentifier)this.OperationId.DeepCopy();
      }
      tmp420.__isset.operationId = this.__isset.operationId;
      if ((SessionConf != null) && __isset.sessionConf)
      {
        tmp420.SessionConf = (global::Apache.Hive.Service.Rpc.Thrift.TDBSqlSessionConf)this.SessionConf.DeepCopy();
      }
      tmp420.__isset.sessionConf = this.__isset.sessionConf;
      return tmp420;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_sessionHandle = false;
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
            case 1281:
              if (field.Type == TType.Struct)
              {
                GetDirectResults = new global::Apache.Hive.Service.Rpc.Thrift.TSparkGetDirectResults();
                await GetDirectResults.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 1282:
              if (field.Type == TType.Bool)
              {
                RunAsync = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3329:
              if (field.Type == TType.Struct)
              {
                OperationId = new global::Apache.Hive.Service.Rpc.Thrift.THandleIdentifier();
                await OperationId.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3330:
              if (field.Type == TType.Struct)
              {
                SessionConf = new global::Apache.Hive.Service.Rpc.Thrift.TDBSqlSessionConf();
                await SessionConf.ReadAsync(iprot, cancellationToken);
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
        var tmp421 = new TStruct("TGetTypeInfoReq");
        await oprot.WriteStructBeginAsync(tmp421, cancellationToken);
        var tmp422 = new TField();
        if ((SessionHandle != null))
        {
          tmp422.Name = "sessionHandle";
          tmp422.Type = TType.Struct;
          tmp422.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp422, cancellationToken);
          await SessionHandle.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((GetDirectResults != null) && __isset.getDirectResults)
        {
          tmp422.Name = "getDirectResults";
          tmp422.Type = TType.Struct;
          tmp422.ID = 1281;
          await oprot.WriteFieldBeginAsync(tmp422, cancellationToken);
          await GetDirectResults.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if (__isset.runAsync)
        {
          tmp422.Name = "runAsync";
          tmp422.Type = TType.Bool;
          tmp422.ID = 1282;
          await oprot.WriteFieldBeginAsync(tmp422, cancellationToken);
          await oprot.WriteBoolAsync(RunAsync, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((OperationId != null) && __isset.operationId)
        {
          tmp422.Name = "operationId";
          tmp422.Type = TType.Struct;
          tmp422.ID = 3329;
          await oprot.WriteFieldBeginAsync(tmp422, cancellationToken);
          await OperationId.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((SessionConf != null) && __isset.sessionConf)
        {
          tmp422.Name = "sessionConf";
          tmp422.Type = TType.Struct;
          tmp422.ID = 3330;
          await oprot.WriteFieldBeginAsync(tmp422, cancellationToken);
          await SessionConf.WriteAsync(oprot, cancellationToken);
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
      if (!(that is TGetTypeInfoReq other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return global::System.Object.Equals(SessionHandle, other.SessionHandle)
        && ((__isset.getDirectResults == other.__isset.getDirectResults) && ((!__isset.getDirectResults) || (global::System.Object.Equals(GetDirectResults, other.GetDirectResults))))
        && ((__isset.runAsync == other.__isset.runAsync) && ((!__isset.runAsync) || (global::System.Object.Equals(RunAsync, other.RunAsync))))
        && ((__isset.operationId == other.__isset.operationId) && ((!__isset.operationId) || (global::System.Object.Equals(OperationId, other.OperationId))))
        && ((__isset.sessionConf == other.__isset.sessionConf) && ((!__isset.sessionConf) || (global::System.Object.Equals(SessionConf, other.SessionConf))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if ((SessionHandle != null))
        {
          hashcode = (hashcode * 397) + SessionHandle.GetHashCode();
        }
        if ((GetDirectResults != null) && __isset.getDirectResults)
        {
          hashcode = (hashcode * 397) + GetDirectResults.GetHashCode();
        }
        if (__isset.runAsync)
        {
          hashcode = (hashcode * 397) + RunAsync.GetHashCode();
        }
        if ((OperationId != null) && __isset.operationId)
        {
          hashcode = (hashcode * 397) + OperationId.GetHashCode();
        }
        if ((SessionConf != null) && __isset.sessionConf)
        {
          hashcode = (hashcode * 397) + SessionConf.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp423 = new StringBuilder("TGetTypeInfoReq(");
      if ((SessionHandle != null))
      {
        tmp423.Append(", SessionHandle: ");
        SessionHandle.ToString(tmp423);
      }
      if ((GetDirectResults != null) && __isset.getDirectResults)
      {
        tmp423.Append(", GetDirectResults: ");
        GetDirectResults.ToString(tmp423);
      }
      if (__isset.runAsync)
      {
        tmp423.Append(", RunAsync: ");
        RunAsync.ToString(tmp423);
      }
      if ((OperationId != null) && __isset.operationId)
      {
        tmp423.Append(", OperationId: ");
        OperationId.ToString(tmp423);
      }
      if ((SessionConf != null) && __isset.sessionConf)
      {
        tmp423.Append(", SessionConf: ");
        SessionConf.ToString(tmp423);
      }
      tmp423.Append(')');
      return tmp423.ToString();
    }
  }

}
