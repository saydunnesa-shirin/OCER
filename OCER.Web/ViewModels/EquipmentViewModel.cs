namespace OCER.Web.ViewModels
{
    public class EquipmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EquipmentType { get; set; }
        public int Days { get; set; }
        public bool InStock { get; set; }
        public int EquipmentTypeId { get; set; }
        public string Description { get; set; }
    }
}
