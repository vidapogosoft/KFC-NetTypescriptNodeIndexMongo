using Model.Entidades.Database;

namespace BackendTaller1.DA
{
    public class WOrders
    {

        public int GuardarOrden(OrderPedido item)
        {

            using (var context = new HandHeldContext())
            {

                context.OrderPedidos.Add(item);
                context.SaveChanges();

                return item.IdOrderCab;
            }


        }

    }
}
