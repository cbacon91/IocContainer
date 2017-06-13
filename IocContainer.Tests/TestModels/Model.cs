namespace IocContainer.Tests.TestModels
{
  class Model : IModel
  {
    public int Id { get; set; }
    public int SetId(int id)
    {
      return Id = id;
    }
  }
}
