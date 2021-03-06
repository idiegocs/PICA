<?xml version="1.0" encoding="UTF-8" ?>
<?oracle-xsl-mapper
  <!-- SPECIFICATION OF MAP SOURCES AND TARGETS, DO NOT MODIFY. -->
  <mapSources>
    <source type="WSDL">
      <schema location="../BPELOrdenCompra.wsdl"/>
      <rootElement name="unaOrden" namespace="http://www.kallsony.com/entidad/orden"/>
    </source>
    <source type="WSDL">
      <schema location="../BPELOrdenCompra.wsdl"/>
      <rootElement name="unUsuario" namespace="http://www.kallsony.com/entidad/orden"/>
      <param name="VariableUser" />
    </source>
  </mapSources>
  <mapTargets>
    <target type="WSDL">
      <schema location="../setOrden.wsdl"/>
      <rootElement name="OrdenCollection" namespace="http://xmlns.oracle.com/pcbpel/adapter/db/top/setOrden"/>
    </target>
  </mapTargets>
  <!-- GENERATED BY ORACLE XSL MAPPER 11.1.1.7.0(build 140919.1004.0161) AT [MON APR 20 18:53:21 COT 2015]. -->
?>
<xsl:stylesheet version="1.0"
                xmlns:xp20="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.Xpath20"
                xmlns:bpws="http://schemas.xmlsoap.org/ws/2003/03/business-process/"
                xmlns:bpel="http://docs.oasis-open.org/wsbpel/2.0/process/executable"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:ns3="http://www.kallsony.com/entidad/compra"
                xmlns:ns5="http://www.kallsony.com/entidad/tarjeta"
                xmlns:bpm="http://xmlns.oracle.com/bpmn20/extensions"
                xmlns:plnk="http://schemas.xmlsoap.org/ws/2003/05/partner-link/"
                xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/"
                xmlns:ns4="http://www.kallsony.com/entidad/producto"
                xmlns:ora="http://schemas.oracle.com/xpath/extension"
                xmlns:socket="http://www.oracle.com/XSL/Transform/java/oracle.tip.adapter.socket.ProtocolTranslator"
                xmlns:ns1="http://www.kallsony.com/operacion/registrarcompra"
                xmlns:top="http://xmlns.oracle.com/pcbpel/adapter/db/top/setOrden"
                xmlns:client="http://xmlns.oracle.com/Appkallsonys/ProjectOrden/BPELOrdenCompra"
                xmlns:mhdr="http://www.oracle.com/XSL/Transform/java/oracle.tip.mediator.service.common.functions.MediatorExtnFunction"
                xmlns:oraext="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.ExtFunc"
                xmlns:dvm="http://www.oracle.com/XSL/Transform/java/oracle.tip.dvm.LookupValue"
                xmlns:hwf="http://xmlns.oracle.com/bpel/workflow/xpath"
                xmlns:tns="http://xmlns.oracle.com/pcbpel/adapter/db/Appkallsonys/ProjectOrden/setOrden"
                xmlns:med="http://schemas.oracle.com/mediator/xpath"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ids="http://xmlns.oracle.com/bpel/services/IdentityService/xpath"
                xmlns:ns2="http://www.kallsony.com/entidad/orden"
                xmlns:ns6="http://www.kallsony.com/entidad/usuario"
                xmlns:xdk="http://schemas.oracle.com/bpel/extension/xpath/function/xdk"
                xmlns:xref="http://www.oracle.com/XSL/Transform/java/oracle.tip.xref.xpath.XRefXPathFunctions"
                xmlns:ns0="http://www.kallsony.com/entidad/direccion"
                xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                xmlns:ldap="http://schemas.oracle.com/xpath/extension/ldap"
                exclude-result-prefixes="xsi xsl ns3 ns5 plnk wsdl ns4 ns1 client ns2 ns6 ns0 xsd top tns xp20 bpws bpel bpm ora socket mhdr oraext dvm hwf med ids xdk xref ldap">
  <xsl:param name="VariableUser"/>
  <xsl:template match="/">
    <top:OrdenCollection>
      <top:Orden>
        <top:fechaorden>
          <xsl:value-of select="xp20:current-date()"/>
        </top:fechaorden>
        <top:idestadoorden>
          <xsl:value-of select="number(1)"/>
        </top:idestadoorden>
        <xsl:if test="$VariableUser/ns2:unUsuario/idUsuario">
          <top:idcliente>
            <xsl:value-of select="$VariableUser/ns2:unUsuario/idUsuario"/>
          </top:idcliente>
        </xsl:if>
        <xsl:if test="/ns2:unaOrden/numeroItems">
          <top:cantitemorden>
            <xsl:value-of select="/ns2:unaOrden/numeroItems"/>
          </top:cantitemorden>
        </xsl:if>
        <xsl:if test="/ns2:unaOrden/total">
          <top:totalorden>
            <xsl:value-of select="/ns2:unaOrden/total"/>
          </top:totalorden>
        </xsl:if>
        <xsl:if test="/ns2:unaOrden/idOrden">
          <top:numpreorden>
            <xsl:value-of select="/ns2:unaOrden/idOrden"/>
          </top:numpreorden>
        </xsl:if>
      </top:Orden>
    </top:OrdenCollection>
  </xsl:template>
</xsl:stylesheet>
