<?xml version="1.0" encoding="UTF-8" ?>
<?oracle-xsl-mapper
  <!-- SPECIFICATION OF MAP SOURCES AND TARGETS, DO NOT MODIFY. -->
  <mapSources>
    <source type="WSDL">
      <schema location="../getUsuario.wsdl"/>
      <rootElement name="UsuarioCollection" namespace="http://xmlns.oracle.com/pcbpel/adapter/db/top/getUsuario"/>
    </source>
  </mapSources>
  <mapTargets>
    <target type="WSDL">
      <schema location="../BPELGuardarCompra.wsdl"/>
      <rootElement name="unUsuario" namespace="http://www.kallsony.com/entidad/orden"/>
    </target>
  </mapTargets>
  <!-- GENERATED BY ORACLE XSL MAPPER 11.1.1.7.0(build 140919.1004.0161) AT [SUN MAY 31 08:30:12 COT 2015]. -->
?>
<xsl:stylesheet version="1.0"
                xmlns:xp20="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.Xpath20"
                xmlns:bpws="http://schemas.xmlsoap.org/ws/2003/03/business-process/"
                xmlns:bpel="http://docs.oasis-open.org/wsbpel/2.0/process/executable"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:ns2="http://www.kallsony.com/entidad/compra"
                xmlns:ns4="http://www.kallsony.com/entidad/tarjeta"
                xmlns:bpm="http://xmlns.oracle.com/bpmn20/extensions"
                xmlns:plt="http://schemas.xmlsoap.org/ws/2003/05/partner-link/"
                xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/"
                xmlns:ns3="http://www.kallsony.com/entidad/producto"
                xmlns:ora="http://schemas.oracle.com/xpath/extension"
                xmlns:socket="http://www.oracle.com/XSL/Transform/java/oracle.tip.adapter.socket.ProtocolTranslator"
                xmlns:tns="http://xmlns.oracle.com/pcbpel/adapter/db/Appkallsonys/ProjectGuardarOrden/getUsuario"
                xmlns:mhdr="http://www.oracle.com/XSL/Transform/java/oracle.tip.mediator.service.common.functions.MediatorExtnFunction"
                xmlns:oraext="http://www.oracle.com/XSL/Transform/java/oracle.tip.pc.services.functions.ExtFunc"
                xmlns:dvm="http://www.oracle.com/XSL/Transform/java/oracle.tip.dvm.LookupValue"
                xmlns:hwf="http://xmlns.oracle.com/bpel/workflow/xpath"
                xmlns:med="http://schemas.oracle.com/mediator/xpath"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:ids="http://xmlns.oracle.com/bpel/services/IdentityService/xpath"
                xmlns:ns1="http://www.kallsony.com/entidad/orden"
                xmlns:client="http://www.kallsony.com/operacion/guardarcompra"
                xmlns:ns5="http://www.kallsony.com/entidad/usuario"
                xmlns:xdk="http://schemas.oracle.com/bpel/extension/xpath/function/xdk"
                xmlns:xref="http://www.oracle.com/XSL/Transform/java/oracle.tip.xref.xpath.XRefXPathFunctions"
                xmlns:ns0="http://www.kallsony.com/entidad/direccion"
                xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                xmlns:top="http://xmlns.oracle.com/pcbpel/adapter/db/top/getUsuario"
                xmlns:ldap="http://schemas.oracle.com/xpath/extension/ldap"
                exclude-result-prefixes="xsi xsl plt wsdl tns xsd top ns2 ns4 ns3 ns1 client ns5 ns0 xp20 bpws bpel bpm ora socket mhdr oraext dvm hwf med ids xdk xref ldap">
  <xsl:template match="/">
    <ns1:unUsuario>
      <idUsuario>
        <xsl:value-of select="/top:UsuarioCollection/top:Usuario/top:idusuario"/>
      </idUsuario>
      <nombreUsuario>
        <xsl:value-of select="/top:UsuarioCollection/top:Usuario/top:username"/>
      </nombreUsuario>
      <nombre>
        <xsl:value-of select="/top:UsuarioCollection/top:Usuario/top:nombres"/>
      </nombre>
      <apellido>
        <xsl:value-of select="/top:UsuarioCollection/top:Usuario/top:apellidos"/>
      </apellido>
      <tipoDocumento>
        <xsl:value-of select="/top:UsuarioCollection/top:Usuario/top:tipodocumento"/>
      </tipoDocumento>
      <numeroDocumento>
        <xsl:value-of select="/top:UsuarioCollection/top:Usuario/top:numerodocumento"/>
      </numeroDocumento>
      <correoElectronico>
        <xsl:value-of select="/top:UsuarioCollection/top:Usuario/top:email"/>
      </correoElectronico>
      <telefono>
        <xsl:value-of select="/top:UsuarioCollection/top:Usuario/top:telefono"/>
      </telefono>
      <direccion>
        <idDireccion>
          <xsl:value-of select="/top:UsuarioCollection/top:Usuario/top:iddireccion"/>
        </idDireccion>
      </direccion>
      <idCategoria>
        <xsl:value-of select="/top:UsuarioCollection/top:Usuario/top:idcategoria"/>
      </idCategoria>
    </ns1:unUsuario>
  </xsl:template>
</xsl:stylesheet>
