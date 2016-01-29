<?xml version="1.0" encoding="UTF-8" ?>
<?oracle-xsl-mapper
  <!-- SPECIFICATION OF MAP SOURCES AND TARGETS, DO NOT MODIFY. -->
  <mapSources>
    <source type="WSDL">
      <schema location="../Campanias.wsdl"/>
      <rootElement name="unProductoCampania" namespace="http://www.kallsony.com/entidad/campania"/>
    </source>
    <source type="WSDL">
      <schema location="../Campanias.wsdl"/>
      <rootElement name="UnProducto" namespace="http://www.kallsony.com/entidad/producto"/>
      <param name="VariableUnProduc" />
    </source>
  </mapSources>
  <mapTargets>
    <target type="WSDL">
      <schema location="../Campanias.wsdl"/>
      <rootElement name="unProductoCampania" namespace="http://www.kallsony.com/entidad/campania"/>
    </target>
  </mapTargets>
  <!-- GENERATED BY ORACLE XSL MAPPER 11.1.1.7.0(build 140919.1004.0161) AT [FRI MAY 15 12:52:52 COT 2015]. -->
?>
<xsl:stylesheet version="1.0"
                xmlns:xp20="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.Xpath20"
                xmlns:bpws="http://schemas.xmlsoap.org/ws/2003/03/business-process/"
                xmlns:bpel="http://docs.oasis-open.org/wsbpel/2.0/process/executable"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:bpm="http://xmlns.oracle.com/bpmn20/extensions"
                xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/"
                xmlns:ora="http://schemas.oracle.com/xpath/extension"
                xmlns:ns1="http://www.kallsony.com/entidad/producto"
                xmlns:socket="http://www.oracle.com/XSL/Transform/java/oracle.tip.adapter.socket.ProtocolTranslator"
                xmlns:tns="http://www.kallsony.com/final/operacion/consultacampanias"
                xmlns:ns2="http://www.kallsony.com/entidad/campania"
                xmlns:mhdr="http://www.oracle.com/XSL/Transform/java/oracle.tip.mediator.service.common.functions.MediatorExtnFunction"
                xmlns:oraext="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.ExtFunc"
                xmlns:dvm="http://www.oracle.com/XSL/Transform/java/oracle.tip.dvm.LookupValue"
                xmlns:hwf="http://xmlns.oracle.com/bpel/workflow/xpath"
                xmlns:ns0="http://www.kallsony.com/util/filtro"
                xmlns:med="http://schemas.oracle.com/mediator/xpath"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ids="http://xmlns.oracle.com/bpel/services/IdentityService/xpath"
                xmlns:wkcaf="http://www.kallsony.com/util/falta"
                xmlns:xdk="http://schemas.oracle.com/bpel/extension/xpath/function/xdk"
                xmlns:xref="http://www.oracle.com/XSL/Transform/java/oracle.tip.xref.xpath.XRefXPathFunctions"
                xmlns:wkcam="http://www.kallsony.com/operacion/consultacampania"
                xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                xmlns:ldap="http://schemas.oracle.com/xpath/extension/ldap"
                exclude-result-prefixes="xsi xsl soap ns1 tns ns2 ns0 wkcaf wkcam xsd xp20 bpws bpel bpm ora socket mhdr oraext dvm hwf med ids xdk xref ldap">
  <xsl:param name="VariableUnProduc"/>
  <xsl:template match="/">
    <ns2:unProductoCampania>
      <descuentoCampania>
        <xsl:value-of select="/ns2:unProductoCampania/descuentoCampania"/>
      </descuentoCampania>
      <productoCampania>
        <idProducto>
          <xsl:value-of select="/ns2:unProductoCampania/productoCampania/idProducto"/>
        </idProducto>
        <codigoProducto>
          <xsl:value-of select="$VariableUnProduc/ns1:UnProducto/codigoProducto"/>
        </codigoProducto>
        <nombreProducto>
          <xsl:value-of select="$VariableUnProduc/ns1:UnProducto/nombreProducto"/>
        </nombreProducto>
        <descripcionProducto>
          <xsl:value-of select="$VariableUnProduc/ns1:UnProducto/descripcionProducto"/>
        </descripcionProducto>
        <xsl:if test="$VariableUnProduc/ns1:UnProducto/fabricanteProducto">
          <fabricanteProducto>
            <xsl:value-of select="$VariableUnProduc/ns1:UnProducto/fabricanteProducto"/>
          </fabricanteProducto>
        </xsl:if>
        <xsl:if test="$VariableUnProduc/ns1:UnProducto/nombreImagenProducto">
          <nombreImagenProducto>
            <xsl:value-of select="$VariableUnProduc/ns1:UnProducto/nombreImagenProducto"/>
          </nombreImagenProducto>
        </xsl:if>
        <xsl:if test="$VariableUnProduc/ns1:UnProducto/precioProducto">
          <precioProducto>
            <xsl:value-of select="$VariableUnProduc/ns1:UnProducto/precioProducto"/>
          </precioProducto>
        </xsl:if>
        <tipoProducto>
          <categoria>
            <xsl:if test="$VariableUnProduc/ns1:UnProducto/tipoProducto/categoria/idTipo">
              <idTipo>
                <xsl:value-of select="$VariableUnProduc/ns1:UnProducto/tipoProducto/categoria/idTipo"/>
              </idTipo>
            </xsl:if>
            <xsl:if test="$VariableUnProduc/ns1:UnProducto/tipoProducto/categoria/nombreTipo">
              <nombreTipo>
                <xsl:value-of select="$VariableUnProduc/ns1:UnProducto/tipoProducto/categoria/nombreTipo"/>
              </nombreTipo>
            </xsl:if>
          </categoria>
          <subCategoria>
            <xsl:if test="$VariableUnProduc/ns1:UnProducto/tipoProducto/subCategoria/idTipo">
              <idTipo>
                <xsl:value-of select="$VariableUnProduc/ns1:UnProducto/tipoProducto/subCategoria/idTipo"/>
              </idTipo>
            </xsl:if>
            <xsl:if test="$VariableUnProduc/ns1:UnProducto/tipoProducto/subCategoria/nombreTipo">
              <nombreTipo>
                <xsl:value-of select="$VariableUnProduc/ns1:UnProducto/tipoProducto/subCategoria/nombreTipo"/>
              </nombreTipo>
            </xsl:if>
          </subCategoria>
        </tipoProducto>
      </productoCampania>
    </ns2:unProductoCampania>
  </xsl:template>
</xsl:stylesheet>
