﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFClientWSProductos.ServiceMierda {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.kallsony.com/util/falta")]
    public partial class Falta : object, System.ComponentModel.INotifyPropertyChanged {
        
        private long idErrorField;
        
        private bool idErrorFieldSpecified;
        
        private string nombreErrorField;
        
        private string descripcionErrorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public long idError {
            get {
                return this.idErrorField;
            }
            set {
                this.idErrorField = value;
                this.RaisePropertyChanged("idError");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idErrorSpecified {
            get {
                return this.idErrorFieldSpecified;
            }
            set {
                this.idErrorFieldSpecified = value;
                this.RaisePropertyChanged("idErrorSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string nombreError {
            get {
                return this.nombreErrorField;
            }
            set {
                this.nombreErrorField = value;
                this.RaisePropertyChanged("nombreError");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string descripcionError {
            get {
                return this.descripcionErrorField;
            }
            set {
                this.descripcionErrorField = value;
                this.RaisePropertyChanged("descripcionError");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.kallsony.com/entidad/producto")]
    public partial class Tipo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idTipoField;
        
        private bool idTipoFieldSpecified;
        
        private string nombreTipoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int idTipo {
            get {
                return this.idTipoField;
            }
            set {
                this.idTipoField = value;
                this.RaisePropertyChanged("idTipo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idTipoSpecified {
            get {
                return this.idTipoFieldSpecified;
            }
            set {
                this.idTipoFieldSpecified = value;
                this.RaisePropertyChanged("idTipoSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string nombreTipo {
            get {
                return this.nombreTipoField;
            }
            set {
                this.nombreTipoField = value;
                this.RaisePropertyChanged("nombreTipo");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.kallsony.com/entidad/producto")]
    public partial class TipoProducto : object, System.ComponentModel.INotifyPropertyChanged {
        
        private Tipo categoriaField;
        
        private Tipo subCategoriaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public Tipo categoria {
            get {
                return this.categoriaField;
            }
            set {
                this.categoriaField = value;
                this.RaisePropertyChanged("categoria");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public Tipo subCategoria {
            get {
                return this.subCategoriaField;
            }
            set {
                this.subCategoriaField = value;
                this.RaisePropertyChanged("subCategoria");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.kallsony.com/entidad/producto")]
    public partial class Producto : object, System.ComponentModel.INotifyPropertyChanged {
        
        private long idProductoField;
        
        private bool idProductoFieldSpecified;
        
        private string codigoProductoField;
        
        private string nombreProductoField;
        
        private string descripcionProductoField;
        
        private string fabricanteProductoField;
        
        private string nombreImagenProductoField;
        
        private float precioProductoField;
        
        private bool precioProductoFieldSpecified;
        
        private TipoProducto tipoProductoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public long idProducto {
            get {
                return this.idProductoField;
            }
            set {
                this.idProductoField = value;
                this.RaisePropertyChanged("idProducto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idProductoSpecified {
            get {
                return this.idProductoFieldSpecified;
            }
            set {
                this.idProductoFieldSpecified = value;
                this.RaisePropertyChanged("idProductoSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string codigoProducto {
            get {
                return this.codigoProductoField;
            }
            set {
                this.codigoProductoField = value;
                this.RaisePropertyChanged("codigoProducto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string nombreProducto {
            get {
                return this.nombreProductoField;
            }
            set {
                this.nombreProductoField = value;
                this.RaisePropertyChanged("nombreProducto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string descripcionProducto {
            get {
                return this.descripcionProductoField;
            }
            set {
                this.descripcionProductoField = value;
                this.RaisePropertyChanged("descripcionProducto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string fabricanteProducto {
            get {
                return this.fabricanteProductoField;
            }
            set {
                this.fabricanteProductoField = value;
                this.RaisePropertyChanged("fabricanteProducto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string nombreImagenProducto {
            get {
                return this.nombreImagenProductoField;
            }
            set {
                this.nombreImagenProductoField = value;
                this.RaisePropertyChanged("nombreImagenProducto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public float precioProducto {
            get {
                return this.precioProductoField;
            }
            set {
                this.precioProductoField = value;
                this.RaisePropertyChanged("precioProducto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool precioProductoSpecified {
            get {
                return this.precioProductoFieldSpecified;
            }
            set {
                this.precioProductoFieldSpecified = value;
                this.RaisePropertyChanged("precioProductoSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public TipoProducto tipoProducto {
            get {
                return this.tipoProductoField;
            }
            set {
                this.tipoProductoField = value;
                this.RaisePropertyChanged("tipoProducto");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.kallsony.com/util/filtro")]
    public partial class RespuestaFiltro : object, System.ComponentModel.INotifyPropertyChanged {
        
        private long totalElementosField;
        
        private bool totalElementosFieldSpecified;
        
        private int paginaField;
        
        private bool paginaFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public long totalElementos {
            get {
                return this.totalElementosField;
            }
            set {
                this.totalElementosField = value;
                this.RaisePropertyChanged("totalElementos");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool totalElementosSpecified {
            get {
                return this.totalElementosFieldSpecified;
            }
            set {
                this.totalElementosFieldSpecified = value;
                this.RaisePropertyChanged("totalElementosSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int pagina {
            get {
                return this.paginaField;
            }
            set {
                this.paginaField = value;
                this.RaisePropertyChanged("pagina");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool paginaSpecified {
            get {
                return this.paginaFieldSpecified;
            }
            set {
                this.paginaFieldSpecified = value;
                this.RaisePropertyChanged("paginaSpecified");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.kallsony.com/operacion/consultaproducto")]
    public partial class ConsultaProductoSalida : object, System.ComponentModel.INotifyPropertyChanged {
        
        private RespuestaFiltro respuestaFiltroField;
        
        private Producto[] listaProductosField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public RespuestaFiltro respuestaFiltro {
            get {
                return this.respuestaFiltroField;
            }
            set {
                this.respuestaFiltroField = value;
                this.RaisePropertyChanged("respuestaFiltro");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("producto", IsNullable=false)]
        public Producto[] listaProductos {
            get {
                return this.listaProductosField;
            }
            set {
                this.listaProductosField = value;
                this.RaisePropertyChanged("listaProductos");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.kallsony.com/util/filtro")]
    public partial class Filtro : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string tipoFiltroField;
        
        private string valorFiltroField;
        
        private int paginaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string tipoFiltro {
            get {
                return this.tipoFiltroField;
            }
            set {
                this.tipoFiltroField = value;
                this.RaisePropertyChanged("tipoFiltro");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string valorFiltro {
            get {
                return this.valorFiltroField;
            }
            set {
                this.valorFiltroField = value;
                this.RaisePropertyChanged("valorFiltro");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int pagina {
            get {
                return this.paginaField;
            }
            set {
                this.paginaField = value;
                this.RaisePropertyChanged("pagina");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.kallsony.com/operacion/consultaproducto")]
    public partial class ConsultaProductoEntrada : object, System.ComponentModel.INotifyPropertyChanged {
        
        private Filtro filtroProductoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public Filtro filtroProducto {
            get {
                return this.filtroProductoField;
            }
            set {
                this.filtroProductoField = value;
                this.RaisePropertyChanged("filtroProducto");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.kallsony.com/final/operacion/consultaproducto", ConfigurationName="ServiceMierda.ProductosPort")]
    public interface ProductosPort {
        
        // CODEGEN: Generating message contract since the operation ConsultarProductos is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="pro:Producto/ConsultarProductos", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(WindowsFClientWSProductos.ServiceMierda.Falta), Action="pro:Producto/ConsultarProductos", Name="falta", Namespace="http://www.kallsony.com/util/falta")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WindowsFClientWSProductos.ServiceMierda.ConsultarProductosResponse ConsultarProductos(WindowsFClientWSProductos.ServiceMierda.ConsultarProductosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="pro:Producto/ConsultarProductos", ReplyAction="*")]
        System.Threading.Tasks.Task<WindowsFClientWSProductos.ServiceMierda.ConsultarProductosResponse> ConsultarProductosAsync(WindowsFClientWSProductos.ServiceMierda.ConsultarProductosRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ConsultarProductosRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.kallsony.com/operacion/consultaproducto", Order=0)]
        public WindowsFClientWSProductos.ServiceMierda.ConsultaProductoEntrada consultaProductoEntrada;
        
        public ConsultarProductosRequest() {
        }
        
        public ConsultarProductosRequest(WindowsFClientWSProductos.ServiceMierda.ConsultaProductoEntrada consultaProductoEntrada) {
            this.consultaProductoEntrada = consultaProductoEntrada;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ConsultarProductosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.kallsony.com/operacion/consultaproducto", Order=0)]
        public WindowsFClientWSProductos.ServiceMierda.ConsultaProductoSalida consultaProductoSalida;
        
        public ConsultarProductosResponse() {
        }
        
        public ConsultarProductosResponse(WindowsFClientWSProductos.ServiceMierda.ConsultaProductoSalida consultaProductoSalida) {
            this.consultaProductoSalida = consultaProductoSalida;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ProductosPortChannel : WindowsFClientWSProductos.ServiceMierda.ProductosPort, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductosPortClient : System.ServiceModel.ClientBase<WindowsFClientWSProductos.ServiceMierda.ProductosPort>, WindowsFClientWSProductos.ServiceMierda.ProductosPort {
        
        public ProductosPortClient() {
        }
        
        public ProductosPortClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductosPortClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductosPortClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductosPortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WindowsFClientWSProductos.ServiceMierda.ConsultarProductosResponse WindowsFClientWSProductos.ServiceMierda.ProductosPort.ConsultarProductos(WindowsFClientWSProductos.ServiceMierda.ConsultarProductosRequest request) {
            return base.Channel.ConsultarProductos(request);
        }
        
        public WindowsFClientWSProductos.ServiceMierda.ConsultaProductoSalida ConsultarProductos(WindowsFClientWSProductos.ServiceMierda.ConsultaProductoEntrada consultaProductoEntrada) {
            WindowsFClientWSProductos.ServiceMierda.ConsultarProductosRequest inValue = new WindowsFClientWSProductos.ServiceMierda.ConsultarProductosRequest();
            inValue.consultaProductoEntrada = consultaProductoEntrada;
            WindowsFClientWSProductos.ServiceMierda.ConsultarProductosResponse retVal = ((WindowsFClientWSProductos.ServiceMierda.ProductosPort)(this)).ConsultarProductos(inValue);
            return retVal.consultaProductoSalida;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WindowsFClientWSProductos.ServiceMierda.ConsultarProductosResponse> WindowsFClientWSProductos.ServiceMierda.ProductosPort.ConsultarProductosAsync(WindowsFClientWSProductos.ServiceMierda.ConsultarProductosRequest request) {
            return base.Channel.ConsultarProductosAsync(request);
        }
        
        public System.Threading.Tasks.Task<WindowsFClientWSProductos.ServiceMierda.ConsultarProductosResponse> ConsultarProductosAsync(WindowsFClientWSProductos.ServiceMierda.ConsultaProductoEntrada consultaProductoEntrada) {
            WindowsFClientWSProductos.ServiceMierda.ConsultarProductosRequest inValue = new WindowsFClientWSProductos.ServiceMierda.ConsultarProductosRequest();
            inValue.consultaProductoEntrada = consultaProductoEntrada;
            return ((WindowsFClientWSProductos.ServiceMierda.ProductosPort)(this)).ConsultarProductosAsync(inValue);
        }
    }
}
