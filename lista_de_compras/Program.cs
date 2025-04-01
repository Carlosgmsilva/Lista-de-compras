namespace ListaDeCompras;
using System.IO;

public class Program
{
    public static void Main()
    {
        string path = @"C:\Users\PC USER\Desktop\lista_de_compras\lista_de_compras\lista";
        string fileName = "listas_de_compras.txt";
        string filePath = path + fileName;

        List<string> shoopingList = new List<string>();

        if (File.Exists(filePath))
        {    

            shoopingList.AddRange(File.ReadAllLines(filePath));
        }

        while (true)
        {
            Console.WriteLine("\n== Lista de Compras ==");
            Console.WriteLine("1. Adicionar item");
            Console.WriteLine("2. Remover item item");
            Console.WriteLine("3. Listar itens");
            Console.WriteLine("4. Sair");
            Console.WriteLine("Escolha um número para continuar: ");

            string choiceUser = Console.ReadLine();

            switch (choiceUser)
            {
                case "1":
                    Console.WriteLine("Digite o nome do item para adiconar: ");
                    string itemInsert = Console.ReadLine();
                    if (!string.IsNullOrEmpty(itemInsert))
                    {
                        shoopingList.Add(itemInsert);
                        Console.WriteLine($"Item '{itemInsert}' adicionado com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("O item não pode ser vazio");
                    }
                    break;

                case "2":
                    Console.WriteLine("Digite o nome do item a ser removido");
                    string itemToRemove = Console.ReadLine();

                    if (shoopingList.Remove(itemToRemove))
                    {
                        Console.WriteLine($"Item '{itemToRemove}' Removido com sucesso");
                    }
                    else
                    {
                        Console.WriteLine($"Item '{itemToRemove}' não encontrado!");
                    }
                    break;

                case "3":
                    Console.WriteLine("\n Itens na sua lista de compras: ");

                    if (shoopingList.Count == 0)
                    {
                        Console.WriteLine("Sua lista está vazia");
                    }
                    else
                    {
                        for (int i = 0; i < shoopingList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {shoopingList[i]}");
                        }
                    }
                    break;
                case "4":
                    File.WriteAllLines(filePath, shoopingList);
                    Console.WriteLine("Lista Salva com sucesso! Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção invlida. Tente novamente");
                    break;
            }
        }

    }
}