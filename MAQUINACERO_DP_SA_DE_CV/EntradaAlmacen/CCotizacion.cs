using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAQUINACERO_DP_SA_DE_CV.Conexion;

namespace MAQUINACERO_DP_SA_DE_CV.Clases
{
    class CCotizacion
    {
        private Consultas CN = new Consultas();
        public DataTable getProductos()
        {
            DataTable tabla;
            tabla = CN.Consulta("SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as'Comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion, a.Kilogramos FROM Almacen as a RIGHT JOIN Producto as p ON a.Codigo = p.Codigo INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida INNER JOIN Medida as me2 ON me2.ID_medida = p.ID_medida2 ORDER BY f.Descripcion;");
            return tabla;
        }

        public DataTable getSetCotizacion()
        {
            DataTable tabla;
            tabla = CN.Consulta("SELECT p.Codigo, f.Tipo, f.Descripcion as Forma, ma.Descripcion as Material, p.Medida, me.Descripcion as Unidad, p.meComercial as'Comercial', me2.Descripcion as 'Unidad comercial', p.Precio, p.Ubicacion, a.Kilogramos FROM Almacen as a RIGHT JOIN Producto as p ON a.Codigo = p.Codigo INNER JOIN Forma as f ON f.ID_forma = p.ID_forma INNER JOIN Material as ma ON p.ID_material = ma.ID_material INNER JOIN Medida as me ON me.ID_medida = p.ID_medida INNER JOIN Medida as me2 ON me2.ID_medida = p.ID_medida2 WHERE p.Codigo = '' ORDER BY f.Descripcion;");
            return tabla;
        }
    }
}
