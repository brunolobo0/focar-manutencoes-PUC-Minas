namespace Api_Orcamento.Models
{
    public class BudgetManagerDataBaseSettings
    {
        public string ConnectionStrings { get; set; } = null!;
        public string DataBaseName { get; set; } = null!;
        public string BudgetCollectionSolicitation { get; set; } = null!;
        public string BudgetCollectionBudget { get; set; } = null!;
        public string BudgetCollectionUsers { get; set; } = null!;
        public string BudgetCollectionCustomer { get; set; } = null!;
        public string BudgetCollectionSupplier { get; set; } = null!;
        public string BudgetCollectionProduct { get; set; } = null!;

    }
}