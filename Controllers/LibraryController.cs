using System;
using CodeLibrary.Models;
using CodeLibrary.Service;

namespace CodeLibrary.Controllers
{
  public class LibraryController
  {
    private CodeLibraryService _service {get; set;} = new CodeLibraryService();
    private bool _Running {get; set;}= true;
    public void Run(){
      while (_Running){
        GetUserImput();
      }
    }

    private void GetUserImput()
    {
      System.Console.WriteLine("Please select \n 1. (R)ead \n 2. (C)heckout \n 3. Re(t)urn \n 4. (A)dd \n 5. (D)elete \n 6. (Q)uit \n");
      string choice = Console.ReadLine().ToLower();
      switch (choice)
      {
        case "1":
        case "r":
        case "read":
          Read();
          break;
        case "2":
        case "c":
        case "checkout":
          Checkout();
          break;
        case "3":
        case "t":
        case "return":
          ReturnBook();
          break;
        case "4":
        case "a":
        case "add":
          AddBook();
          break;
        case "5":
        case "d":
        case "delete":
          DeleteBook();
          break;
        case "6":
        case "q":
        case "quit":
          quit();
          break;
        default:
          Console.WriteLine("Sorry didnt catch that, I'd ask you to speak up but I haven't got ears");
          break;
      }
    }

    private void AddBook()
    {
      System.Console.Write("Title: ");
      string title = Console.ReadLine();
      System.Console.Write("Author: ");
      string author = Console.ReadLine();
      System.Console.Write("Description: ");
      string description = Console.ReadLine();
      bool isAvailable = true;
      Book newBook = new Book(title, author, description, isAvailable);
      _service.AddBook(newBook);
    }

    private void quit()
    {
      throw new NotImplementedException();
    }

    private void DeleteBook()
    {
      throw new NotImplementedException();
    }

    private void ReturnBook()
    {
      Console.WriteLine(_service.GetBooks(false));
      Console.WriteLine("What book are you dropping off?");
      string userImput = Console.ReadLine();
      if(int.TryParse(userImput, out int selection) && selection > 0)
      {
        string response = _service.ReturnBook(selection - 1);
        Console.WriteLine("thanks for brining back" + response);
      }
      else System.Console.WriteLine("I need you to use a number from the list if I'm to help you");
    }

    private void Checkout()
    {
      Console.WriteLine(_service.GetBooks(true));
      Console.WriteLine("Intrested in anything you see?");
      string userImput = Console.ReadLine();
      if(int.TryParse(userImput, out int selection) && selection > 0)
      {
        string response = _service.Checkout(selection - 1);
        Console.WriteLine(response + "\n Please remember to bring that back");
      }
      else System.Console.WriteLine("I need you to use a number from the list if I'm to help you");
    }

    private void Read()
    {
      throw new NotImplementedException();
    }
  }
}
