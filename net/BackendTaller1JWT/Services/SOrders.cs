using BackendTaller1.DA;
using BackendTaller1.Interfaces;
using Model.Entidades.Database;

namespace BackendTaller1.Services
{
    public class SOrders : IOrders
    {
        public ROrders dataget = new ROrders();
        public WOrders datapost = new WOrders();

        public IEnumerable<OrderPedido> ConsultarOrdenes()
        {
            return dataget.ConsultarOrdenes();
        }

        public IEnumerable<OrderPedido> ConsultarOrden(int idorder)
        {
            return dataget.ConsultarOrden(idorder);
        }

        public OrderPedido? ConsultarOrdenById(int idorden)
        {
            return dataget.ConsultarOrdenById(idorden);
        }

        public IEnumerable<OrderPedidoDetalle> ConsultarOrdenDetalle(int idorder)
        {
            return dataget.ConsultarOrdenDetalle(idorder);
        }

        public int GuardarOrden(OrderPedido item)
        {
            return datapost.GuardarOrden(item);
        }
    }
}
