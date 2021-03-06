<?xml version="1.0" encoding="UTF-8" ?>
<?oracle-xsl-mapper
  <!-- SPECIFICATION OF MAP SOURCES AND TARGETS, DO NOT MODIFY. -->
  <mapSources>
    <source type="WSDL">
      <schema location="../BPELCotizacion.wsdl"/>
      <rootElement name="cotizacionEntrada" namespace="http://www.kallsony.com/operacion/cotizarcompra"/>
    </source>
  </mapSources>
  <mapTargets>
    <target type="WSDL">
      <schema location="http://localhost:7002/OSBSony/ProxyServices/ProxySony?WSDL"/>
      <rootElement name="fullfillOrder" namespace="http://tempuri.org/"/>
    </target>
  </mapTargets>
  <!-- GENERATED BY ORACLE XSL MAPPER 11.1.1.7.0(build 140919.1004.0161) AT [TUE JUN 02 13:34:36 COT 2015]. -->
?>
<xsl:stylesheet version="1.0"
                xmlns:wsa="http://schemas.xmlsoap.org/ws/2004/08/addressing"
                xmlns:client="http://xmlns.oracle.com/Appkallsonys/ProjectCotizacion/BPELCotizacion"
                xmlns:xp20="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.Xpath20"
                xmlns:bpws="http://schemas.xmlsoap.org/ws/2003/03/business-process/"
                xmlns:ns5="http://schemas.microsoft.com/2003/10/Serialization/"
                xmlns:bpel="http://docs.oasis-open.org/wsbpel/2.0/process/executable"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:ns7="http://tempuri.org/Imports"
                xmlns:wsa10="http://www.w3.org/2005/08/addressing"
                xmlns:bpm="http://xmlns.oracle.com/bpmn20/extensions"
                xmlns:ns6="http://schemas.datacontract.org/2004/07/WcfSony"
                xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/"
                xmlns:plnk="http://schemas.xmlsoap.org/ws/2003/05/partner-link/"
                xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/"
                xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/"
                xmlns:tns="http://tempuri.org/"
                xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/"
                xmlns:ns2="http://www.kallsony.com/entidad/producto"
                xmlns:ora="http://schemas.oracle.com/xpath/extension"
                xmlns:wsx="http://schemas.xmlsoap.org/ws/2004/09/mex"
                xmlns:socket="http://www.oracle.com/XSL/Transform/java/oracle.tip.adapter.socket.ProtocolTranslator"
                xmlns:wsap="http://schemas.xmlsoap.org/ws/2004/08/addressing/policy"
                xmlns:wsaw="http://www.w3.org/2006/05/addressing/wsdl"
                xmlns:mhdr="http://www.oracle.com/XSL/Transform/java/oracle.tip.mediator.service.common.functions.MediatorExtnFunction"
                xmlns:oraext="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.ExtFunc"
                xmlns:dvm="http://www.oracle.com/XSL/Transform/java/oracle.tip.dvm.LookupValue"
                xmlns:hwf="http://xmlns.oracle.com/bpel/workflow/xpath"
                xmlns:med="http://schemas.oracle.com/mediator/xpath"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ns3="http://www.kallsony.com/entidad/orden"
                xmlns:ids="http://xmlns.oracle.com/bpel/services/IdentityService/xpath"
                xmlns:wsp="http://schemas.xmlsoap.org/ws/2004/09/policy"
                xmlns:ns4="http://www.kallsony.com/entidad/usuario"
                xmlns:xdk="http://schemas.oracle.com/bpel/extension/xpath/function/xdk"
                xmlns:xref="http://www.oracle.com/XSL/Transform/java/oracle.tip.xref.xpath.XRefXPathFunctions"
                xmlns:msc="http://schemas.microsoft.com/ws/2005/12/wsdl/contract"
                xmlns:ns0="http://www.kallsony.com/entidad/direccion"
                xmlns:wsu="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"
                xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                xmlns:ns1="http://www.kallsony.com/operacion/cotizarcompra"
                xmlns:wsam="http://www.w3.org/2007/05/addressing/metadata"
                xmlns:ldap="http://schemas.oracle.com/xpath/extension/ldap"
                exclude-result-prefixes="xsi xsl client plnk wsdl ns2 ns3 ns4 ns0 xsd ns1 wsa ns5 ns7 wsa10 ns6 soap12 soapenc soap tns wsx wsap wsaw wsp msc wsu wsam xp20 bpws bpel bpm ora socket mhdr oraext dvm hwf med ids xdk xref ldap">
  <xsl:template match="/">
    <tns:fullfillOrder>
      <tns:envio>
        <ns6:addresseeLastName>
          <xsl:value-of select="/ns1:cotizacionEntrada/ns1:usuarioEnvio/apellido"/>
        </ns6:addresseeLastName>
        <ns6:addresseeName>
          <xsl:value-of select="/ns1:cotizacionEntrada/ns1:usuarioEnvio/nombre"/>
        </ns6:addresseeName>
        <ns6:city>
          <xsl:value-of select="/ns1:cotizacionEntrada/ns1:usuarioEnvio/direccion/idCiudad"/>
        </ns6:city>
        <ns6:country>
          <xsl:value-of select="/ns1:cotizacionEntrada/ns1:usuarioEnvio/direccion/pais"/>
        </ns6:country>
        <ns6:items>
          <xsl:for-each select="/ns1:cotizacionEntrada/ns1:orden/listaItems/items">
            <ns6:Item>
              <ns6:itemID>
                <xsl:value-of select="producto/idProducto"/>
              </ns6:itemID>
              <ns6:partNumber>
                <xsl:value-of select="producto/codigoProducto"/>
              </ns6:partNumber>
              <ns6:price>
                <xsl:value-of select="producto/precioProducto"/>
              </ns6:price>
              <ns6:prodID>
                <xsl:value-of select="producto/idProducto"/>
              </ns6:prodID>
              <ns6:productName>
                <xsl:value-of select="producto/nombreProducto"/>
              </ns6:productName>
              <ns6:quantity>
                <xsl:value-of select="cantidad"/>
              </ns6:quantity>
            </ns6:Item>
          </xsl:for-each>
        </ns6:items>
        <ns6:orderId>
          <xsl:value-of select="/ns1:cotizacionEntrada/ns1:idOrden"/>
        </ns6:orderId>
        <ns6:partner>
          <xsl:value-of select="string('Kallsonys')"/>
        </ns6:partner>
        <ns6:state>
          <xsl:value-of select="/ns1:cotizacionEntrada/ns1:usuarioEnvio/direccion/idDepartamento"/>
        </ns6:state>
        <ns6:street>
          <xsl:value-of select="/ns1:cotizacionEntrada/ns1:usuarioEnvio/direccion/numero"/>
        </ns6:street>
        <ns6:supplier>
          <xsl:value-of select="string('SONY')"/>
        </ns6:supplier>
        <ns6:zipcode>
          <xsl:value-of select="number('1')"/>
        </ns6:zipcode>
      </tns:envio>
    </tns:fullfillOrder>
  </xsl:template>
</xsl:stylesheet>
