using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using KB2C.Data;
using KB2C.Data.Interface;
using KB2C.Business;
using KB2C.Business.Interface;

namespace DependencyInjector
{
    public static class UnityInjector
    {
        public static void DependencyLoader(IUnityContainer container)
        {
            //container.RegisterType<IBusiness, ClienteBL>();
            //container.RegisterType<IData, ClienteDAL>();
            container.RegisterType<IBusiness.ICampaniaBL, CampaniaBL>();
            container.RegisterType<IBusiness.ICategoriaBL, CategoriaBL>();
            container.RegisterType<IBusiness.ICompraBL, CompraBL>();
            container.RegisterType<IBusiness.IOrdenBL, OrdenBL>();
            container.RegisterType<IBusiness.IProductoBL, ProductoBL>();

            container.RegisterType<IData.ICampaniaDAL, CampaniaDAL>();
            container.RegisterType<IData.ICategoriaDAL, CategoryDAL>();
            container.RegisterType<IData.ICompraDAL, CompraDAL>();
            container.RegisterType<IData.IOrdenDAL, OrdenDAL>();
            container.RegisterType<IData.IProductoDAL, ProductoDAL>();

        }
    }
}
