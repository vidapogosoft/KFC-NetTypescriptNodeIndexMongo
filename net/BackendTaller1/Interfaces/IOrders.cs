
using Model.Entidades.Database;

namespace BackendTaller1.Interfaces
{
    public interface IOrders
    {

        //Get
        //Colecciones
        IEnumerable<OrderPedido> ConsultarOrdenes();
        IEnumerable<OrderPedido> ConsultarOrden(int idorder);
        IEnumerable<OrderPedidoDetalle> ConsultarOrdenDetalle(int idorder);

        //Objetos
        OrderPedido? ConsultarOrdenById(int idorden);


        //Post
        int GuardarOrden(OrderPedido item);
    }
}
