<?xml version="1.0" encoding="UTF-8" ?>
<?oracle-xsl-mapper
  <!-- SPECIFICATION OF MAP SOURCES AND TARGETS, DO NOT MODIFY. -->
  <mapSources>
    <source type="WSDL">
      <schema location="../BPELEnvio.wsdl"/>
      <rootElement name="enviarCompraEntrada" namespace="http://www.kallsony.com/operacion/enviarcompra"/>
    </source>
  </mapSources>
  <mapTargets>
    <target type="WSDL">
      <schema location="../setDeprisaFile.wsdl"/>
      <rootElement name="ValidarDestinoEntrada" namespace="http://www.kallsony.com.destino.deprisa"/>
    </target>
  </mapTargets>
  <!-- GENERATED BY ORACLE XSL MAPPER 11.1.1.7.0(build 140919.1004.0161) AT [MON JUN 01 19:07:03 COT 2015]. -->
?>
<xsl:stylesheet version="1.0"
                xmlns:xp20="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.Xpath20"
                xmlns:bpws="http://schemas.xmlsoap.org/ws/2003/03/business-process/"
                xmlns:bpel="http://docs.oasis-open.org/wsbpel/2.0/process/executable"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:bpm="http://xmlns.oracle.com/bpmn20/extensions"
                xmlns:tns="http://xmlns.oracle.com/pcbpel/adapter/file/Appkallsonys/ProjectEnvio/setDeprisaFile"
                xmlns:client="http://xmlns.oracle.com/Appkallsonys/ProjectEnvio/BPELEnvio"
                xmlns:plnk="http://schemas.xmlsoap.org/ws/2003/05/partner-link/"
                xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/"
                xmlns:ora="http://schemas.oracle.com/xpath/extension"
                xmlns:ns2="http://www.kallsony.com/entidad/producto"
                xmlns:socket="http://www.oracle.com/XSL/Transform/java/oracle.tip.adapter.socket.ProtocolTranslator"
                xmlns:imp1="http://www.kallsony.com.destino.deprisa"
                xmlns:ns1="http://www.kallsony.com/operacion/enviarcompra"
                xmlns:mhdr="http://www.oracle.com/XSL/Transform/java/oracle.tip.mediator.service.common.functions.MediatorExtnFunction"
                xmlns:oraext="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.ExtFunc"
                xmlns:dvm="http://www.oracle.com/XSL/Transform/java/oracle.tip.dvm.LookupValue"
                xmlns:hwf="http://xmlns.oracle.com/bpel/workflow/xpath"
                xmlns:jca="http://xmlns.oracle.com/pcbpel/wsdl/jca/"
                xmlns:med="http://schemas.oracle.com/mediator/xpath"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ns3="http://www.kallsony.com/entidad/orden"
                xmlns:ids="http://xmlns.oracle.com/bpel/services/IdentityService/xpath"
                xmlns:ns4="http://www.kallsony.com/entidad/usuario"
                xmlns:xdk="http://schemas.oracle.com/bpel/extension/xpath/function/xdk"
                xmlns:xref="http://www.oracle.com/XSL/Transform/java/oracle.tip.xref.xpath.XRefXPathFunctions"
                xmlns:ns0="http://www.kallsony.com/entidad/direccion"
                xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                xmlns:ldap="http://schemas.oracle.com/xpath/extension/ldap"
                exclude-result-prefixes="xsi xsl client plnk wsdl ns2 ns1 ns3 ns4 ns0 xsd tns imp1 jca xp20 bpws bpel bpm ora socket mhdr oraext dvm hwf med ids xdk xref ldap xmlns">
  
  <xsl:output method="text" indent="yes"/>
  <xsl:strip-space elements="*"/>
  

  <xsl:template match="/">
    <imp1:ValidarDestinoEntrada>
      <imp1:encabezado>
        <xsl:value-of select='concat("|",/ns1:enviarCompraEntrada/ns1:idOrden,",",/ns1:enviarCompraEntrada/ns1:usuarioEnvio/apellido,",",/ns1:enviarCompraEntrada/ns1:usuarioEnvio/nombre,",",/ns1:enviarCompraEntrada/ns1:usuarioEnvio/direccion/numero,",",/ns1:enviarCompraEntrada/ns1:usuarioEnvio/direccion/idCiudad,",",/ns1:enviarCompraEntrada/ns1:usuarioEnvio/direccion/idDepartamento,",","1","|")'/>
      </imp1:encabezado>
      <xsl:value-of select="'&#13;'" />
      <imp1:items>
        <xsl:for-each select="/ns1:enviarCompraEntrada/ns1:orden/listaItems/items">
          <imp1:item>
            <imp1:detalle>
              <xsl:value-of select='concat("|",producto/idProducto,",",producto/nombreProducto,",",producto/precioProducto,",",cantidad,",",../../../ns1:idOrden,"|")'/>
            </imp1:detalle>
          </imp1:item>
         <xsl:value-of select="'&#13;'" />
        </xsl:for-each>
      </imp1:items>
    </imp1:ValidarDestinoEntrada>
  </xsl:template>
</xsl:stylesheet>
