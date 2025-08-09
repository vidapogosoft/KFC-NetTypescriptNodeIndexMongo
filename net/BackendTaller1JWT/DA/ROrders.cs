using Model.Entidades.Database;

namespace BackendTaller1.DA
{
    public class ROrders
    {

        public List<OrderPedido> ConsultarOrdenes()
        {

            using (var context = new HandHeldContext())
            {
                return context.OrderPedidos.Where(a=> a.Estado == "ACTIVO").OrderByDescending(a=> a.FechaIngreso).Take(15).ToList();
            }

        }

        public List<OrderPedido> ConsultarOrden(int idorder)
        {

            
            {using (var context = new HandHeldContext())
                return context.OrderPedidos.Where(a => a.Estado == "ACTIVO" && a.IdOrderCab == idorder).ToList();
            }

        }

        public OrderPedido? ConsultarOrdenById(int idorder)
        {

            using (var context = new HandHeldContext())
            {
                return context.OrderPedidos.Where(a => a.Estado == "ACTIVO" && a.IdOrderCab == idorder).FirstOrDefault();
            }

        }

        public List<OrderPedidoDetalle> ConsultarOrdenDetalle(int idorder)
        {

            using (var context = new HandHeldContext())
            {
                return context.OrderPedidoDetalles.Where(a => a.Estado == "ACTIVO" && a.IdOrderCab == idorder).ToList();
            }

        }
    }
}
