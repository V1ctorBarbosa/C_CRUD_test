
namespace CrudTest
{
    class Program
    {
        //Aqui estamos dizendo que vamos ter uma lista do tipo Dogs (que é a nossa classe ali em cima.) Essa lista vai se chamar Dogs e começa como um array vazio
        static readonly List<Dogs> DogsList = [];

        //Main é um método que é iniciado toda vez que uma aplicação C# é rodada. Então, no dotnet run, esse método vai rodar
        static void Main()
        {
            //mostrar o menu quando a aplicação rodar até o momento em que o usuário saia
            bool displayMenu = true;

            //Laço de repetição. Só quando o cara apertar sair que a aplicação vai parar
            while (displayMenu)
            {
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1. Listar cachorros");
                Console.WriteLine("2. Adicionar cachorro");
                Console.WriteLine("3. Atualizar cachorro");
                Console.WriteLine("4. Deletar cachorro");
                Console.WriteLine("5. Sair");

                //Essa linha é o seguinte: a gente vai tentar parsear o que o usuário digitou no console para um int.
                //Se der certo, ela vai out esse inteiro que é a nossa option que cai no switch case
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            ListDogs();
                            break;
                        case 2:
                            AddDog();
                            break;
                        case 3:
                            UpdateDog();
                            break;
                        case 4:
                            DeleteDog();
                            break;
                        case 5:
                            displayMenu = false; // Altera a variável para sair do loop
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }
                }
                else
                {
                    //Caso o usuário escreva algo além das opções que eu dei
                    Console.WriteLine("Opção inválida");
                }
                //Aqui o usuário escreve
                Console.WriteLine();
            }
        }

        static void ListDogs()
        {
            //Verifica se tem algum cachorro
            if (DogsList.Count == 0)
            {
                Console.WriteLine("Não tem nenhum cachorro por aqui");
            }
            else
            {
                //Aqui é TIPO + elemento em questão + ARRAY dos dados
                foreach (Dogs dog in DogsList)
                {
                    Console.WriteLine($"Nome: {dog.Name}, Idade: {dog.Age}");
                }
            }
        }

        static void AddDog()
        {
            Console.WriteLine("Qual o nome do cachorro?");
            // Vamos pegar o nome do cachorro no que o usuário digitou
            string? newDogName = Console.ReadLine();

            Console.WriteLine("Qual a idade");
            //Mesma coisa que é na hora de selecionar a opção, Vitão. Vamos tentar parsear o que o cara digitou. Se rolar, vamos out um int com idade do cachorro
            if (int.TryParse(Console.ReadLine(), out int newDogAge))
            {
                //Aqui vamos usar o método add para adicionar um novo dado ao nosso Dogs. E o que esse dado vai ser? Um novo Dogs(classe) que vai levar o que o usuário digitou
                DogsList.Add(new Dogs { Name = newDogName, Age = newDogAge });
                Console.WriteLine("Novo cachorrão na área");
            }
            else
            {
                Console.WriteLine("Cachorro estranho. Não adicionado");
            }

        }

        static void UpdateDog()
        {
            //Aqui a gente vai pegar o nome do cachorro que vai ser atualizado
            Console.WriteLine("Qual o nome do cachorro que deseja atualizar?");
            string? dogName = Console.ReadLine();

            //Aqui, criamos uma variável do tipo Dogs (que pode ser nula) chamada dogToUpdate. É como se fosse o filter do JS
            //Vamos pegar a nosso array DogsList e verificar se algum dos nomes que tem lá são == ao nomes que o usuário digitou
            Dogs? dogToUpdate = DogsList.FirstOrDefault(dog => dog.Name == dogName);

            if (dogToUpdate != null)
            {
                //Caso o cara tenha digitado um nome válido, vamos apresentar os dados a serem alterados e dar a nova opção de nome do cachorro
                Console.WriteLine($"Nome atual: {dogToUpdate.Name}, Idade atual: {dogToUpdate.Age}");
                Console.WriteLine("Qual o novo nome do cachorro?");
                string? newDogName = Console.ReadLine();

                //Aqui é a nova idade, e é claro que precisamos aplicar o tryParse
                Console.WriteLine("Qual a nova idade do cachorro?");
                if (int.TryParse(Console.ReadLine(), out int newDogAge))
                {
                    // Atualizar os dados do cachorro selecionado
                    dogToUpdate.Name = newDogName;
                    dogToUpdate.Age = newDogAge;
                    Console.WriteLine("Dados do cachorro atualizados com sucesso!");
                }
                else
                {
                    //Caso a idade seja inválida
                    Console.WriteLine("Idade inválida. Dados do cachorro não atualizados.");
                }
            }
            else
            {
                //Caso não tenha um cachorro com o nome fornecido
                Console.WriteLine("Cachorro não encontrado.");
            }
        }


        static void DeleteDog()
        {
            //Mesma coisa, Vitão. Separa o nome do cachorro que o usuário digitou
            Console.WriteLine("Qual o nome do cachorro a ser deletado?");
            string? dogName = Console.ReadLine();

            //Encontra ele na lista
            Dogs? dogToDelete = DogsList.FirstOrDefault(dog => dog.Name == dogName);

            if (dogToDelete != null)
            {
                //Se o nome for achado, deleta ele usando o método .Remove
                DogsList.Remove(dogToDelete);
                Console.WriteLine("O cachorro foi deletado");
            }
            else
            {
                Console.WriteLine("Cachorro não encontrado");
            }

        }
    }
}
