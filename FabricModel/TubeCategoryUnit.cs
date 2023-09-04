namespace FabricModel
{
    public class TubeCategoryUnit
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public float? Tube_weight { get; set; }  // 可為null的浮點數
        public float? Tube_price { get; set; }   // 可為null的浮點數
    }
}
