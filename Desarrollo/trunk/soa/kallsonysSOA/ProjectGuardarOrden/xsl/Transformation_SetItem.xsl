<?xml version="1.0" encoding="UTF-8" ?>
<?oracle-xsl-mapper
  <!-- SPECIFICATION OF MAP SOURCES AND TARGETS, DO NOT MODIFY. -->
  <mapSources>
    <source type="WSDL">
      <schema location="../BPELGuardarCompra.wsdl"/>
      <rootElement name="unItem" namespace="http://www.kallsony.com/entidad/orden"/>
    </source>
    <source type="WSDL">
      <schema location="../setOrden.wsdl"/>
      <rootElement name="OrdenCollection" namespace="http://xmlns.oracle.com/pcbpel/adapter/db/top/setOrden"/>
      <param name="InvokeSetOrden_OutputVariable.OrdenCollection" />
    </source>
  </mapSources>
  <mapTargets>
    <target type="WSDL">
      <schema location="../setItemOrden.wsdl"/>
      <rootElement name="ItemOrdenCollection" namespace="http://xmlns.oracle.com/pcbpel/adapter/db/top/setItemOrden"/>
    </target>
  </mapTargets>
  <!-- GENERATED BY ORACLE XSL MAPPER 11.1.1.7.0(build 140919.1004.0161) AT [SUN MAY 31 08:58:32 COT 2015]. -->
?>
<xsl:stylesheet version="1.0"
                xmlns:xp20="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.Xpath20"
                xmlns:bpws="http://schemas.xmlsoap.org/ws/2003/03/business-process/"
                xmlns:bpel="http://docs.oasis-open.org/wsbpel/2.0/process/executable"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:ns2="http://www.kallsony.com/entidad/compra"
                xmlns:ns4="http://www.kallsony.com/entidad/tarjeta"
                xmlns:bpm="http://xmlns.oracle.com/bpmn20/extensions"
                xmlns:plnk="http://schemas.xmlsoap.org/ws/2003/05/partner-link/"
                xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/"
                xmlns:ora="http://schemas.oracle.com/xpath/extension"
                xmlns:ns3="http://www.kallsony.com/entidad/producto"
                xmlns:socket="http://www.oracle.com/XSL/Transform/java/oracle.tip.adapter.socket.ProtocolTranslator"
                xmlns:ns6="http://xmlns.oracle.com/pcbpel/adapter/db/Appkallsonys/ProjectGuardarOrden/setItemOrden"
                xmlns:top="http://xmlns.oracle.com/pcbpel/adapter/db/top/setOrden"
                xmlns:mhdr="http://www.oracle.com/XSL/Transform/java/oracle.tip.mediator.service.common.functions.MediatorExtnFunction"
                xmlns:oraext="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.ExtFunc"
                xmlns:dvm="http://www.oracle.com/XSL/Transform/java/oracle.tip.dvm.LookupValue"
                xmlns:hwf="http://xmlns.oracle.com/bpel/workflow/xpath"
                xmlns:tns="http://xmlns.oracle.com/pcbpel/adapter/db/Appkallsonys/ProjectGuardarOrden/setOrden"
                xmlns:med="http://schemas.oracle.com/mediator/xpath"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ns1="http://www.kallsony.com/entidad/orden"
                xmlns:ids="http://xmlns.oracle.com/bpel/services/IdentityService/xpath"
                xmlns:client="http://www.kallsony.com/operacion/guardarcompra"
                xmlns:ns5="http://www.kallsony.com/entidad/usuario"
                xmlns:xdk="http://schemas.oracle.com/bpel/extension/xpath/function/xdk"
                xmlns:xref="http://www.oracle.com/XSL/Transform/java/oracle.tip.xref.xpath.XRefXPathFunctions"
                xmlns:ns0="http://www.kallsony.com/entidad/direccion"
                xmlns:ns7="http://xmlns.oracle.com/pcbpel/adapter/db/top/setItemOrden"
                xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                xmlns:ldap="http://schemas.oracle.com/xpath/extension/ldap"
                exclude-result-prefixes="xsi xsl ns2 ns4 plnk wsdl ns3 top tns ns1 client ns5 ns0 xsd ns6 ns7 xp20 bpws bpel bpm ora socket mhdr oraext dvm hwf med ids xdk xref ldap">
  <xsl:param name="InvokeSetOrden_OutputVariable.OrdenCollection"/>
  <xsl:template match="/">
    <ns7:ItemOrdenCollection>
      <ns7:ItemOrden>
        <xsl:if test="/ns1:unItem/tipo">
          <xsl:choose>
            <xsl:when test='string(/ns1:unItem/tipo) = "true"'>
              <ns7:tipoitem>
                <xsl:value-of select="number(1.0)"/>
              </ns7:tipoitem>
            </xsl:when>
            <xsl:otherwise>
              <ns7:tipoitem>
                <xsl:value-of select="number(0.0)"/>
              </ns7:tipoitem>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
        <xsl:if test="$InvokeSetOrden_OutputVariable.OrdenCollection/top:OrdenCollection/top:Orden/top:idorden">
          <ns7:idorden>
            <xsl:value-of select="$InvokeSetOrden_OutputVariable.OrdenCollection/top:OrdenCollection/top:Orden/top:idorden"/>
          </ns7:idorden>
        </xsl:if>
        <xsl:if test="/ns1:unItem/producto/idProducto">
          <ns7:idproducto>
            <xsl:value-of select="/ns1:unItem/producto/idProducto"/>
          </ns7:idproducto>
        </xsl:if>
        <xsl:if test="/ns1:unItem/producto/codigoProducto">
          <ns7:codigoproducto>
            <xsl:value-of select="/ns1:unItem/producto/codigoProducto"/>
          </ns7:codigoproducto>
        </xsl:if>
        <xsl:if test="/ns1:unItem/producto/nombreProducto">
          <ns7:nombreproducto>
            <xsl:value-of select="/ns1:unItem/producto/nombreProducto"/>
          </ns7:nombreproducto>
        </xsl:if>
        <xsl:if test="/ns1:unItem/cantidad">
          <ns7:cantidaditem>
            <xsl:value-of select="/ns1:unItem/cantidad"/>
          </ns7:cantidaditem>
        </xsl:if>
        <xsl:if test="/ns1:unItem/producto/precioProducto">
          <ns7:valorunitarioitem>
            <xsl:value-of select="/ns1:unItem/producto/precioProducto"/>
          </ns7:valorunitarioitem>
        </xsl:if>
      </ns7:ItemOrden>
    </ns7:ItemOrdenCollection>
  </xsl:template>
</xsl:stylesheet>
