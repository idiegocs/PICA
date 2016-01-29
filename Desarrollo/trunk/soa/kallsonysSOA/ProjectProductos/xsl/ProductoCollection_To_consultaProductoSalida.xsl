<?xml version="1.0" encoding="UTF-8" ?>
<?oracle-xsl-mapper
  <!-- SPECIFICATION OF MAP SOURCES AND TARGETS, DO NOT MODIFY. -->
  <mapSources>
    <source type="WSDL">
      <schema location="../getProductos.wsdl"/>
      <rootElement name="ProductoCollection" namespace="http://xmlns.oracle.com/pcbpel/adapter/db/top/getProductos"/>
    </source>
  </mapSources>
  <mapTargets>
    <target type="WSDL">
      <schema location="../Producto.wsdl"/>
      <rootElement name="consultaProductoSalida" namespace="http://www.kallsony.com/operacion/consultaproducto"/>
    </target>
  </mapTargets>
  <!-- GENERATED BY ORACLE XSL MAPPER 11.1.1.7.0(build 140919.1004.0161) AT [THU FEB 26 17:48:31 COT 2015]. -->
?>
<xsl:stylesheet version="1.0"
                xmlns:xp20="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.Xpath20"
                xmlns:bpws="http://schemas.xmlsoap.org/ws/2003/03/business-process/"
                xmlns:bpel="http://docs.oasis-open.org/wsbpel/2.0/process/executable"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:bpm="http://xmlns.oracle.com/bpmn20/extensions"
                xmlns:plt="http://schemas.xmlsoap.org/ws/2003/05/partner-link/"
                xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/"
                xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/"
                xmlns:ora="http://schemas.oracle.com/xpath/extension"
                xmlns:ns1="http://www.kallsony.com/entidad/producto"
                xmlns:tns="http://xmlns.oracle.com/pcbpel/adapter/db/kallSonysApp/productos/getProductos"
                xmlns:socket="http://www.oracle.com/XSL/Transform/java/oracle.tip.adapter.socket.ProtocolTranslator"
                xmlns:mhdr="http://www.oracle.com/XSL/Transform/java/oracle.tip.mediator.service.common.functions.MediatorExtnFunction"
                xmlns:oraext="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.ExtFunc"
                xmlns:dvm="http://www.oracle.com/XSL/Transform/java/oracle.tip.dvm.LookupValue"
                xmlns:hwf="http://xmlns.oracle.com/bpel/workflow/xpath"
                xmlns:ns2="http://www.kallsony.com/util/filtro"
                xmlns:med="http://schemas.oracle.com/mediator/xpath"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ids="http://xmlns.oracle.com/bpel/services/IdentityService/xpath"
                xmlns:top="http://xmlns.oracle.com/pcbpel/adapter/db/top/getProductos"
                xmlns:wkcuf="http://www.kallsony.com/util/falta"
                xmlns:xdk="http://schemas.oracle.com/bpel/extension/xpath/function/xdk"
                xmlns:xref="http://www.oracle.com/XSL/Transform/java/oracle.tip.xref.xpath.XRefXPathFunctions"
                xmlns:ns0="http://www.kallsony.com/final/operacion/consultaproducto"
                xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                xmlns:wkcoc="http://www.kallsony.com/operacion/consultaproducto"
                xmlns:ldap="http://schemas.oracle.com/xpath/extension/ldap"
                exclude-result-prefixes="xsi xsl plt wsdl tns top xsd soap ns1 ns2 wkcuf ns0 wkcoc xp20 bpws bpel bpm ora socket mhdr oraext dvm hwf med ids xdk xref ldap">
  <xsl:template match="/">
    <wkcoc:consultaProductoSalida>
      <wkcoc:respuestaFiltro>
        <totalElementos>
          <xsl:value-of select="number(300.0)"/>
        </totalElementos>
        <pagina>
          <xsl:value-of select="number(2.0)"/>
        </pagina>
      </wkcoc:respuestaFiltro>
      <wkcoc:listaProductos>
        <xsl:for-each select="/top:ProductoCollection/top:Producto">
          <wkcoc:producto>
            <idProducto>
              <xsl:value-of select="top:IdProducto"/>
            </idProducto>
            <codigoProducto>
              <xsl:value-of select="top:CodigoProducto"/>
            </codigoProducto>
            <nombreProducto>
              <xsl:value-of select="top:NombreProducto"/>
            </nombreProducto>
            <descripcionProducto>
              <xsl:value-of select="top:DescripcionProducto"/>
            </descripcionProducto>
            <fabricanteProducto>
              <xsl:value-of select="top:NombreFabricante"/>
            </fabricanteProducto>
            <nombreImagenProducto>
              <xsl:value-of select="top:NombreImagenProducto"/>
            </nombreImagenProducto>
            <precioProducto>
              <xsl:value-of select="top:PrecioUnitario"/>
            </precioProducto>
            <tipoProducto>
              <categoria>
                <idTipo>
                  <xsl:value-of select="top:IdSubcategoria/top:IdCategoria/top:IdCategoria"/>
                </idTipo>
                <nombreTipo>
                  <xsl:value-of select="top:IdSubcategoria/top:IdCategoria/top:NombreCategoria"/>
                </nombreTipo>
              </categoria>
              <subCategoria>
                <idTipo>
                  <xsl:value-of select="top:IdSubcategoria/top:IdSubcategoria"/>
                </idTipo>
                <nombreTipo>
                  <xsl:value-of select="top:IdSubcategoria/top:NombreSubcategoria"/>
                </nombreTipo>
              </subCategoria>
            </tipoProducto>
          </wkcoc:producto>
        </xsl:for-each>
      </wkcoc:listaProductos>
    </wkcoc:consultaProductoSalida>
  </xsl:template>
</xsl:stylesheet>
