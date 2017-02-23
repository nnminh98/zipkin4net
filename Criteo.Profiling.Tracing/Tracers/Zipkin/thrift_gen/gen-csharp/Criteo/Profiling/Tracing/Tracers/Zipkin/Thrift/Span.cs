/**
 * Autogenerated by Thrift Compiler (0.9.3)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Criteo.Profiling.Tracing.Tracers.Zipkin.Thrift
{

  /// <summary>
  /// A trace is a series of spans (often RPC calls) which form a latency tree.
  /// 
  /// Spans are usually created by instrumentation in RPC clients or servers, but
  /// can also represent in-process activity. Annotations in spans are similar to
  /// log statements, and are sometimes created directly by application developers
  /// to indicate events of interest, such as a cache miss.
  /// 
  /// The root span is where parent_id = Nil; it usually has the longest duration
  /// in the trace.
  /// 
  /// Span identifiers are packed into i64s, but should be treated opaquely.
  /// String encoding is fixed-width lower-hex, to avoid signed interpretation.
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Span : TBase
  {
    private bool _debug;

    /// <summary>
    /// Unique 8-byte identifier for a trace, set on all spans within it.
    /// </summary>
    public long? Trace_id { get; set; }

    /// <summary>
    /// Span name in lowercase, rpc method for example. Conventionally, when the
    /// span name isn't known, name = "unknown".
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Unique 8-byte identifier of this span within a trace. A span is uniquely
    /// identified in storage by (trace_id, id).
    /// </summary>
    public long? Id { get; set; }

    /// <summary>
    /// The parent's Span.id; absent if this the root span in a trace.
    /// </summary>
    public long? Parent_id { get; set; }

    /// <summary>
    /// Associates events that explain latency with a timestamp. Unlike log
    /// statements, annotations are often codes: for example SERVER_RECV("sr").
    /// Annotations are sorted ascending by timestamp.
    /// </summary>
    public List<Annotation> Annotations { get; set; }

    /// <summary>
    /// Tags a span with context, usually to support query or aggregation. For
    /// example, a binary annotation key could be "http.path".
    /// </summary>
    public List<BinaryAnnotation> Binary_annotations { get; set; }

    /// <summary>
    /// True is a request to store this span even if it overrides sampling policy.
    /// </summary>
    public bool? Debug
    {
      get
      {
        return _debug;
      }
      set
      {
        __isset.debug = value.HasValue;
        if (value.HasValue) this._debug = value.Value;
      }
    }

    /// <summary>
    /// Epoch microseconds of the start of this span, absent if this an incomplete
    /// span.
    /// 
    /// This value should be set directly by instrumentation, using the most
    /// precise value possible. For example, gettimeofday or syncing nanoTime
    /// against a tick of currentTimeMillis.
    /// 
    /// For compatibilty with instrumentation that precede this field, collectors
    /// or span stores can derive this via Annotation.timestamp.
    /// For example, SERVER_RECV.timestamp or CLIENT_SEND.timestamp.
    /// 
    /// Timestamp is nullable for input only. Spans without a timestamp cannot be
    /// presented in a timeline: Span stores should not output spans missing a
    /// timestamp.
    /// 
    /// There are two known edge-cases where this could be absent: both cases
    /// exist when a collector receives a span in parts and a binary annotation
    /// precedes a timestamp. This is possible when..
    ///  - The span is in-flight (ex not yet received a timestamp)
    ///  - The span's start event was lost
    /// </summary>
    public long? Timestamp { get; set; }

    /// <summary>
    /// Measurement in microseconds of the critical path, if known. Durations of
    /// less than one microsecond must be rounded up to 1 microsecond.
    /// 
    /// This value should be set directly, as opposed to implicitly via annotation
    /// timestamps. Doing so encourages precision decoupled from problems of
    /// clocks, such as skew or NTP updates causing time to move backwards.
    /// 
    /// For compatibility with instrumentation that precede this field, collectors
    /// or span stores can derive this by subtracting Annotation.timestamp.
    /// For example, SERVER_SEND.timestamp - SERVER_RECV.timestamp.
    /// 
    /// If this field is persisted as unset, zipkin will continue to work, except
    /// duration query support will be implementation-specific. Similarly, setting
    /// this field non-atomically is implementation-specific.
    /// 
    /// This field is i64 vs i32 to support spans longer than 35 minutes.
    /// </summary>
    public long? Duration { get; set; }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool debug;
    }

    public Span() {
      this._debug = false;
      this.__isset.debug = true;
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I64) {
                Trace_id = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                Name = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.I64) {
                Id = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.I64) {
                Parent_id = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.List) {
                {
                  Annotations = new List<Annotation>();
                  TList _list0 = iprot.ReadListBegin();
                  for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                  {
                    Annotation _elem2;
                    _elem2 = new Annotation();
                    _elem2.Read(iprot);
                    Annotations.Add(_elem2);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 8:
              if (field.Type == TType.List) {
                {
                  Binary_annotations = new List<BinaryAnnotation>();
                  TList _list3 = iprot.ReadListBegin();
                  for( int _i4 = 0; _i4 < _list3.Count; ++_i4)
                  {
                    BinaryAnnotation _elem5;
                    _elem5 = new BinaryAnnotation();
                    _elem5.Read(iprot);
                    Binary_annotations.Add(_elem5);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 9:
              if (field.Type == TType.Bool) {
                Debug = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 10:
              if (field.Type == TType.I64) {
                Timestamp = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 11:
              if (field.Type == TType.I64) {
                Duration = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("Span");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Trace_id != null) {
          field.Name = "trace_id";
          field.Type = TType.I64;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Trace_id.Value);
          oprot.WriteFieldEnd();
        }
        if (Name != null) {
          field.Name = "name";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Name);
          oprot.WriteFieldEnd();
        }
        if (Id != null) {
          field.Name = "id";
          field.Type = TType.I64;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Id.Value);
          oprot.WriteFieldEnd();
        }
        if (Parent_id != null) {
          field.Name = "parent_id";
          field.Type = TType.I64;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Parent_id.Value);
          oprot.WriteFieldEnd();
        }
        if (Annotations != null) {
          field.Name = "annotations";
          field.Type = TType.List;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Annotations.Count));
            foreach (Annotation _iter6 in Annotations)
            {
              _iter6.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Binary_annotations != null) {
          field.Name = "binary_annotations";
          field.Type = TType.List;
          field.ID = 8;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Binary_annotations.Count));
            foreach (BinaryAnnotation _iter7 in Binary_annotations)
            {
              _iter7.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (__isset.debug) {
          field.Name = "debug";
          field.Type = TType.Bool;
          field.ID = 9;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Debug.Value);
          oprot.WriteFieldEnd();
        }
        if (Timestamp != null) {
          field.Name = "timestamp";
          field.Type = TType.I64;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Timestamp.Value);
          oprot.WriteFieldEnd();
        }
        if (Duration != null) {
          field.Name = "duration";
          field.Type = TType.I64;
          field.ID = 11;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Duration.Value);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override bool Equals(object that) {
      var other = that as Span;
      if (other == null) return false;
      if (ReferenceEquals(this, other)) return true;
      return System.Object.Equals(Trace_id, other.Trace_id)
        && System.Object.Equals(Name, other.Name)
        && System.Object.Equals(Id, other.Id)
        && System.Object.Equals(Parent_id, other.Parent_id)
        && TCollections.Equals(Annotations, other.Annotations)
        && TCollections.Equals(Binary_annotations, other.Binary_annotations)
        && ((__isset.debug == other.__isset.debug) && ((!__isset.debug) || (System.Object.Equals(Debug, other.Debug))))
        && System.Object.Equals(Timestamp, other.Timestamp)
        && System.Object.Equals(Duration, other.Duration);
    }

    public override int GetHashCode() {
      int hashcode = 0;
      unchecked {
        hashcode = (hashcode * 397) ^ (Trace_id == null ? 0 : (Trace_id.GetHashCode()));
        hashcode = (hashcode * 397) ^ (Name == null ? 0 : (Name.GetHashCode()));
        hashcode = (hashcode * 397) ^ (Id == null ? 0 : (Id.GetHashCode()));
        hashcode = (hashcode * 397) ^ (Parent_id == null ? 0 : (Parent_id.GetHashCode()));
        hashcode = (hashcode * 397) ^ (Annotations == null ? 0 : (TCollections.GetHashCode(Annotations)));
        hashcode = (hashcode * 397) ^ (Binary_annotations == null ? 0 : (TCollections.GetHashCode(Binary_annotations)));
        hashcode = (hashcode * 397) ^ (Debug == null ? 0 : (Debug.GetHashCode()));
        hashcode = (hashcode * 397) ^ (Timestamp == null ? 0 : (Timestamp.GetHashCode()));
        hashcode = (hashcode * 397) ^ (Duration == null ? 0 : (Duration.GetHashCode()));
      }
      return hashcode;
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Span(");
      bool __first = true;
      if (Trace_id != null) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Trace_id: ");
        __sb.Append(Trace_id);
      }
      if (Name != null) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Name: ");
        __sb.Append(Name);
      }
      if (Id != null) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Id: ");
        __sb.Append(Id);
      }
      if (Parent_id != null) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Parent_id: ");
        __sb.Append(Parent_id);
      }
      if (Annotations != null) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Annotations: ");
        __sb.Append(Annotations);
      }
      if (Binary_annotations != null) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Binary_annotations: ");
        __sb.Append(Binary_annotations);
      }
      if (__isset.debug) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Debug: ");
        __sb.Append(Debug);
      }
      if (Timestamp != null) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Timestamp: ");
        __sb.Append(Timestamp);
      }
      if (Duration != null) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Duration: ");
        __sb.Append(Duration);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
