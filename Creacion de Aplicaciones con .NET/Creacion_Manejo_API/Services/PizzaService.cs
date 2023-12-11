using Creacion_Manejo_API.Models;

namespace Creacion_Manejo_API.Services;

public static class PizzaService{
    static List<Pizza> pizzas{get;}
    static int nextId = 3;
    static PizzaService(){
        pizzas = new List<Pizza>{
            new Pizza {ID = 1, nameof = "Classic Italian", IsGlutenFree = false},
            new Pizza {ID = 2, name = "Veggie", IsGlutenFree = true}
        };
    }

    public static List<Pizza> GetAll => pizzas;
    public static Pizza? Get(int id) => pizzas.FirstOrDefault(p => p.ID == id);
    public static void Add(Pizza pizza){
        pizza.ID = nextId++;
        Pizza.Add(pizza);
    }
    public static void Delete(int id){
        var pizza = Get(id);
        if(pizza is null)
            return;
        
        pizza.remove(pizza);
    }
    public static void Update(Pizza pizza){
        var index = Pizzas.FindIndex(p => p.ID == pizza.ID);
        if(index == -1)
            return;
        
        pizza[index] = pizza;
    }
}