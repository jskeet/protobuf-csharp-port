// Generated by the protocol buffer compiler.  DO NOT EDIT!

using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;
using pbd = global::Google.ProtocolBuffers.Descriptors;
using scg = global::System.Collections.Generic;
using self = global::Google.ProtocolBuffers.TestProtos;

namespace Google.ProtocolBuffers.TestProtos {
  
  public static partial class MultiFileProto {
  
    #region Descriptor
    public static pbd::FileDescriptor Descriptor {
        get { return descriptor; }
    }
    private static readonly pbd::FileDescriptor descriptor = pbd::FileDescriptor.InternalBuildGeneratedFileFrom (
        new byte[] {
            0x0a, 0x3b, 0x73, 0x72, 0x63, 0x2f, 0x74, 0x65, 0x73, 0x74, 0x2f, 0x6a, 0x61, 0x76, 0x61, 0x2f, 0x63, 0x6f, 0x6d, 0x2f, 
            0x67, 0x6f, 0x6f, 0x67, 0x6c, 0x65, 0x2f, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 0x2f, 0x6d, 0x75, 0x6c, 0x74, 
            0x69, 0x70, 0x6c, 0x65, 0x5f, 0x66, 0x69, 0x6c, 0x65, 0x73, 0x5f, 0x74, 0x65, 0x73, 0x74, 0x2e, 0x70, 0x72, 0x6f, 0x74, 
            0x6f, 0x12, 0x11, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 0x5f, 0x75, 0x6e, 0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 
            0x1a, 0x1e, 0x67, 0x6f, 0x6f, 0x67, 0x6c, 0x65, 0x2f, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 0x2f, 0x75, 0x6e, 
            0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x22, 0xbf, 0x02, 0x0a, 0x12, 0x4d, 0x65, 0x73, 
            0x73, 0x61, 0x67, 0x65, 0x57, 0x69, 0x74, 0x68, 0x4e, 0x6f, 0x4f, 0x75, 0x74, 0x65, 0x72, 0x12, 0x43, 0x0a, 0x06, 0x6e, 
            0x65, 0x73, 0x74, 0x65, 0x64, 0x18, 0x01, 0x20, 0x01, 0x28, 0x0b, 0x32, 0x33, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x62, 
            0x75, 0x66, 0x5f, 0x75, 0x6e, 0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 0x2e, 0x4d, 0x65, 0x73, 0x73, 0x61, 0x67, 0x65, 0x57, 
            0x69, 0x74, 0x68, 0x4e, 0x6f, 0x4f, 0x75, 0x74, 0x65, 0x72, 0x2e, 0x4e, 0x65, 0x73, 0x74, 0x65, 0x64, 0x4d, 0x65, 0x73, 
            0x73, 0x61, 0x67, 0x65, 0x12, 0x30, 0x0a, 0x07, 0x66, 0x6f, 0x72, 0x65, 0x69, 0x67, 0x6e, 0x18, 0x02, 0x20, 0x03, 0x28, 
            0x0b, 0x32, 0x1f, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 0x5f, 0x75, 0x6e, 0x69, 0x74, 0x74, 0x65, 0x73, 
            0x74, 0x2e, 0x54, 0x65, 0x73, 0x74, 0x41, 0x6c, 0x6c, 0x54, 0x79, 0x70, 0x65, 0x73, 0x12, 0x45, 0x0a, 0x0b, 0x6e, 0x65, 
            0x73, 0x74, 0x65, 0x64, 0x5f, 0x65, 0x6e, 0x75, 0x6d, 0x18, 0x03, 0x20, 0x01, 0x28, 0x0e, 0x32, 0x30, 0x2e, 0x70, 0x72, 
            0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 0x5f, 0x75, 0x6e, 0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 0x2e, 0x4d, 0x65, 0x73, 0x73, 
            0x61, 0x67, 0x65, 0x57, 0x69, 0x74, 0x68, 0x4e, 0x6f, 0x4f, 0x75, 0x74, 0x65, 0x72, 0x2e, 0x4e, 0x65, 0x73, 0x74, 0x65, 
            0x64, 0x45, 0x6e, 0x75, 0x6d, 0x12, 0x38, 0x0a, 0x0c, 0x66, 0x6f, 0x72, 0x65, 0x69, 0x67, 0x6e, 0x5f, 0x65, 0x6e, 0x75, 
            0x6d, 0x18, 0x04, 0x20, 0x01, 0x28, 0x0e, 0x32, 0x22, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 0x5f, 0x75, 
            0x6e, 0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 0x2e, 0x45, 0x6e, 0x75, 0x6d, 0x57, 0x69, 0x74, 0x68, 0x4e, 0x6f, 0x4f, 0x75, 
            0x74, 0x65, 0x72, 0x1a, 0x1a, 0x0a, 0x0d, 0x4e, 0x65, 0x73, 0x74, 0x65, 0x64, 0x4d, 0x65, 0x73, 0x73, 0x61, 0x67, 0x65, 
            0x12, 0x09, 0x0a, 0x01, 0x69, 0x18, 0x01, 0x20, 0x01, 0x28, 0x05, 0x22, 0x15, 0x0a, 0x0a, 0x4e, 0x65, 0x73, 0x74, 0x65, 
            0x64, 0x45, 0x6e, 0x75, 0x6d, 0x12, 0x07, 0x0a, 0x03, 0x42, 0x41, 0x5a, 0x10, 0x03, 0x2a, 0x23, 0x0a, 0x0f, 0x45, 0x6e, 
            0x75, 0x6d, 0x57, 0x69, 0x74, 0x68, 0x4e, 0x6f, 0x4f, 0x75, 0x74, 0x65, 0x72, 0x12, 0x07, 0x0a, 0x03, 0x46, 0x4f, 0x4f, 
            0x10, 0x01, 0x12, 0x07, 0x0a, 0x03, 0x42, 0x41, 0x52, 0x10, 0x02, 0x32, 0x63, 0x0a, 0x12, 0x53, 0x65, 0x72, 0x76, 0x69, 
            0x63, 0x65, 0x57, 0x69, 0x74, 0x68, 0x4e, 0x6f, 0x4f, 0x75, 0x74, 0x65, 0x72, 0x12, 0x4d, 0x0a, 0x03, 0x46, 0x6f, 0x6f, 
            0x12, 0x25, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 0x5f, 0x75, 0x6e, 0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 
            0x2e, 0x4d, 0x65, 0x73, 0x73, 0x61, 0x67, 0x65, 0x57, 0x69, 0x74, 0x68, 0x4e, 0x6f, 0x4f, 0x75, 0x74, 0x65, 0x72, 0x1a, 
            0x1f, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 0x5f, 0x75, 0x6e, 0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 0x2e, 
            0x54, 0x65, 0x73, 0x74, 0x41, 0x6c, 0x6c, 0x54, 0x79, 0x70, 0x65, 0x73, 0x3a, 0x44, 0x0a, 0x14, 0x65, 0x78, 0x74, 0x65, 
            0x6e, 0x73, 0x69, 0x6f, 0x6e, 0x5f, 0x77, 0x69, 0x74, 0x68, 0x5f, 0x6f, 0x75, 0x74, 0x65, 0x72, 0x12, 0x24, 0x2e, 0x70, 
            0x72, 0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 0x5f, 0x75, 0x6e, 0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 0x2e, 0x54, 0x65, 0x73, 
            0x74, 0x41, 0x6c, 0x6c, 0x45, 0x78, 0x74, 0x65, 0x6e, 0x73, 0x69, 0x6f, 0x6e, 0x73, 0x18, 0x87, 0xad, 0x4b, 0x20, 0x01, 
            0x28, 0x05, 0x42, 0x58, 0x42, 0x16, 0x4d, 0x75, 0x6c, 0x74, 0x69, 0x70, 0x6c, 0x65, 0x46, 0x69, 0x6c, 0x65, 0x73, 0x54, 
            0x65, 0x73, 0x74, 0x50, 0x72, 0x6f, 0x74, 0x6f, 0x50, 0x01, 0xc2, 0x3e, 0x21, 0x47, 0x6f, 0x6f, 0x67, 0x6c, 0x65, 0x2e, 
            0x50, 0x72, 0x6f, 0x74, 0x6f, 0x63, 0x6f, 0x6c, 0x42, 0x75, 0x66, 0x66, 0x65, 0x72, 0x73, 0x2e, 0x54, 0x65, 0x73, 0x74, 
            0x50, 0x72, 0x6f, 0x74, 0x6f, 0x73, 0xca, 0x3e, 0x0e, 0x4d, 0x75, 0x6c, 0x74, 0x69, 0x46, 0x69, 0x6c, 0x65, 0x50, 0x72, 
            0x6f, 0x74, 0x6f, 0xd0, 0x3e, 0x01, 0xd8, 0x3e, 0x00, 0xe0, 0x3e, 0x01, 
        }, new pbd::FileDescriptor[] {
                self::UnitTestProtoFile.Descriptor,
        });
    #endregion
    
    #region Extensions
    public static readonly pb::GeneratedExtensionBase<self::TestAllExtensions, int> ExtensionWithOuter =
          pb::GeneratedSingleExtension<self::TestAllExtensions, int>.CreateInstance(Descriptor.Extensions[0]);
    #endregion
    
    #region Static variables
    internal static readonly pbd::MessageDescriptor internal__static_protobuf_unittest_MessageWithNoOuter__Descriptor 
        = Descriptor.MessageTypes[0];
    internal static pb::FieldAccess.FieldAccessorTable internal__static_protobuf_unittest_MessageWithNoOuter__FieldAccessorTable
        = new pb::FieldAccess.FieldAccessorTable(internal__static_protobuf_unittest_MessageWithNoOuter__Descriptor,
            new string[] { "Nested", "Foreign", "NestedEnum", "ForeignEnum", },
            typeof (self::MessageWithNoOuter),
            typeof (self::MessageWithNoOuter.Builder));
    internal static readonly pbd::MessageDescriptor  internal__static_protobuf_unittest_MessageWithNoOuter_NestedMessage__Descriptor 
        = internal__static_protobuf_unittest_MessageWithNoOuter__Descriptor.NestedTypes[0];
    internal static pb::FieldAccess.FieldAccessorTable internal__static_protobuf_unittest_MessageWithNoOuter_NestedMessage__FieldAccessorTable
        = new pb::FieldAccess.FieldAccessorTable(internal__static_protobuf_unittest_MessageWithNoOuter_NestedMessage__Descriptor,
            new string[] { "I", },
            typeof (self::MessageWithNoOuter.Types.NestedMessage),
            typeof (self::MessageWithNoOuter.Types.NestedMessage.Builder));
    #endregion
    
  }
  
}