using System;
using System.Collections.Generic;
using CodeLibrary.Models;

namespace CodeLibrary.Service
{
  class CodeLibraryService
  {
    public List<Book> books {get; set;}

    public string GetBooks(bool available)
    {
      string template = "";
      var list = books.FindAll(b => b.IsAvailable == available);
      for(int i =0; i < list.Count; i++)
      {
        var book = list[i];
          template += $"{i +1}. {book.Title} - by {book.Author} \n";
      }
      return template;
    }
    public CodeLibraryService()
    {
      books = new List<Book>(){
        new Book("DummyTitle","DummyAuthor", "Lorem", true),
        new Book("DummyTitle","DummyAuthor", "Lorem", true),
        new Book("DummyTitle","DummyAuthor", "Lorem", true),
        new Book("LostTitle","DummyAuthor", "Lorem", false),
        new Book("DummyTitle","DummyAuthor", "Lorem", true),
        new Book("DummyTitle","DummyAuthor", "Lorem", true)
      };

    }

    internal string Checkout(int selection)
    {
      var list = books.FindAll(b => b.IsAvailable == true);
      if (selection <= list.Count)
      {
        list[selection].IsAvailable = false;
        return $"enjoy {list[selection].Title}!";
      }
      return "Sorry Boss, thats not a real book";
    }

    internal string ReturnBook(int selection)
    {
      var list = books.FindAll(b => b.IsAvailable == false);
      if (selection <= list.Count)
      {
        list[selection].IsAvailable = true;
        return $"{list[selection].Title}!";
      }
      return "Sorry Boss, thats not a real book";
    }

    internal void AddBook(Book newBook)
    {
      books.Add(newBook);
    }
  }
}