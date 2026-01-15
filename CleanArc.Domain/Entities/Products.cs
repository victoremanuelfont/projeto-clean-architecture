namespace CleanArc.Domain.Entities;

// "sealed" melhora a performance e indica que ninguém herda dessa classe
public sealed class Product
{
    // Propriedades são "private set". Isso significa que ninguém de fora pode mudar o ID ou Nome 
    // diretamente (ex: produto.Name = ""). Eles são obrigados a usar os métodos ou construtores.
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }

    // Construtor 1: Usado quando vamos CRIAR um produto novo (ainda não tem ID)
    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    // Construtor 2: Usado pelo Entity Framework ou quando buscamos do Banco (já tem ID)
    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        if (id < 0) throw new ArgumentException("Invalid Id value");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }

    // Método para atualizar os dados (substitui os 'Setters' públicos)
    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    // O coração da Clean Architecture: A validação fica AQUI, não no Front-end ou no Banco.
    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        if (string.IsNullOrEmpty(name) || name.Length < 3)
            throw new ArgumentException("Nome inválido. O nome é obrigatório e deve ter no mínimo 3 caracteres");

        if (string.IsNullOrEmpty(description) || description.Length < 5)
            throw new ArgumentException("Descrição inválida. Mínimo de 5 caracteres");

        if (price < 0)
            throw new ArgumentException("Preço inválido");

        if (stock < 0)
            throw new ArgumentException("Estoque inválido");

        // Se passou por tudo, aí sim atribuímos os valores
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }
}