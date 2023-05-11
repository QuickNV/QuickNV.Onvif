﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//
//     对此文件的更改可能导致不正确的行为，并在以下条件下丢失:
//     代码重新生成。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quick.Onvif.Provisioning
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", ConfigurationName="Quick.Onvif.Provisioning.ProvisioningService")]
    public interface ProvisioningService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/provisioning/wsdl/GetServiceCapabilities", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="Capabilities")]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.Capabilities> GetServiceCapabilitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/provisioning/wsdl/PanMove", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.PanMoveResponse> PanMoveAsync(Quick.Onvif.Provisioning.PanMoveRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/provisioning/wsdl/TiltMove", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.TiltMoveResponse> TiltMoveAsync(Quick.Onvif.Provisioning.TiltMoveRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/provisioning/wsdl/ZoomMove", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.ZoomMoveResponse> ZoomMoveAsync(Quick.Onvif.Provisioning.ZoomMoveRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/provisioning/wsdl/RollMove", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.RollMoveResponse> RollMoveAsync(Quick.Onvif.Provisioning.RollMoveRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/provisioning/wsdl/FocusMove", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.FocusMoveResponse> FocusMoveAsync(Quick.Onvif.Provisioning.FocusMoveRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/provisioning/wsdl/Stop", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task StopAsync(string VideoSource);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.onvif.org/ver10/provisioning/wsdl/Usage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="Usage")]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.Usage> GetUsageAsync(string VideoSource);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl")]
    public partial class Capabilities
    {
        
        private string defaultTimeoutField;
        
        private SourceCapabilities[] sourceField;
        
        private System.Xml.XmlElement[] anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="duration", Order=0)]
        public string DefaultTimeout
        {
            get
            {
                return this.defaultTimeoutField;
            }
            set
            {
                this.defaultTimeoutField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Source", Order=1)]
        public SourceCapabilities[] Source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=2)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl")]
    public partial class SourceCapabilities
    {
        
        private System.Xml.XmlElement[] anyField;
        
        private string videoSourceTokenField;
        
        private string maximumPanMovesField;
        
        private string maximumTiltMovesField;
        
        private string maximumZoomMovesField;
        
        private string maximumRollMovesField;
        
        private bool autoLevelField;
        
        private bool autoLevelFieldSpecified;
        
        private string maximumFocusMovesField;
        
        private bool autoFocusField;
        
        private bool autoFocusFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=0)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string VideoSourceToken
        {
            get
            {
                return this.videoSourceTokenField;
            }
            set
            {
                this.videoSourceTokenField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="positiveInteger")]
        public string MaximumPanMoves
        {
            get
            {
                return this.maximumPanMovesField;
            }
            set
            {
                this.maximumPanMovesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="positiveInteger")]
        public string MaximumTiltMoves
        {
            get
            {
                return this.maximumTiltMovesField;
            }
            set
            {
                this.maximumTiltMovesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="positiveInteger")]
        public string MaximumZoomMoves
        {
            get
            {
                return this.maximumZoomMovesField;
            }
            set
            {
                this.maximumZoomMovesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="positiveInteger")]
        public string MaximumRollMoves
        {
            get
            {
                return this.maximumRollMovesField;
            }
            set
            {
                this.maximumRollMovesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool AutoLevel
        {
            get
            {
                return this.autoLevelField;
            }
            set
            {
                this.autoLevelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AutoLevelSpecified
        {
            get
            {
                return this.autoLevelFieldSpecified;
            }
            set
            {
                this.autoLevelFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="positiveInteger")]
        public string MaximumFocusMoves
        {
            get
            {
                return this.maximumFocusMovesField;
            }
            set
            {
                this.maximumFocusMovesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool AutoFocus
        {
            get
            {
                return this.autoFocusField;
            }
            set
            {
                this.autoFocusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AutoFocusSpecified
        {
            get
            {
                return this.autoFocusFieldSpecified;
            }
            set
            {
                this.autoFocusFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl")]
    public partial class Usage
    {
        
        private string panField;
        
        private string tiltField;
        
        private string zoomField;
        
        private string rollField;
        
        private string focusField;
        
        private System.Xml.XmlElement[] anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="positiveInteger", Order=0)]
        public string Pan
        {
            get
            {
                return this.panField;
            }
            set
            {
                this.panField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="positiveInteger", Order=1)]
        public string Tilt
        {
            get
            {
                return this.tiltField;
            }
            set
            {
                this.tiltField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="positiveInteger", Order=2)]
        public string Zoom
        {
            get
            {
                return this.zoomField;
            }
            set
            {
                this.zoomField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="positiveInteger", Order=3)]
        public string Roll
        {
            get
            {
                return this.rollField;
            }
            set
            {
                this.rollField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="positiveInteger", Order=4)]
        public string Focus
        {
            get
            {
                return this.focusField;
            }
            set
            {
                this.focusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=5)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl")]
    public enum PanDirection
    {
        
        /// <remarks/>
        Left,
        
        /// <remarks/>
        Right,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PanMove", WrapperNamespace="http://www.onvif.org/ver10/provisioning/wsdl", IsWrapped=true)]
    public partial class PanMoveRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=0)]
        public string VideoSource;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=1)]
        public Quick.Onvif.Provisioning.PanDirection Direction;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="duration")]
        public string Timeout;
        
        public PanMoveRequest()
        {
        }
        
        public PanMoveRequest(string VideoSource, Quick.Onvif.Provisioning.PanDirection Direction, string Timeout)
        {
            this.VideoSource = VideoSource;
            this.Direction = Direction;
            this.Timeout = Timeout;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PanMoveResponse", WrapperNamespace="http://www.onvif.org/ver10/provisioning/wsdl", IsWrapped=true)]
    public partial class PanMoveResponse
    {
        
        public PanMoveResponse()
        {
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl")]
    public enum TiltDirection
    {
        
        /// <remarks/>
        Up,
        
        /// <remarks/>
        Down,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TiltMove", WrapperNamespace="http://www.onvif.org/ver10/provisioning/wsdl", IsWrapped=true)]
    public partial class TiltMoveRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=0)]
        public string VideoSource;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=1)]
        public Quick.Onvif.Provisioning.TiltDirection Direction;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="duration")]
        public string Timeout;
        
        public TiltMoveRequest()
        {
        }
        
        public TiltMoveRequest(string VideoSource, Quick.Onvif.Provisioning.TiltDirection Direction, string Timeout)
        {
            this.VideoSource = VideoSource;
            this.Direction = Direction;
            this.Timeout = Timeout;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="TiltMoveResponse", WrapperNamespace="http://www.onvif.org/ver10/provisioning/wsdl", IsWrapped=true)]
    public partial class TiltMoveResponse
    {
        
        public TiltMoveResponse()
        {
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl")]
    public enum ZoomDirection
    {
        
        /// <remarks/>
        Wide,
        
        /// <remarks/>
        Telephoto,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ZoomMove", WrapperNamespace="http://www.onvif.org/ver10/provisioning/wsdl", IsWrapped=true)]
    public partial class ZoomMoveRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=0)]
        public string VideoSource;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=1)]
        public Quick.Onvif.Provisioning.ZoomDirection Direction;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="duration")]
        public string Timeout;
        
        public ZoomMoveRequest()
        {
        }
        
        public ZoomMoveRequest(string VideoSource, Quick.Onvif.Provisioning.ZoomDirection Direction, string Timeout)
        {
            this.VideoSource = VideoSource;
            this.Direction = Direction;
            this.Timeout = Timeout;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ZoomMoveResponse", WrapperNamespace="http://www.onvif.org/ver10/provisioning/wsdl", IsWrapped=true)]
    public partial class ZoomMoveResponse
    {
        
        public ZoomMoveResponse()
        {
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl")]
    public enum RollDirection
    {
        
        /// <remarks/>
        Clockwise,
        
        /// <remarks/>
        Counterclockwise,
        
        /// <remarks/>
        Auto,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RollMove", WrapperNamespace="http://www.onvif.org/ver10/provisioning/wsdl", IsWrapped=true)]
    public partial class RollMoveRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=0)]
        public string VideoSource;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=1)]
        public Quick.Onvif.Provisioning.RollDirection Direction;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="duration")]
        public string Timeout;
        
        public RollMoveRequest()
        {
        }
        
        public RollMoveRequest(string VideoSource, Quick.Onvif.Provisioning.RollDirection Direction, string Timeout)
        {
            this.VideoSource = VideoSource;
            this.Direction = Direction;
            this.Timeout = Timeout;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RollMoveResponse", WrapperNamespace="http://www.onvif.org/ver10/provisioning/wsdl", IsWrapped=true)]
    public partial class RollMoveResponse
    {
        
        public RollMoveResponse()
        {
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl")]
    public enum FocusDirection
    {
        
        /// <remarks/>
        Near,
        
        /// <remarks/>
        Far,
        
        /// <remarks/>
        Auto,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FocusMove", WrapperNamespace="http://www.onvif.org/ver10/provisioning/wsdl", IsWrapped=true)]
    public partial class FocusMoveRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=0)]
        public string VideoSource;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=1)]
        public Quick.Onvif.Provisioning.FocusDirection Direction;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/provisioning/wsdl", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(DataType="duration")]
        public string Timeout;
        
        public FocusMoveRequest()
        {
        }
        
        public FocusMoveRequest(string VideoSource, Quick.Onvif.Provisioning.FocusDirection Direction, string Timeout)
        {
            this.VideoSource = VideoSource;
            this.Direction = Direction;
            this.Timeout = Timeout;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FocusMoveResponse", WrapperNamespace="http://www.onvif.org/ver10/provisioning/wsdl", IsWrapped=true)]
    public partial class FocusMoveResponse
    {
        
        public FocusMoveResponse()
        {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface ProvisioningServiceChannel : Quick.Onvif.Provisioning.ProvisioningService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class ProvisioningServiceClient : System.ServiceModel.ClientBase<Quick.Onvif.Provisioning.ProvisioningService>, Quick.Onvif.Provisioning.ProvisioningService
    {
        
        public ProvisioningServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Provisioning.Capabilities> GetServiceCapabilitiesAsync()
        {
            return base.Channel.GetServiceCapabilitiesAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.PanMoveResponse> Quick.Onvif.Provisioning.ProvisioningService.PanMoveAsync(Quick.Onvif.Provisioning.PanMoveRequest request)
        {
            return base.Channel.PanMoveAsync(request);
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Provisioning.PanMoveResponse> PanMoveAsync(string VideoSource, Quick.Onvif.Provisioning.PanDirection Direction, string Timeout)
        {
            Quick.Onvif.Provisioning.PanMoveRequest inValue = new Quick.Onvif.Provisioning.PanMoveRequest();
            inValue.VideoSource = VideoSource;
            inValue.Direction = Direction;
            inValue.Timeout = Timeout;
            return ((Quick.Onvif.Provisioning.ProvisioningService)(this)).PanMoveAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.TiltMoveResponse> Quick.Onvif.Provisioning.ProvisioningService.TiltMoveAsync(Quick.Onvif.Provisioning.TiltMoveRequest request)
        {
            return base.Channel.TiltMoveAsync(request);
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Provisioning.TiltMoveResponse> TiltMoveAsync(string VideoSource, Quick.Onvif.Provisioning.TiltDirection Direction, string Timeout)
        {
            Quick.Onvif.Provisioning.TiltMoveRequest inValue = new Quick.Onvif.Provisioning.TiltMoveRequest();
            inValue.VideoSource = VideoSource;
            inValue.Direction = Direction;
            inValue.Timeout = Timeout;
            return ((Quick.Onvif.Provisioning.ProvisioningService)(this)).TiltMoveAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.ZoomMoveResponse> Quick.Onvif.Provisioning.ProvisioningService.ZoomMoveAsync(Quick.Onvif.Provisioning.ZoomMoveRequest request)
        {
            return base.Channel.ZoomMoveAsync(request);
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Provisioning.ZoomMoveResponse> ZoomMoveAsync(string VideoSource, Quick.Onvif.Provisioning.ZoomDirection Direction, string Timeout)
        {
            Quick.Onvif.Provisioning.ZoomMoveRequest inValue = new Quick.Onvif.Provisioning.ZoomMoveRequest();
            inValue.VideoSource = VideoSource;
            inValue.Direction = Direction;
            inValue.Timeout = Timeout;
            return ((Quick.Onvif.Provisioning.ProvisioningService)(this)).ZoomMoveAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.RollMoveResponse> Quick.Onvif.Provisioning.ProvisioningService.RollMoveAsync(Quick.Onvif.Provisioning.RollMoveRequest request)
        {
            return base.Channel.RollMoveAsync(request);
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Provisioning.RollMoveResponse> RollMoveAsync(string VideoSource, Quick.Onvif.Provisioning.RollDirection Direction, string Timeout)
        {
            Quick.Onvif.Provisioning.RollMoveRequest inValue = new Quick.Onvif.Provisioning.RollMoveRequest();
            inValue.VideoSource = VideoSource;
            inValue.Direction = Direction;
            inValue.Timeout = Timeout;
            return ((Quick.Onvif.Provisioning.ProvisioningService)(this)).RollMoveAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Quick.Onvif.Provisioning.FocusMoveResponse> Quick.Onvif.Provisioning.ProvisioningService.FocusMoveAsync(Quick.Onvif.Provisioning.FocusMoveRequest request)
        {
            return base.Channel.FocusMoveAsync(request);
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Provisioning.FocusMoveResponse> FocusMoveAsync(string VideoSource, Quick.Onvif.Provisioning.FocusDirection Direction, string Timeout)
        {
            Quick.Onvif.Provisioning.FocusMoveRequest inValue = new Quick.Onvif.Provisioning.FocusMoveRequest();
            inValue.VideoSource = VideoSource;
            inValue.Direction = Direction;
            inValue.Timeout = Timeout;
            return ((Quick.Onvif.Provisioning.ProvisioningService)(this)).FocusMoveAsync(inValue);
        }
        
        public System.Threading.Tasks.Task StopAsync(string VideoSource)
        {
            return base.Channel.StopAsync(VideoSource);
        }
        
        public System.Threading.Tasks.Task<Quick.Onvif.Provisioning.Usage> GetUsageAsync(string VideoSource)
        {
            return base.Channel.GetUsageAsync(VideoSource);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
    }
}