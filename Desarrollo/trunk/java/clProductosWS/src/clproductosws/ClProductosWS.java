/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clproductosws;

import com.wsproductos.ConsultaProductoEntrada;
import com.wsproductos.ConsultaProductoSalida;
import com.wsproductos.Filtro;
import com.wsproductos.Producto;
import com.wsproductos.ProductoDeralleFaltaProducto;
import java.util.List;

/**
 *
 * @author Diego
 */
public class ClProductosWS {

    public ClProductosWS() {

    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        ConsultaProductoEntrada consultaProductosEntrada = new ConsultaProductoEntrada();
        Filtro filtroProducto = new Filtro();
        filtroProducto.setPagina(1);
        filtroProducto.setValorFiltro("A");
        filtroProducto.setValorFiltro("televisor");
        consultaProductosEntrada.setFiltroProducto(filtroProducto);
        ConsultaProductoSalida salida = null;
        List<Producto> productosLista = null;

        try {
            salida = consultarProductos(consultaProductosEntrada);

            if (salida != null) {
                if (salida.getRespuestaFiltro() != null) {
                    System.out.println("Pagina " + salida.getRespuestaFiltro().getPagina());
                    System.out.println("Total Registros " + salida.getRespuestaFiltro().getTotalElementos());
                }
                productosLista = salida.getListaProductos().getProducto();
                if (productosLista != null) {
                    System.out.println("Numero Productos " + productosLista.size());
                    for (Producto produc : productosLista) {
                        System.out.println("Producto " + produc);
                    }
                }
            }

        } catch (ProductoDeralleFaltaProducto ex) {
            System.out.println("ProductoDeralleFaltaProducto " + ex.getFaultInfo().getIdError());
        } catch (Exception e) {
            System.out.println("error " + e);
        }
        System.out.println("Termino");
    }

    private static ConsultaProductoSalida consultarProductos(com.wsproductos.ConsultaProductoEntrada consultaProductosEntrada) throws ProductoDeralleFaltaProducto {

        com.wsproductos.ProductosPort_Service service = new com.wsproductos.ProductosPort_Service();

        com.wsproductos.ProductosPort port = service.getProductosPortPort();

        return port.consultarProductos(consultaProductosEntrada);
    }

}
