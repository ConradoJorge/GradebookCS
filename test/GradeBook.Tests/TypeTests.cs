using System;
using Xunit;


namespace GradeBook.Tests
{
    public class TypeTests
    {

        [Fact]
        public void StringsBehaveLikeValueTypes(){
            string name = "Scott";
            var upper = MakeUppercase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private String MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void Test1(){
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]

        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
        
        [Fact]
        public void GetBookResturnsDifferentObjects()
        {
            //Arrange   
            var bookOne = GetBook("Book 1");
            var bookTwo = GetBook("Book 2");
        
            //Act



            //Assert
            Assert.Equal("Book 1", bookOne.Name);
            Assert.Equal("Book 2", bookTwo.Name);
        }



        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var bookOne = GetBook("Book 1");
            var bookTwo = bookOne;

        
            //Act



            //Assert
            Assert.Same(bookOne, bookTwo);
            Assert.True(Object.ReferenceEquals(bookOne, bookTwo));
       
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }


        private void SetName(Book book, string name)
        {
            book.Name = name;
        }
        
    }
}
