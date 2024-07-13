 namespace ReductioAndAbsurdum
 {
    public class ProductType
        {
            public int? Id { get; set; }
            public string? Name { get; set; }

            public ProductType(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
 }