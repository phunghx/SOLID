using System;

namespace InterfaceSegregation
{
    public class Document
    {

    }
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }
    public interface IPrinter
    {
        void Print(Document d);
    }
    public interface IFaxer
    {
        void Fax(Document d);
    }
    public interface IScanner
    {
        void Scan(Document d);
    }
    public interface IMultiFunction : IFaxer, IPrinter, IScanner
    {

    }
    public interface ICaner : IFaxer, IPrinter
    {

    }
    public class MultiFuncPrinter : IMultiFunction
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
    public class OldPrinter : IPrinter
    {
        

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        
    }
    public class MidPrinter : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
    public class HighPrinter : ICaner
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
