namespace Tarea5.Models
{
    public class DetalleFacturaModel
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public float valor { get; set; }

        public int ProductoModelId { get; set; }
        public ProductoModel ProductoModel { get; set; }


        public int FacturaModelId { get; set; }
        public FacturaModel FacturaModel { get; set; }


        public int StockModelId { get; set; }
        public StockModel StockModel { get; set; }

    }
}