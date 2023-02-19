                  
                   /*******************************
                   *                              *
                   *    Старикова Алина ПИ-221    *
                   *            "ООП"             *
                   *                              * 
                   *******************************/

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DocumentMenu {
    public sealed class DocumentWork {
        private static readonly DocumentWork instance = new DocumentWork();
        private List<Document> documents = new List<Document>();
        private DocumentWork() { }

        public static DocumentWork Instance {
            get { return instance; }
        }

        public void AddDocument(Document doc) {
            documents.Add(doc);
        }

        public void RemoveDocument(Document doc) {
            documents.Remove(doc);
        }

        public void Menu() {
            Console.WriteLine(" 1 - добавить док-т");
            Console.WriteLine(" 2 - удалить док-т");
            Console.WriteLine(" 3 - список док-в");
            Console.WriteLine(" 4 - закончить");
            string choice = Console.ReadLine();
            switch(choice) {
                case "1":
                    AddDocumentMenu();
                    break;
                case "2":
                    RemoveDocumentMenu();
                    break;
                case "3":
                    ListAllDocumentsMenu();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(" неправильно! попробуй еще раз :(");
                    break;
            }
            Menu();
        }
        private void AddDocumentMenu() {
            Console.WriteLine(" введите название док-та:");
            string name = Console.ReadLine();

            Console.WriteLine(" введите автора док-та:");
            string author = Console.ReadLine();

            Console.WriteLine(" введите ключевые слова через запятую:");
            string[] keywords = Console.ReadLine().Split(',');

            Console.WriteLine(" введите тему док-та:");
            string subject = Console.ReadLine();

            Console.WriteLine(" введите путь к файлу док-та:");
            string filePath = Console.ReadLine();

            Console.WriteLine(" выберите тип док-та:");
            Console.WriteLine(" 1 - MS Word");
            Console.WriteLine(" 2 - PDF");
            Console.WriteLine(" 3 - MS Excel");
            Console.WriteLine(" 4 - TXT");
            Console.WriteLine(" 5 - HTML");

            string choice = Console.ReadLine();
            switch(choice) {
                case "1":
                    documents.Add(new MSWordDocument(name, author, keywords, subject, filePath));
                    break;
                case "2":
                    documents.Add(new PDFDocument(name, author, keywords, subject, filePath));
                    break;
                case "3":
                    documents.Add(new MSExcelDocument(name, author, keywords, subject, filePath));
                    break;
                case "4":
                    documents.Add(new TXTDocument(name, author, keywords, subject, filePath));
                    break;
                case "5":
                    documents.Add(new HTMLDocument(name, author, keywords, subject, filePath));
                    break;
                default:
                    Console.WriteLine(" неправильно! попробуй еще раз :(");
                    break;
            }
        }
        private void RemoveDocumentMenu() {
            Console.WriteLine(" введите название док-та, который вы хотите удалить:");
            string name = Console.ReadLine();

            Document doc = documents.Find(d => d.Name == name);
            if(doc != null) {
                documents.Remove(doc);
                Console.WriteLine(" док-т удален!");
            }
            else {
                Console.WriteLine(" такого док-та не существует!");
            }
        }
        private void ListAllDocumentsMenu() {
            Console.WriteLine(" показать список док-в:");
            foreach(Document doc in documents) {
                Console.WriteLine(doc.Info());
            }
        }
    }
    public abstract class Document {
        public string Name { get; set; }
        public string Author { get; set; }
        public string[] Keywords { get; set; }
        public string Subject { get; set; }
        public string FilePath { get; set; }
        public Document(string name, string author, string[] keywords, string subject, string filePath) {
            Name = name;
            Author = author;
            Keywords = keywords;
            Subject = subject;
            FilePath = filePath;
        }
        public abstract string Info();
    }
    public class MSWordDocument : Document {
        public MSWordDocument(string name, string author, string[] keywords, string subject, string filePath)
            : base(name, author, keywords, subject, filePath) {
        }
        public override string Info() {
            return $" MS Word док-т - {Name}. автор - {Author}. ключевые слова - {string.Join(",", Keywords)}. тема - {Subject}. путь файла - {FilePath}";
        }
    }

    public class PDFDocument : Document {
        public PDFDocument(string name, string author, string[] keywords, string subject, string filePath)
            : base(name, author, keywords, subject, filePath) {
        }
        public override string Info() {
            return $" PDF док-т - {Name}. автор - {Author}. ключевые слова - {string.Join(",", Keywords)}. тема - {Subject}. путь файла - {FilePath}";
        }
    }

    public class MSExcelDocument : Document {
        public MSExcelDocument(string name, string author, string[] keywords, string subject, string filePath)
            : base(name, author, keywords, subject, filePath) {
        }
        public override string Info() {
            return $" MS Excel док-т - {Name}. автор - {Author}. ключевые слова - {string.Join(",", Keywords)}. тема - {Subject}. путь файла - {FilePath}";
        }
    }

    public class TXTDocument : Document {
        public TXTDocument(string name, string author, string[] keywords, string subject, string filePath)
            : base(name, author, keywords, subject, filePath) {
        }
        public override string Info() {
            return $" TXT док-т - {Name}. автор - {Author}. ключевые слова - {string.Join(",", Keywords)}. тема - {Subject}. путь файла - {FilePath}";
        }
    }

    public class HTMLDocument : Document {
        public HTMLDocument(string name, string author, string[] keywords, string subject, string filePath)
            : base(name, author, keywords, subject, filePath) {
        }
        public override string Info() {
            return $" HTML док-т - {Name}. автор - {Author}. ключевые слова - {string.Join(",", Keywords)}. тема - {Subject}. путь файла - {FilePath}";
        }
    }
    class Program {
        static void Main(string[] args) {
            DocumentWork docManager = DocumentWork.Instance;
            docManager.Menu();
        }
    }
}