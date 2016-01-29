<?xml version="1.0" encoding="UTF-8" ?>
<?oracle-xsl-mapper
  <!-- SPECIFICATION OF MAP SOURCES AND TARGETS, DO NOT MODIFY. -->
  <mapSources>
    <source type="WSDL">
      <schema location="../getCategorias.wsdl"/>
      <rootElement name="CategoriaCollection" namespace="http://xmlns.oracle.com/pcbpel/adapter/db/top/getCategorias"/>
    </source>
  </mapSources>
  <mapTargets>
    <target type="WSDL">
      <schema location="../Categorias.wsdl"/>
      <rootElement name="consultaCategoriaSalida" namespace="http://www.kallsony.com/operacion/consultarcategorias"/>
    </target>
  </mapTargets>
  <!-- GENERATED BY ORACLE XSL MAPPER 11.1.1.7.0(build 140919.1004.0161) AT [MON MAR 16 16:27:20 COT 2015]. -->
?>
<xsl:stylesheet version="1.0"
                xmlns:xp20="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.Xpath20"
                xmlns:bpws="http://schemas.xmlsoap.org/ws/2003/03/business-process/"
                xmlns:bpel="http://docs.oasis-open.org/wsbpel/2.0/process/executable"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:bpm="http://xmlns.oracle.com/bpmn20/extensions"
                xmlns:tns="http://xmlns.oracle.com/pcbpel/adapter/db/kallSonysApp/categorias/getCategorias"
                xmlns:plt="http://schemas.xmlsoap.org/ws/2003/05/partner-link/"
                xmlns:top="http://xmlns.oracle.com/pcbpel/adapter/db/top/getCategorias"
                xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/"
                xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/"
                xmlns:ora="http://schemas.oracle.com/xpath/extension"
                xmlns:socket="http://www.oracle.com/XSL/Transform/java/oracle.tip.adapter.socket.ProtocolTranslator"
                xmlns:wkct="http://www.kallsony.com/operacion/consultarcategorias"
                xmlns:mhdr="http://www.oracle.com/XSL/Transform/java/oracle.tip.mediator.service.common.functions.MediatorExtnFunction"
                xmlns:oraext="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.ExtFunc"
                xmlns:dvm="http://www.oracle.com/XSL/Transform/java/oracle.tip.dvm.LookupValue"
                xmlns:hwf="http://xmlns.oracle.com/bpel/workflow/xpath"
                xmlns:ns2="http://www.kallsony.com/entidad/categoria"
                xmlns:ns1="http://www.kallsony.com/util/filtro"
                xmlns:med="http://schemas.oracle.com/mediator/xpath"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ids="http://xmlns.oracle.com/bpel/services/IdentityService/xpath"
                xmlns:ns0="http://www.kallsony.com/final/operacion/consultacategorias"
                xmlns:wkctf="http://www.kallsony.com/util/falta"
                xmlns:xdk="http://schemas.oracle.com/bpel/extension/xpath/function/xdk"
                xmlns:xref="http://www.oracle.com/XSL/Transform/java/oracle.tip.xref.xpath.XRefXPathFunctions"
                xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                xmlns:ldap="http://schemas.oracle.com/xpath/extension/ldap"
                exclude-result-prefixes="xsi xsl tns plt top wsdl xsd soap wkct ns2 ns1 ns0 wkctf xp20 bpws bpel bpm ora socket mhdr oraext dvm hwf med ids xdk xref ldap">
  <xsl:template match="/">
    <wkct:consultaCategoriaSalida>
      <wkct:listaCategorias>
        <xsl:for-each select="/top:CategoriaCollection/top:Categoria">
          <categoria>
            <tipoCategoria>
              <idTipo>
                <xsl:value-of select="top:IdCategoria"/>
              </idTipo>
              <nombreTipo>
                <xsl:value-of select="top:NombreCategoria"/>
              </nombreTipo>
            </tipoCategoria>
            <listaSubCategorias>
              <xsl:for-each select="top:SubcategoriaCollection/top:Subcategoria">
                <subCategoria>
                  <tipoSubCategoria>
                    <idTipo>
                      <xsl:value-of select="top:IdSubcategoria"/>
                    </idTipo>
                    <nombreTipo>
                      <xsl:value-of select="top:NombreSubcategoria"/>
                    </nombreTipo>
                  </tipoSubCategoria>
                </subCategoria>
              </xsl:for-each>
            </listaSubCategorias>
          </categoria>
        </xsl:for-each>
      </wkct:listaCategorias>
    </wkct:consultaCategoriaSalida>
  </xsl:template>
</xsl:stylesheet>
